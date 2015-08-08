using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace minisphere.Remote
{
    enum DValueTag
    {
        EOM,
        REQ,
        REP,
        ERR,
        NFY,
        Unused,
        Undefined,
        Null,
        True,
        False,
        Object,
        HeapPtr,
        Pointer,
        Lightfunc,
    }

    class DuktapeClient : IDisposable
    {
        private TcpClient tcp = new TcpClient();

        public DuktapeClient(string hostname, int port)
        {
            tcp.Connect(hostname, port);

            // validate Duktape handshake and protocol version
            try {
                string line = "";
                byte[] buffer = new byte[1];
                while (buffer[0] != '\n')
                {
                    tcp.Client.ReceiveAll(buffer);
                    line += (char)buffer[0];
                }
                int debuggerVersion = Convert.ToInt32(line.Split(' ')[0]);
                if (debuggerVersion != 1)
                    throw new NotSupportedException("The debugger protocol is not supported.");
            }
            catch
            {
                throw new NotSupportedException("The debugger protocol is not supported.");
            }
        }

        public void Dispose()
        {
            tcp.Close();
        }

        public dynamic[] Receive()
        {
            List<dynamic> message = new List<dynamic>();
            dynamic value;
            while (!(value = ReceiveValue()).Equals(DValueTag.EOM))
            {
                message.Add(value);
            }
            return message.ToArray();
        }

        public dynamic ReceiveValue()
        {
            byte[] bytes;
            int length = -1;
            Encoding utf8 = new UTF8Encoding(false);

            if (!tcp.Client.ReceiveAll(bytes = new byte[1]))
                return null;
            if (bytes[0] >= 0x60 && bytes[0] < 0x80)
            {
                length = bytes[0] - 0x60;
                if (!tcp.Client.ReceiveAll(bytes = new byte[length]))
                    return null;
                return utf8.GetString(bytes);
            }
            else if (bytes[0] >= 0x80 && bytes[0] < 0xC0)
            {
                return bytes[0] - 0x80;
            }
            else if (bytes[0] >= 0xC0)
            {
                Array.Resize(ref bytes, 2);
                if (tcp.Client.Receive(bytes, 1, 1, SocketFlags.None) == 0)
                    return null;
                return ((bytes[0] - 0xC0) << 8) + bytes[1];
            }
            else
            {
                switch (bytes[0])
                {
                    case 0x00: return DValueTag.EOM;
                    case 0x01: return DValueTag.REQ;
                    case 0x02: return DValueTag.REP;
                    case 0x03: return DValueTag.ERR;
                    case 0x04: return DValueTag.NFY;
                    case 0x10: // 32-bit integer
                        if (!tcp.Client.ReceiveAll(bytes = new byte[4]))
                            return null;
                        return (bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3];
                    case 0x11: // string with 32-bit length
                        if (!tcp.Client.ReceiveAll(bytes = new byte[4]))
                            return null;
                        length = (bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3];
                        if (!tcp.Client.ReceiveAll(bytes = new byte[length]))
                            return null;
                        return utf8.GetString(bytes);
                    case 0x12: // string with 16-bit length
                        if (!tcp.Client.ReceiveAll(bytes = new byte[2]))
                            return null;
                        length = (bytes[0] << 8) + bytes[1];
                        if (!tcp.Client.ReceiveAll(bytes = new byte[length]))
                            return null;
                        return utf8.GetString(bytes);
                    case 0x13: // buffer with 32-bit length
                        if (!tcp.Client.ReceiveAll(bytes = new byte[4]))
                            return null;
                        length = (bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3];
                        if (!tcp.Client.ReceiveAll(bytes = new byte[length]))
                            return null;
                        return bytes;
                    case 0x14: // buffer with 16-bit length
                        if (!tcp.Client.ReceiveAll(bytes = new byte[2]))
                            return null;
                        length = (bytes[0] << 8) + bytes[1];
                        if (!tcp.Client.ReceiveAll(bytes = new byte[length]))
                            return null;
                        return bytes;
                    case 0x15: return DValueTag.Unused;
                    case 0x16: return DValueTag.Undefined;
                    case 0x17: return DValueTag.Null;
                    case 0x18: return DValueTag.True;
                    case 0x19: return DValueTag.False;
                    case 0x1A: // IEEE double
                        if (!tcp.Client.ReceiveAll(bytes = new byte[8]))
                            return null;
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);
                        return BitConverter.ToDouble(bytes, 0);
                    case 0x1B: // JS object
                        tcp.Client.ReceiveAll(bytes = new byte[2]);
                        tcp.Client.ReceiveAll(new byte[bytes[1]]);
                        return DValueTag.Object;
                    case 0x1C: // pointer
                        tcp.Client.ReceiveAll(bytes = new byte[1]);
                        tcp.Client.ReceiveAll(new byte[bytes[0]]);
                        return DValueTag.Pointer;
                    case 0x1D: // Duktape lightfunc
                        tcp.Client.ReceiveAll(bytes = new byte[3]);
                        tcp.Client.ReceiveAll(new byte[bytes[2]]);
                        return DValueTag.Lightfunc;
                    case 0x1E: // Duktape heap pointer
                        tcp.Client.ReceiveAll(bytes = new byte[1]);
                        tcp.Client.ReceiveAll(new byte[bytes[0]]);
                        return DValueTag.HeapPtr;
                    default:
                        return DValueTag.EOM;
                }
            }
        }

        public void Send(params dynamic[] values)
        {
            foreach (dynamic value in values)
            {
                Send(value);
            }
        }

        public void Send(DValueTag value)
        {
            switch (value)
            {
                case DValueTag.EOM: tcp.Client.Send(new byte[1] { 0x00 }); break;
                case DValueTag.REQ: tcp.Client.Send(new byte[1] { 0x01 }); break;
                case DValueTag.REP: tcp.Client.Send(new byte[1] { 0x02 }); break;
                case DValueTag.ERR: tcp.Client.Send(new byte[1] { 0x03 }); break;
                case DValueTag.NFY: tcp.Client.Send(new byte[1] { 0x04 }); break;
                case DValueTag.Unused: tcp.Client.Send(new byte[1] { 0x15 }); break;
                case DValueTag.Undefined: tcp.Client.Send(new byte[1] { 0x16 }); break;
                case DValueTag.Null: tcp.Client.Send(new byte[1] { 0x17 }); break;
                case DValueTag.True: tcp.Client.Send(new byte[1] { 0x18 }); break;
                case DValueTag.False: tcp.Client.Send(new byte[1] { 0x19 }); break;
            }
        }

        public void Send(int value)
        {
            if (value < 64)
            {
                tcp.Client.Send(new byte[] { (byte)(0x80 + value) });
            }
            else if (value < 16384)
            {
                tcp.Client.Send(new byte[] {
                    (byte)(0xC0 + (value >> 8 & 0xFF)),
                    (byte)(value & 0xFF)
                });
            }
            else
            {
                tcp.Client.Send(new byte[] { 0x10 });
                tcp.Client.Send(new byte[] {
                    (byte)(value >> 24 & 0xFF),
                    (byte)(value >> 16 & 0xFF),
                    (byte)(value >> 8 & 0xFF),
                    (byte)(value & 0xFF)
                });
            }
        }

        public void Send(string value)
        {
            var utf8 = new UTF8Encoding(false);
            byte[] stringBytes = utf8.GetBytes(value);

            tcp.Client.Send(new byte[] { 0x11 });
            tcp.Client.Send(new byte[]
            {
                (byte)(stringBytes.Length >> 24 & 0xFF),
                (byte)(stringBytes.Length >> 16 & 0xFF),
                (byte)(stringBytes.Length >> 8 & 0xFF),
                (byte)(stringBytes.Length & 0xFF)
            });
            tcp.Client.Send(stringBytes);
        }
    }
}
