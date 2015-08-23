using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Reflection;
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
        private ConsolePane consoleView;
        private InspectorPane inspectorView;
        private StackPane stackView;
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
            consoleView.Dispose();
            inspectorView.Dispose();
        }

        public string FileName { get; private set; }

        public int LineNumber { get; private set; }

        public bool Running { get; private set; }

        public event EventHandler Attached;

        public event EventHandler Detached;

        public event EventHandler Paused;

        public event EventHandler Resumed;

        public async Task<bool> Attach()
        {
            try
            {
                await Connect("localhost", 812);
                return true;
            }
            catch (TimeoutException)
            {
                return false;
            }
        }

        public async Task Detach()
        {
            focusSwitchTimer.Change(Timeout.Infinite, Timeout.Infinite);
            await duktape.Detach();
            Dispose();
        }

        private async Task Connect(string hostname, int port, uint timeout = 5000)
        {
            long end = DateTime.Now.Ticks + timeout * 10000;
            while (DateTime.Now.Ticks < end)
            {
                try
                {
                    duktape = new DuktapeClient();
                    duktape.Attached += duktape_Attached;
                    duktape.Detached += duktape_Detached;
                    duktape.ErrorThrown += duktape_ErrorThrown;
                    duktape.Alert += duktape_Print;
                    duktape.Print += duktape_Print;
                    duktape.Status += duktape_Status;
                    await duktape.Connect(hostname, port);
                    return;
                }
                catch (SocketException) { } // *munch*
            }
            throw new TimeoutException();
        }

        private void duktape_Attached(object sender, EventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                if (Attached != null)
                    Attached(this, EventArgs.Empty);

                stackView = new StackPane(this) { Enabled = false };
                inspectorView = new InspectorPane(this) { Enabled = false };
                consoleView = new ConsolePane(this);

                var assembly = Assembly.GetExecutingAssembly();
                var title = assembly.GetCustomAttribute<AssemblyTitleAttribute>();
                consoleView.Print(string.Format("{0} for Sphere Studio", title.Title));
                consoleView.Print(string.Format("(c) 2015 Fat Cerberus", title.Title));
                consoleView.Print("");
                consoleView.Print(string.Format("The debuggee is {0}.", duktape.TargetID));
                consoleView.Print(string.Format("(Duktape {0})", duktape.Version));
                consoleView.Print("");
            }), null);
        }

        private void duktape_Detached(object sender, EventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                if (Detached != null)
                    Detached(this, EventArgs.Empty);
                inspectorView.Dispose();
                stackView.Dispose();
                consoleView.Dispose();
                inspectorView.Dispose();
                consoleView.Dispose();
            }), null);
        }

        private async void duktape_ErrorThrown(object sender, ErrorThrownEventArgs e)
        {
            if (e.IsFatal)
            {
                var stack = await duktape.GetCallStack();
                var topCall = stack.First(entry => entry.Item2 != "undefined" || entry.Item3 != 0);
                string message = string.Format("An exception was thrown by game code. Execution is suspended so you can examine the state of the program.  The value (string-coerced) and location of the thrown exception is shown below:\n\n({1}:{2})\n{0}",
                    e.Message, topCall.Item2, topCall.Item3);
                message += "\n\n\nContinue execution?  This will unwind the stack.";
                if (MessageBox.Show(message, "Unhandled Exception", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    await duktape.Resume();
                }
            }
        }

        private void duktape_Print(object sender, TraceEventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                consoleView.Print(e.Text);
            }), null);
        }

        private async void duktape_Status(object sender, EventArgs e)
        {
            bool wantPause = !duktape.Running;
            bool wantResume = !Running && duktape.Running;
            Running = duktape.Running;
            focusSwitchTimer.Change(wantResume ? 250 : Timeout.Infinite, Timeout.Infinite);
            Tuple<string, string, int> topCall = null;
            Tuple<string, string, int>[] stack = null;
            if (wantPause)
            {
                stack = await duktape.GetCallStack();
                topCall = stack.First(entry => entry.Item2 != "undefined" || entry.Item3 != 0);
                FileName = ResolvePath(topCall.Item2);
                LineNumber = topCall.Item3;
            }
            PluginManager.IDE.Invoke(new Action(async () =>
            {
                if (wantPause && Paused != null)
                    Paused(this, EventArgs.Empty);
                if (wantResume && Resumed != null)
                    Resumed(this, EventArgs.Empty);
                if (!duktape.Running)
                {
                    var variables = await duktape.GetLocals();
                    inspectorView.SetVariables(variables);
                    stackView.UpdateStack(stack);
                    inspectorView.Enabled = true;
                    stackView.Enabled = true;
                    inspectorView.Activate();
                }
            }), null);
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

        public async Task Resume()
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
            PluginManager.IDE.Invoke(new Action(() =>
            {
                DebugSession me = (DebugSession)state;
                NativeMethods.SetForegroundWindow(me.engineProcess.MainWindowHandle);
                me.consoleView.Activate();
                me.inspectorView.Enabled = false;
                me.inspectorView.Clear();
                me.stackView.Enabled = false;
                me.stackView.Clear();
            }), null);
        }

        /// <summary>
        /// Resolves a SphereFS path into an absolute one.
        /// </summary>
        /// <param name="path">The SphereFS path to resolve.</param>
        internal string ResolvePath(string path)
        {
            if (path.Length >= 2 && path.Substring(0, 2) == "~/")
                path = Path.Combine(ssproj.RootPath, path.Substring(2));
            else if (path.Length >= 5 && path.Substring(0, 5) == "~sgm/")
                path = Path.Combine(ssproj.RootPath, path.Substring(5));
            else if (path.Length >= 5 && path.Substring(0, 5) == "~sys/")
                path = Path.Combine(engineDir, "system", path.Substring(5));
            else if (path.Length >= 5 && path.Substring(0, 5) == "~usr/")
                path = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                    "minisphere", path.Substring(5));
            else
                path = Path.Combine(ssproj.RootPath, "scripts", path);
            return path.Replace('/', '\\');
        }

        private void UpdateStatus()
        {
            FileName = ResolvePath(duktape.FileName);
            LineNumber = duktape.LineNumber;
            Running = duktape.Running;
        }
    }
}
