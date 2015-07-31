using System;
using System.Net;
using System.Net.Sockets;

using Sphere.Plugins.Interfaces;

namespace SphereStudio.Plugins
{
    class DuktapeClient : IDisposable, IDebugger
    {
        TcpClient tcp = new TcpClient();

        public DuktapeClient()
        {
        }

        public void Dispose()
        {
            tcp.Close();
        }

        public void Connect(string hostname, int port, uint timeout = 5000)
        {
            long end = DateTime.Now.Ticks + timeout * 10000;
            while (DateTime.Now.Ticks < end)
            {
                try {
                    tcp.Connect(hostname, port);
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
    }
}
