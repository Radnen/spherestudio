using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using minisphere.Remote.Duktape;

namespace minisphere.Remote
{
    class DebugSession : IDisposable, IDebugger
    {
        private IProject ssproj;
        private DuktapeClient duktape;
        private Process engineProcess;
        private string engineDir;
        private ConcurrentQueue<dynamic[]> replies = new ConcurrentQueue<dynamic[]>();
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
            focusSwitchTimer.Dispose();
            Detach();
        }

        public string FileName { get; private set; }

        public int LineNumber { get; private set; }

        public bool Running { get; private set; }

        public event EventHandler Detached;

        public event EventHandler Paused;

        public event EventHandler Resumed;

        public async Task Connect(string hostname, int port, uint timeout = 5000)
        {
            long end = DateTime.Now.Ticks + timeout * 10000;
            var breaks = ssproj.GetAllBreakpoints();
            while (DateTime.Now.Ticks < end)
            {
                try {
                    duktape = new DuktapeClient();
                    duktape.Detached += duktape_Detached;
                    duktape.Paused += duktape_Paused;
                    duktape.Resumed += duktape_Resumed;
                    await duktape.Connect(hostname, port);
                    foreach (string filename in breaks.Keys)
                        foreach (int lineNumber in breaks[filename])
                            await SetBreakpoint(filename, lineNumber, true);
                    return;
                }
                catch (SocketException) { }
            }
            throw new TimeoutException();
        }

        private void duktape_Detached(object sender, EventArgs e)
        {
            if (Detached != null)
            {
                PluginManager.IDE.Invoke(Detached,
                    new object[] { this, EventArgs.Empty });
            }
        }

        private void duktape_Paused(object sender, EventArgs e)
        {
            focusSwitchTimer.Change(Timeout.Infinite, Timeout.Infinite);
            UpdateStatus();
            if (Paused != null)
            {
                PluginManager.IDE.Invoke(Paused,
                    new object[] { this, EventArgs.Empty });
            }
        }

        private void duktape_Resumed(object sender, EventArgs e)
        {
            focusSwitchTimer.Change(250, Timeout.Infinite);
            UpdateStatus();
            if (Resumed != null)
            {
                PluginManager.IDE.Invoke(Resumed,
                    new object[] { this, EventArgs.Empty });
            }
        }

        public void Detach()
        {
            engineProcess.CloseMainWindow();
            duktape.Dispose();
            duktape = null;
        }

        public async Task<IReadOnlyDictionary<string, string>> GetVariableList()
        {
            return await duktape.GetLocals();
        }

        public async Task SetBreakpoint(string filename, int lineNumber, bool isActive)
        {
            // convert filename to a SphereFS path
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

            // set the new breakpoint if needed
            if (isActive)
            {
                await duktape.AddBreak(relativePath, lineNumber);
            }
        }

        public async Task Run()
        {
            await duktape.Run();
        }

        public async Task Pause()
        {
            await duktape.Pause();
        }

        public async Task<string> Evaluate(string expression)
        {
            return await duktape.Eval(expression);
        }

        public async Task StepInto()
        {
            await duktape.StepInto();
        }

        public async Task StepOut()
        {
            await duktape.StepOut();
        }

        public async Task StepOver()
        {
            await duktape.StepOver();
        }

        private static void FocusEngine(object state)
        {
            DebugSession me = (DebugSession)state;
            NativeMethods.SetForegroundWindow(me.engineProcess.MainWindowHandle);
        }

        private void UpdateStatus()
        {
            string path = duktape.FileName;
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
            LineNumber = duktape.LineNumber;
            Running = duktape.Running;
        }
    }
}
