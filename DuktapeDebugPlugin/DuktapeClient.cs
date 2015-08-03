using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.DValues;

namespace SphereStudio.Plugins
{
    class DuktapeClient : IDisposable, IDebugger
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private Timer _activator;
        private Process _engine;
        private string _engineDir;
        private IProject _project;
        private TcpClient _tcp;
        private Thread _thread;

        public DuktapeClient(IProject project, string enginePath, Process engine)
        {
            _engine = engine;
            _engineDir = Path.GetDirectoryName(enginePath);
            _project = project;
            _activator = new Timer(FocusEngine, this, Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            Detach();
        }

        public string FileName { get; private set; }

        public int LineNumber { get; private set; }

        public bool Running { get; private set; }

        public event EventHandler Detached;

        public event EventHandler Paused;

        public event EventHandler Resumed;

        public void Connect(string hostname, int port, uint timeout = 5000)
        {
            long end = DateTime.Now.Ticks + timeout * 10000;
            while (DateTime.Now.Ticks < end)
            {
                try {
                    _tcp = new TcpClient(hostname, port);
                    string line = "";
                    byte[] buffer = new byte[1];
                    while (buffer[0] != '\n')
                    {
                        _tcp.Client.Receive(buffer);
                        line += (char)buffer[0];
                    }
                    int debuggerVersion = Convert.ToInt32(line.Split(' ')[0]);
                    if (debuggerVersion != 1)
                        throw new NotSupportedException("The debugger protocol is not supported.");
                    _thread = new Thread(RunDebugger);
                    _thread.Start();
                    return;
                }
                catch (SocketException) { }
            }
            throw new TimeoutException();
        }

        public void Detach()
        {
            if (_thread != null)
            {
                _thread.Abort();
                _tcp.Close();
                _thread = null;
                _tcp = null;
                if (Detached != null) Detached(this, EventArgs.Empty);
            }
        }

        public void Run()
        {
            // REQ 13h EOM (Resume)
            byte[] request = new byte[] { 0x01, 0x93, 0 };
            _tcp.Client.Send(request);
        }

        public void StepInto()
        {
            // REQ 14h EOM (Step Into)
            byte[] request = new byte[] { 0x01, 0x94, 0 };
            _tcp.Client.Send(request);
        }

        public void StepOut()
        {
            // REQ 16h EOM (Step Out)
            byte[] request = new byte[] { 0x01, 0x96, 0 };
            _tcp.Client.Send(request);
        }

        public void StepOver()
        {
            // REQ 15h EOM (Step Over)
            byte[] request = new byte[] { 0x01, 0x95, 0 };
            _tcp.Client.Send(request);
        }

        private static void FocusEngine(object state)
        {
            DuktapeClient me = (DuktapeClient)state;
            SetForegroundWindow(me._engine.MainWindowHandle);
        }

        private void RunDebugger()
        {
            var message = new List<object>();
            while (true)
            {
                message.Clear();
                object value;
                while (true)
                {
                    if ((value = _tcp.Client.ReceiveDValue()) == null)
                        goto detach;
                    message.Add(value);
                    if (value.Equals(DValue.EOM))
                        break;
                }
                if (message[0].Equals(DValue.NFY))
                {
                    switch ((int)message[1])
                    {
                        case 0x01:
                            string path = (string)message[3];
                            if (path.Substring(0, 5) == "~sgm/")
                                FileName = Path.Combine(_project.RootPath, path.Substring(5));
                            else if (path.Substring(0, 2) == "~/")
                                FileName = Path.Combine(_project.RootPath, path.Substring(2));
                            else if (path.Substring(0, 5) == "~sys/")
                                FileName = Path.Combine(_engineDir, "system", path.Substring(5));
                            else if (path.Substring(0, 5) == "~usr/")
                                FileName = Path.Combine(
                                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                    "minisphere", path.Substring(5));
                            else
                                FileName = Path.Combine(_project.RootPath, "scripts", path);
                            LineNumber = (int)message[5];
                            bool wasRunning = Running;
                            Running = (int)message[2] == 0;
                            if (Running && !wasRunning)
                            {
                                _activator.Change(250, Timeout.Infinite);
                                if (Resumed != null)
                                    Resumed(this, EventArgs.Empty);
                            }
                            if (!Running)
                            {
                                _activator.Change(Timeout.Infinite, Timeout.Infinite);
                                if (Paused != null)
                                    Paused(this, EventArgs.Empty);
                            }
                            break;
                    }
                }
            }

        detach:
            if (Detached != null)
                Detached(this, EventArgs.Empty);
        }
    }
}
