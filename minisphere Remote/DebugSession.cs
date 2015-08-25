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

using minisphere.Remote.Panes;
using minisphere.Remote.Duktape;

namespace minisphere.Remote
{
    class DebugSession : IDebugger, IDisposable
    {
        private IProject ssproj;
        private DuktapeClient duktape;
        private Process engineProcess;
        private string engineDir;
        private ConcurrentQueue<dynamic[]> replies = new ConcurrentQueue<dynamic[]>();
        private System.Threading.Timer focusTimer;

        public DebugSession(IProject project, string enginePath, Process engine)
        {
            ssproj = project;
            engineProcess = engine;
            engineDir = Path.GetDirectoryName(enginePath);
            focusTimer = new System.Threading.Timer(
                FocusEngine, this,
                Timeout.Infinite, Timeout.Infinite);
        }

        public void Dispose()
        {
            Attached = null;
            Detached = null;
            Paused = null;
            Resumed = null;
            focusTimer.Dispose();
            duktape.Dispose();
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
            focusTimer.Change(Timeout.Infinite, Timeout.Infinite);
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

                Views.Inspector.CurrentSession = this;
                Views.Stack.CurrentSession = this;
                Views.Inspector.Enabled = false;
                Views.Stack.Enabled = false;
                Views.Console.Clear();
                Views.Errors.Clear();
                Views.Inspector.Clear();
                Views.Stack.Clear();

                var assembly = Assembly.GetExecutingAssembly();
                var title = assembly.GetCustomAttribute<AssemblyTitleAttribute>();
                Views.Console.Print(string.Format("{0} for Sphere Studio", title.Title));
                Views.Console.Print(string.Format("(c) 2015 Fat Cerberus", title.Title));
                Views.Console.Print("");
                Views.Console.Print(string.Format("The debuggee is {0}.", duktape.TargetID));
                Views.Console.Print(string.Format("(Duktape {0})", duktape.Version));
                Views.Console.Print("");

                Views.Inspector.DockPane.Show();
                Views.Stack.DockPane.Show();
            }), null);
        }

        private void duktape_Detached(object sender, EventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                if (Detached != null)
                    Detached(this, EventArgs.Empty);
                Views.Errors.ClearHighlight();
                Views.Inspector.Clear();
                Views.Inspector.Enabled = false;
                Views.Stack.Clear();
                Views.Stack.Enabled = false;

                Views.Console.Print("");
                Views.Console.Print(duktape.TargetID + " detached.");
            }), null);
        }

        private void duktape_ErrorThrown(object sender, ErrorThrownEventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                Views.Errors.Add(e.Message, e.IsFatal, e.Function, e.FileName, e.LineNumber);
                Views.Errors.DockPane.Show();
            }), null);
        }

        private void duktape_Print(object sender, TraceEventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(() =>
            {
                Views.Console.Print(e.Text);
            }), null);
        }

        private void duktape_Status(object sender, EventArgs e)
        {
            PluginManager.IDE.Invoke(new Action(async () =>
            {
                bool wantPause = !duktape.Running;
                bool wantResume = !Running && duktape.Running;
                Running = duktape.Running;
                focusTimer.Change(wantResume ? 250 : Timeout.Infinite, Timeout.Infinite);
                Tuple<string, string, int>[] callStack = null;
                IReadOnlyDictionary<string, string> vars = null;
                if (wantPause)
                {
                    callStack = await duktape.GetCallStack();
                    vars = await duktape.GetLocals();
                }
                if (wantPause && !duktape.Running)
                {
                    var topCall = callStack.First(entry => entry.Item2 != duktape.TargetID || entry.Item3 != 0);
                    FileName = ResolvePath(topCall.Item2);
                    LineNumber = topCall.Item3;
                    Views.Inspector.SetVariables(vars);
                    Views.Inspector.Enabled = true;
                    Views.Stack.UpdateStack(callStack);
                    Views.Stack.Enabled = true;
                    Views.Inspector.DockPane.Show();
                }
                if (duktape.Running)
                {
                    Views.Errors.ClearHighlight();
                    Views.Console.DockPane.Show();
                    Views.Inspector.Enabled = false;
                    Views.Stack.Enabled = false;
                    Views.Inspector.Clear();
                    Views.Stack.Clear();
                }
                if (wantPause && Paused != null)
                    Paused(this, EventArgs.Empty);
                if (wantResume && Resumed != null)
                    Resumed(this, EventArgs.Empty);
            }), null);
        }

        public async Task SetBreakpoint(string filename, int lineNumber, bool isSet)
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
            if (isSet)
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
