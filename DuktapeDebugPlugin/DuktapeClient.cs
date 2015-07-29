using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Sphere.Plugins
{
    class DuktapeClient : IDisposable, IDebugger
    {
        TcpClient tcp;

        public DuktapeClient(string hostname, int port)
        {
            tcp = new TcpClient(hostname, port);
        }

        public void Dispose()
        {
            tcp.Close();
        }

        public void Run()
        {
            byte[] request = new byte[] { 0x01, 0x13, 0x0 };

            tcp.Client.Send(request);
        }

        public void StepInto() { }
        public void StepOut() { }
        public void StepOver() { }
    }
}
