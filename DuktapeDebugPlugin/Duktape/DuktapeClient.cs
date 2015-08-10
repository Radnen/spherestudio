using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace minisphere.Remote.Duktape
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

    class DuktapeClient : IDisposable
    {
        private TcpClient tcp = new TcpClient();
        private Queue<dynamic[]> requests = new Queue<dynamic[]>();
        private Dictionary<dynamic[], dynamic[]> replies = new Dictionary<dynamic[], dynamic[]>();
        private object replyLock = new object();
        private Thread messenger;

        public DuktapeClient()
        {
        }

        public void Dispose()
        {
            tcp.Close();
        }

        /// <summary>
        /// Fires when the debugger is first attached.
        /// </summary>
        public event EventHandler Attached;

        /// <summary>
        /// Fires when the debugger is detached from the target.
        /// </summary>
        public event EventHandler Detached;

        /// <summary>
        /// Fires when execution pauses, e.g. at a breakpoint.
        /// </summary>
        public event EventHandler Paused;

        /// <summary>
        /// Fires when execution has resumed.
        /// </summary>
        public event EventHandler Resumed;
        
        /// <summary>
        /// Gets the filename reported in the last status update.
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// Gets the line number being executed as of the last status update.
        /// </summary>
        public int LineNumber { get; private set; }

        /// <summary>
        /// Gets whether the target is currently executing code.
        /// </summary>
        public bool Running { get; private set; }

        public async Task Connect(string hostname, int port)
        {
            await tcp.ConnectAsync(hostname, port);
            try
            {
                string line = "";
                byte[] buffer = new byte[1];
                while (buffer[0] != '\n')
                {
                    tcp.Client.ReceiveAll(buffer);
                    line += (char)buffer[0];
                }
                int debuggerVersion = Convert.ToInt32(line.Split(' ')[0]);
                if (debuggerVersion != 1)
                    throw new NotSupportedException("Wrong Duktape protocol version or protocol not supported");
                messenger = new Thread(RunMessenger);
                messenger.Start();
                if (Attached != null)
                {
                    Attached(this, EventArgs.Empty);
                }
            }
            catch
            {
                throw new NotSupportedException("Wrong Duktape protocol version or protocol not supported");
            }
        }

        /// <summary>
        /// Sets a breakpoint. Execution will pause automatically if the breakpoint is hit.
        /// </summary>
        /// <param name="filename">The filename in which to place the breakpoint.</param>
        /// <param name="lineNumber">The line number of the breakpoint.</param>
        /// <returns>The index assigned to the breakpoint by Duktape.</returns>
        public async Task<int> AddBreak(string filename, int lineNumber)
        {
            var reply = await Converse(DValue.REQ, 0x18, filename, lineNumber);
            return reply[1];
        }

        public async Task DelBreak(int index)
        {
            await Converse(DValue.REQ, 0x19, index);
        }

        public async Task<Tuple<string, int>[]> ListBreak()
        {
            var reply = await Converse(DValue.REQ, 0x17);
            var count = (reply.Length - 1) / 2;
            List<Tuple<string, int>> list = new List<Tuple<string, int>>();
            for (int i = 0; i < count; ++i)
            {
                var breakpoint = Tuple.Create(reply[1 + i * 2], reply[2 + i * 2]);
                list.Add(breakpoint);
            }
            return list.ToArray();
        }

        public async Task<string> Eval(string expression)
        {
            var code = string.Format(
                @"(function() {{ try {{ return Duktape.enc('jx', eval(""{0}""), null, 2); }} catch (e) {{ return e.toString(); }} }})();",
                expression.Replace(@"\", @"\\").Replace(@"""", @"\"""));
            var reply = await Converse(DValue.REQ, 0x1E, code);
            return reply[2];
        }

        public async Task<IReadOnlyDictionary<string, string>> GetLocals()
        {
            var reply = await Converse(DValue.REQ, 0x1D);
            var variables = new Dictionary<string, string>();
            int count = (reply.Length - 1) / 2;
            for (int i = 0; i < count; ++i)
            {
                string name = reply[1 + i * 2].ToString();
                dynamic value = reply[2 + i * 2];
                string friendlyValue = value.Equals(DValue.Object) ? "JS object"
                    : value is int ? value.ToString()
                    : value is double ? value.ToString()
                    : value is string ? string.Format("\"{0}\"", value)
                    : await Eval(name);
                variables.Add(name, friendlyValue);
            }
            return variables;
        }

        public async Task Pause()
        {
            await Converse(DValue.REQ, 0x12);
        }

        public async Task Run()
        {
            await Converse(DValue.REQ, 0x13);
        }

        public async Task StepInto()
        {
            await Converse(DValue.REQ, 0x14);
        }

        public async Task StepOut()
        {
            await Converse(DValue.REQ, 0x16);
        }

        public async Task StepOver()
        {
            await Converse(DValue.REQ, 0x15);
        }

        private dynamic[] ReceiveMessage()
        {
            List<dynamic> message = new List<dynamic>();
            dynamic value;
            do
            {
                if ((value = ReceiveValue()) == null)
                    return null;
                message.Add(value);
            } while (!value.Equals(DValue.EOM));
            return message.ToArray();
        }

        private dynamic ReceiveValue()
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
                    case 0x00: return DValue.EOM;
                    case 0x01: return DValue.REQ;
                    case 0x02: return DValue.REP;
                    case 0x03: return DValue.ERR;
                    case 0x04: return DValue.NFY;
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
                    case 0x15: return DValue.Unused;
                    case 0x16: return DValue.Undefined;
                    case 0x17: return DValue.Null;
                    case 0x18: return DValue.True;
                    case 0x19: return DValue.False;
                    case 0x1A: // IEEE double
                        if (!tcp.Client.ReceiveAll(bytes = new byte[8]))
                            return null;
                        if (BitConverter.IsLittleEndian)
                            Array.Reverse(bytes);
                        return BitConverter.ToDouble(bytes, 0);
                    case 0x1B: // JS object
                        tcp.Client.ReceiveAll(bytes = new byte[2]);
                        tcp.Client.ReceiveAll(new byte[bytes[1]]);
                        return DValue.Object;
                    case 0x1C: // pointer
                        tcp.Client.ReceiveAll(bytes = new byte[1]);
                        tcp.Client.ReceiveAll(new byte[bytes[0]]);
                        return DValue.Pointer;
                    case 0x1D: // Duktape lightfunc
                        tcp.Client.ReceiveAll(bytes = new byte[3]);
                        tcp.Client.ReceiveAll(new byte[bytes[2]]);
                        return DValue.Lightfunc;
                    case 0x1E: // Duktape heap pointer
                        tcp.Client.ReceiveAll(bytes = new byte[1]);
                        tcp.Client.ReceiveAll(new byte[bytes[0]]);
                        return DValue.HeapPtr;
                    default:
                        return DValue.EOM;
                }
            }
        }
        
        private void SendValue(DValue value)
        {
            switch (value)
            {
                case DValue.EOM: tcp.Client.Send(new byte[1] { 0x00 }); break;
                case DValue.REQ: tcp.Client.Send(new byte[1] { 0x01 }); break;
                case DValue.REP: tcp.Client.Send(new byte[1] { 0x02 }); break;
                case DValue.ERR: tcp.Client.Send(new byte[1] { 0x03 }); break;
                case DValue.NFY: tcp.Client.Send(new byte[1] { 0x04 }); break;
                case DValue.Unused: tcp.Client.Send(new byte[1] { 0x15 }); break;
                case DValue.Undefined: tcp.Client.Send(new byte[1] { 0x16 }); break;
                case DValue.Null: tcp.Client.Send(new byte[1] { 0x17 }); break;
                case DValue.True: tcp.Client.Send(new byte[1] { 0x18 }); break;
                case DValue.False: tcp.Client.Send(new byte[1] { 0x19 }); break;
            }
        }

        private void SendValue(int value)
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

        private void SendValue(string value)
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

        private async Task<dynamic[]> Converse(params dynamic[] values)
        {
            foreach (dynamic value in values)
            {
                SendValue(value);
            }
            SendValue(DValue.EOM);
            lock (replyLock)
            {
                requests.Enqueue(values);
            }
            return await Task.Run(() =>
            {
                while (true)
                {
                    lock (replyLock)
                    {
                        if (replies.ContainsKey(values))
                        {
                            var reply = replies[values];
                            replies.Remove(values);
                            return reply;
                        }
                    }
                    Thread.Sleep(0);
                }
            });
        }

        private void RunMessenger()
        {
            while (true)
            {
                dynamic[] message = ReceiveMessage();
                if (message == null) goto detachNow;
                if (message[0] == DValue.NFY)
                {
                    int commandID = message[1];
                    switch (commandID)
                    {
                        case 0x01:
                            FileName = message[3];
                            LineNumber = message[5];
                            bool wasRunning = Running;
                            Running = message[2] == 0;
                            if (Running && !wasRunning && Resumed != null)
                                Resumed(this, EventArgs.Empty);
                            if (!Running && Paused != null)
                                Paused(this, EventArgs.Empty);
                            break;
                    }
                }
                else if (message[0] == DValue.REP || message[0] == DValue.ERR)
                {
                    lock (replyLock)
                    {
                        dynamic[] request = requests.Dequeue();
                        replies.Add(request, message.Take(message.Length - 1).ToArray());
                    }
                }
            }

        detachNow:
            if (Detached != null)
            {
                Detached(this, EventArgs.Empty);
            }
        }
    }
}
