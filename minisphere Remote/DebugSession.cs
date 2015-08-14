using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net.Sockets;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

using minisphere.Remote.Components;
using minisphere.Remote.Duktape;

namespace minisphere.Remote
{
    class DebugSession : IDebugger, IDisposable
    {
        private IProject ssproj;
        private DuktapeClient duktape;
        private Process engineProcess;
        private string engineDir;
        private ConsolePane console;
        private DockDescription consoleDock;
        private InspectorPane inspector;
        private DockDescription inspectorDock;
        private ConcurrentQueue<dynamic[]> replies = new ConcurrentQueue<dynamic[]>();
        private System.Threading.Timer focusSwitchTimer;

        public DebugSession(IProject project, string enginePath, Process engine)
        {
            ssproj = project;
            engineProcess = engine;
            engineDir = Path.GetDirectoryName(enginePath);
            focusSwitchTimer = new System.Threading.Timer(
                FocusEngine, this,
                Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            Attached = null;
            Detached = null;
            Paused = null;
            Resumed = null;
            focusSwitchTimer.Dispose();
            duktape.Dispose();
            console.Dispose();
            inspector.Dispose();
        }

        public string FileName { get; private set; }

        public int LineNumber { get; private set; }

        public bool Running { get; private set; }

        public event EventHandler Attached;

        public event EventHandler Detached;

        public event EventHandler Paused;

        public event EventHandler Resumed;

        public async Task Connect(string hostname, int port, uint timeout = 5000)
        {
            long end = DateTime.Now.Ticks + timeout * 10000;
            while (DateTime.Now.Ticks < end)
            {
                try {
                    duktape = new DuktapeClient();
                    duktape.Attached += duktape_Attached;
                    duktape.Detached += duktape_Detached;
                    duktape.Paused += duktape_Paused;
                    duktape.Resumed += duktape_Resumed;
                    duktape.Alert += duktape_Print;
                    duktape.Print += duktape_Print;
                    await duktape.Connect(hostname, port);
                    return;
                } catch (SocketException) { } // *munch*
            }
            throw new TimeoutException();
        }

        private void duktape_Print(object sender, TraceEventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                console.Print(e.Text);
            }), null);
        }

        private void duktape_Attached(object sender, EventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                if (Attached != null)
                    Attached(this, EventArgs.Empty);
                inspector = new InspectorPane(this) { Dock = DockStyle.Fill, Enabled = false };
                console = new ConsolePane() { Dock = DockStyle.Fill };
                inspectorDock = new DockDescription();
                inspectorDock.Control = inspector;
                inspectorDock.DockAreas = DockDescAreas.Sides;
                inspectorDock.DockState = DockDescStyle.Side;
                inspectorDock.HideOnClose = true;
                inspectorDock.TabText = "Inspector";
                inspectorDock.Icon = Icon.FromHandle(Properties.Resources.EyeOpen.GetHicon());
                PluginManager.IDE.DockControl(inspectorDock);
                consoleDock = new DockDescription();
                consoleDock.Control = console;
                consoleDock.DockAreas = DockDescAreas.Sides;
                consoleDock.DockState = DockDescStyle.Side;
                consoleDock.HideOnClose = true;
                consoleDock.TabText = "Console";
                consoleDock.Icon = Icon.FromHandle(Properties.Resources.Listing.GetHicon());
                PluginManager.IDE.DockControl(consoleDock);
                var assembly = Assembly.GetExecutingAssembly();
                var title = assembly.GetCustomAttribute<AssemblyTitleAttribute>();
                console.Print(string.Format("{0} for Sphere Studio", title.Title));
                console.Print(string.Format("(c) 2015 Fat Cerberus", title.Title));
                console.Print("");
                console.Print(duktape.TargetID);
                console.Print("");
            }), null);
        }

        private void duktape_Detached(object sender, EventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                if (Detached != null)
                    Detached(this, EventArgs.Empty);
                inspectorDock.Hide();
                consoleDock.Hide();
                inspector.Dispose();
                console.Dispose();
            }), null);
        }

        private void duktape_Paused(object sender, EventArgs e)
        {
            focusSwitchTimer.Change(Timeout.Infinite, Timeout.Infinite);
            UpdateStatus();
            PluginManager.IDE.Invoke(new Action(async () =>
            {
                if (Paused != null)
                    Paused(this, EventArgs.Empty);
                var variables = await GetVariableList();
                if (!Running)
                {
                    inspector.SetVariables(variables);
                    inspector.Enabled = true;
                    inspectorDock.Show();
                }
            }), null);
        }

        private void duktape_Resumed(object sender, EventArgs e)
        {
            focusSwitchTimer.Change(250, Timeout.Infinite);
            UpdateStatus();
            PluginManager.IDE.Invoke(new Action(() =>
            {
                if (Resumed != null)
                    Resumed(this, EventArgs.Empty);
                inspector.Enabled = false;
                inspector.Clear();
                consoleDock.Show();
            }), null);
        }

        public async Task Detach()
        {
            focusSwitchTimer.Change(Timeout.Infinite, Timeout.Infinite);
            await duktape.Detach();
            Dispose();
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
            if (filename.StartsWith(rootPath))
                relativePath = filename.Substring(rootPath.Length).Replace('\\', '/');
            if (filename.StartsWith(sysPath))
                relativePath = string.Format("~sys/{0}", filename.Substring(sysPath.Length).Replace('\\', '/'));

            // clear all matching breakpoints
            var breaks = await duktape.ListBreak();
            for (int i = breaks.Length - 1; i >= 0; --i)
            {
                string fn = breaks[i].Item1;
                int line = breaks[i].Item2;
                if (relativePath == fn && lineNumber == line)
                    await duktape.DelBreak(i);
            }
            
            // set the breakpoint if needed
            if (isActive)
            {
                await duktape.AddBreak(relativePath, lineNumber);
            }
        }

        public async Task Run()
        {
            await duktape.Resume();
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
