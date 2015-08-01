using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;

using Sphere.Plugins.Interfaces;
using Sphere.Plugins.DValues;

namespace SphereStudio.Plugins
{
    class DuktapeClient : IDisposable, IDebugger
    {
        private TcpClient tcp = new TcpClient();
        private IProject project;

        public DuktapeClient(IProject project)
        {
            this.project = project;
        }

        public void Dispose()
        {
            tcp.Close();
        }

        public string FileName { get; private set; }

        public int LineNumber { get; private set; }

        public bool Running { get; private set; }

        public event EventHandler Paused;

        public void Connect(string hostname, int port, uint timeout = 5000)
        {
            long end = DateTime.Now.Ticks + timeout * 10000;
            while (DateTime.Now.Ticks < end)
            {
                try {
                    tcp.Connect(hostname, port);
                    string line = "";
                    byte[] buffer = new byte[1];
                    while (buffer[0] != '\n')
                    {
                        tcp.Client.Receive(buffer);
                        line += (char)buffer[0];
                    }
                    int debuggerVersion = Convert.ToInt32(line.Split(' ')[0]);
                    if (debuggerVersion != 1)
                        throw new NotSupportedException("The debugger protocol is not supported.");
                    var thread = new Thread(Listener);
                    thread.Start();
                    return;
                }
                catch (SocketException) { }
            }
            throw new TimeoutException();
        }

        public void Run()
        {
            // REQ 13h EOM (Resume)
            byte[] request = new byte[] { 0x01, 0x93, 0 };
            tcp.Client.Send(request);
        }

        public void StepInto() { }
        public void StepOut() { }
        public void StepOver() { }

        private void Listener()
        {
            var message = new List<object>();
            while (true)
            {
                message.Clear();
                object value;
                while (true)
                {
                    if ((value = tcp.Client.ReceiveDValue()) == null)
                        return;
                    message.Add(value);
                    if (value.Equals(DValue.EOM))
                        break;
                }
                if (message[0].Equals(DValue.NFY))
                {
                    switch ((int)message[1])
                    {
                        case 0x01:
                            FileName = Path.Combine(project.RootPath, (string)message[3]);
                            LineNumber = (int)message[5];
                            Running = (int)message[2] == 0;
                            if (!Running && Paused != null)
                                Paused(this, EventArgs.Empty);
                            break;
                    }
                }
            }
        }
    }
}
