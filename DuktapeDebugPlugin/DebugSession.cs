using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using System.Threading.Tasks;

namespace minisphere.Remote
{
    class DebugSession : IDisposable, IDebugger
    {
        [DllImport("user32.dll")] [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        private IProject ssproj;
        private DuktapeClient duktape;
        private Process engineProcess;
        private string engineDir;
        private ConcurrentQueue<object[]> replies = new ConcurrentQueue<object[]>();
        private Thread messageReader;
        private Timer focusSwitchTimer;

        public DebugSession(IProject project, string enginePath, Process engine)
        {
            ssproj = project;
            engineProcess = engine;
            engineDir = Path.GetDirectoryName(enginePath);
            focusSwitchTimer = new Timer(FocusEngine, this, Timeout.Infinite, Timeout.Infinite);
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
            var breaks = ssproj.GetAllBreakpoints();
            while (DateTime.Now.Ticks < end)
            {
                try {
                    duktape = new DuktapeClient(hostname, port);
                    messageReader = new Thread(RunDebugger);
                    messageReader.Start();
                    foreach (string filename in breaks.Keys)
                    {
                        foreach (int lineNumber in breaks[filename])
                        {
                            string relativePath = filename;
                            string rootPath = Path.Combine(ssproj.RootPath, @"scripts") + @"\";
                            string sysPath = Path.Combine(engineDir, @"system") + @"\";
                            try
                            {
                                if (filename.Substring(0, rootPath.Length) == rootPath)
                                    relativePath = filename.Substring(rootPath.Length).Replace('\\', '/');
                            } catch { } // *munch*
                            try
                            {
                                if (filename.Substring(0, sysPath.Length) == sysPath)
                                    relativePath = string.Format("~sys/{0}", filename.Substring(sysPath.Length).Replace('\\', '/'));
                            } catch { } // *munch*
                            duktape.Send(DValueTag.REQ);
                            duktape.Send(0x18);
                            duktape.Send(relativePath);
                            duktape.Send(lineNumber);
                            duktape.Send(DValueTag.EOM);
                            ReadReply();
                        }
                    }
                    return;
                }
                catch (SocketException) { }
            }
            throw new TimeoutException();
        }

        public void Detach()
        {
            if (messageReader != null)
            {
                engineProcess.CloseMainWindow();
                messageReader.Abort();
                duktape.Dispose();
                messageReader = null;
                duktape = null;
                if (Detached != null) Detached(this, EventArgs.Empty);
            }
        }

        public IReadOnlyDictionary<string, string> GetVariableList()
        {
            duktape.Send(DValueTag.REQ, 0x1D, DValueTag.EOM);
            object[] reply = ReadReply();
            var variables = new Dictionary<string, string>();
            int count = (reply.Length - 2) / 2;
            for (int i = 0; i < count; ++i)
            {
                string name = reply[i * 2 + 1].ToString();
                string value = reply[i * 2 + 2].Equals(DValueTag.Object) ? "(JavaScript object)" : Evaluate(name);
                variables.Add(name, value);
            }
            return variables;
        }

        public void Run()
        {
            duktape.Send(DValueTag.REQ, 0x13, DValueTag.EOM);
            ReadReply();
        }

        public void BreakNow()
        {
            duktape.Send(DValueTag.REQ, 0x12, DValueTag.EOM);
            ReadReply();
        }

        public string Evaluate(string expression)
        {
            var eval = string.Format(
                @"(function() {{ try {{ return Duktape.enc('jx', ({0}), null, 2); }} catch (e) {{ return e.toString(); }} }})();",
                expression);
            duktape.Send(DValueTag.REQ, 0x1E, eval, DValueTag.EOM);
            var reply = ReadReply();
            bool ok = reply != null && (int)reply[1] == 0;
            return ok ? (string)reply[2] : null;
        }

        public void StepInto()
        {
            duktape.Send(DValueTag.REQ, 0x14, DValueTag.EOM);
            ReadReply();
        }

        public void StepOut()
        {
            duktape.Send(DValueTag.REQ, 0x16, DValueTag.EOM);
            ReadReply();
        }

        public void StepOver()
        {
            duktape.Send(DValueTag.REQ, 0x15, DValueTag.EOM);
            ReadReply();
        }

        private static void FocusEngine(object state)
        {
            DebugSession me = (DebugSession)state;
            SetForegroundWindow(me.engineProcess.MainWindowHandle);
        }

        private object[] ReadReply()
        {
            while (replies.Count <= 0 && messageReader.IsAlive) ;
            object[] reply;
            bool ok = replies.TryDequeue(out reply);
            return ok ? reply : null;
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
                    if ((value = duktape.ReceiveValue()) == null)
                        goto detach;
                    message.Add(value);
                    if (value.Equals(DValueTag.EOM))
                        break;
                }
                if (message[0].Equals(DValueTag.NFY))
                {
                    switch ((int)message[1])
                    {
                        case 0x01:
                            string path = (string)message[3];
                            if (path.Length >= 2 && path.Substring(0, 2) == "~/")
                                FileName = Path.Combine(ssproj.RootPath, path.Substring(2));
                            else if (path.Length >= 5 && path.Substring(0, 5) == "~sgm/")
                                FileName = Path.Combine(ssproj.RootPath, path.Substring(5));
                            else if (path.Length >= 5 && path.Substring(0, 5) == "~sys/")
                                FileName = Path.Combine(engineDir, "system", path.Substring(5));
                            else if (path.Length >= 5 && path.Substring(0, 5) == "~usr/")
                                FileName = Path.Combine(
                                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                                    "minisphere", path.Substring(5));
                            else
                                FileName = Path.Combine(ssproj.RootPath, "scripts", path);
                            FileName = FileName.Replace('/', '\\');
                            LineNumber = (int)message[5];
                            bool wasRunning = Running;
                            Running = (int)message[2] == 0;
                            if (Running && !wasRunning)
                            {
                                focusSwitchTimer.Change(250, Timeout.Infinite);
                                if (Resumed != null)
                                    Resumed(this, EventArgs.Empty);
                            }
                            if (!Running)
                            {
                                focusSwitchTimer.Change(Timeout.Infinite, Timeout.Infinite);
                                if (Paused != null)
                                    Paused(this, EventArgs.Empty);
                            }
                            break;
                    }
                }
                else if (message[0].Equals(DValueTag.REP)
                    || message[0].Equals(DValueTag.ERR))
                {
                    replies.Enqueue(message.ToArray());
                }
            }

        detach:
            if (Detached != null)
                Detached(this, EventArgs.Empty);
        }
    }
}
