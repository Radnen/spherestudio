using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace minisphere.Remote
{
    enum DValue
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

    static class DValueExtensions
    {
        public static bool ReceiveAll(this Socket socket, byte[] buffer, SocketFlags socketFlags = SocketFlags.None)
        {
            int offset = 0;
            while (offset < buffer.Length)
            {
                int size = socket.Receive(buffer, offset, buffer.Length - offset, socketFlags);
                offset += size;
                if (size == 0) return false;
            }
            return true;
        }

        public static object ReceiveDValue(this Socket socket)
        {
            byte[] bytes;
            int length = -1;
            Encoding utf8 = new UTF8Encoding(false);

            if (!socket.ReceiveAll(bytes = new byte[1]))
                return null;
            if (bytes[0] >= 0x60 && bytes[0] < 0x80)
            {
                length = bytes[0] - 0x60;
                if (!socket.ReceiveAll(bytes = new byte[length]))
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
                if (socket.Receive(bytes, 1, 1, SocketFlags.None) == 0)
                    return null;
                return ((bytes[0] - 0xC0) << 8) + bytes[1];
            }
            else
            {
                switch (bytes[0])
                {
                    case 0x00: return DValue.EOM;
                    case 0x01: return DValue.REQ;
                    case 0x02: return DValue.REP;
                    case 0x03: return DValue.ERR;
                    case 0x04: return DValue.NFY;
                    case 0x10: // 32-bit integer
                        if (!socket.ReceiveAll(bytes = new byte[4]))
                            return null;
                        return (bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3];
                    case 0x11: // string with 32-bit length
                        if (!socket.ReceiveAll(bytes = new byte[4]))
                            return null;
                        length = (bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3];
                        if (!socket.ReceiveAll(bytes = new byte[length]))
                            return null;
                        return utf8.GetString(bytes);
                    case 0x12: // string with 16-bit length
                        if (!socket.ReceiveAll(bytes = new byte[2]))
                            return null;
                        length = (bytes[0] << 8) + bytes[1];
                        if (!socket.ReceiveAll(bytes = new byte[length]))
                            return null;
                        return utf8.GetString(bytes);
                    case 0x13: // buffer with 32-bit length
                        if (!socket.ReceiveAll(bytes = new byte[4]))
                            return null;
                        length = (bytes[0] << 24) + (bytes[1] << 16) + (bytes[2] << 8) + bytes[3];
                        if (!socket.ReceiveAll(bytes = new byte[length]))
                            return null;
                        return bytes;
                    case 0x14: // buffer with 16-bit length
                        if (!socket.ReceiveAll(bytes = new byte[2]))
                            return null;
                        length = (bytes[0] << 8) + bytes[1];
                        if (!socket.ReceiveAll(bytes = new byte[length]))
                            return null;
                        return bytes;
                    case 0x15: return DValue.Unused;
                    case 0x16: return DValue.Undefined;
                    case 0x17: return DValue.Null;
                    case 0x18: return DValue.True;
                    case 0x19: return DValue.False;
                    case 0x1A: // IEEE double
                        if (!socket.ReceiveAll(bytes = new byte[8]))
                            return null;
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);
                        return BitConverter.ToDouble(bytes, 0);
                    case 0x1B: // JS object
                        socket.ReceiveAll(bytes = new byte[2]);
                        socket.ReceiveAll(new byte[bytes[1]]);
                        return DValue.Object;
                    case 0x1C: // pointer
                        socket.ReceiveAll(bytes = new byte[1]);
                        socket.ReceiveAll(new byte[bytes[0]]);
                        return DValue.Pointer;
                    case 0x1D: // Duktape lightfunc
                        socket.ReceiveAll(bytes = new byte[3]);
                        socket.ReceiveAll(new byte[bytes[2]]);
                        return DValue.Lightfunc;
                    case 0x1E: // Duktape heap pointer
                        socket.ReceiveAll(bytes = new byte[1]);
                        socket.ReceiveAll(new byte[bytes[0]]);
                        return DValue.HeapPtr;
                    default:
                        return DValue.EOM;
                }
            }
        }

        public static void SendDValue(this Socket socket, DValue value)
        {
            switch (value)
            {
                case DValue.EOM: socket.Send(new byte[1] { 0x00 }); break;
                case DValue.REQ: socket.Send(new byte[1] { 0x01 }); break;
                case DValue.REP: socket.Send(new byte[1] { 0x02 }); break;
                case DValue.ERR: socket.Send(new byte[1] { 0x03 }); break;
                case DValue.NFY: socket.Send(new byte[1] { 0x04 }); break;
                case DValue.Unused: socket.Send(new byte[1] { 0x15 }); break;
                case DValue.Undefined: socket.Send(new byte[1] { 0x16 }); break;
                case DValue.Null: socket.Send(new byte[1] { 0x17 }); break;
                case DValue.True: socket.Send(new byte[1] { 0x18 }); break;
                case DValue.False: socket.Send(new byte[1] { 0x19 }); break;
            }
        }

        public static void SendDValue(this Socket socket, int value)
        {
            if (value < 64)
            {
                socket.Send(new byte[] { (byte)(0x80 + value) });
            }
            else if (value < 16384)
            {
                socket.Send(new byte[] {
                    (byte)(0xC0 + (value >> 8 & 0xFF)),
                    (byte)(value & 0xFF)
                });
            }
            else
            {
                socket.Send(new byte[] { 0x10 });
                socket.Send(new byte[] {
                    (byte)(value >> 24 & 0xFF),
                    (byte)(value >> 16 & 0xFF),
                    (byte)(value >> 8 & 0xFF),
                    (byte)(value & 0xFF)
                });
            }
        }

        public static void SendDValue(this Socket socket, string value)
        {
            var utf8 = new UTF8Encoding(false);
            byte[] stringBytes = utf8.GetBytes(value);

            socket.Send(new byte[] { 0x11 });
            socket.Send(new byte[]
            {
                (byte)(stringBytes.Length >> 24 & 0xFF),
                (byte)(stringBytes.Length >> 16 & 0xFF),
                (byte)(stringBytes.Length >> 8 & 0xFF),
                (byte)(stringBytes.Length & 0xFF)
            });
            socket.Send(stringBytes);
        }
    }
}
