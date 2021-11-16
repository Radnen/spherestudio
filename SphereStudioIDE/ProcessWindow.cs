using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

/* WARNING: Portions of this code utilize multiple threads. */
namespace Sphere_Editor
{
    public partial class ProcessWindow : Panel
    {
        IntPtr AppWin = IntPtr.Zero;

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true)]
        private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);

        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);

        [DllImport("user32.dll", EntryPoint = "PostMessageA", SetLastError = true)]
        private static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);

        [DllImport("user32.dll", EntryPoint = "GetClientRect", SetLastError = true)]
        private static extern bool GetClientRect(IntPtr hwnd, out RECT lpRect);

        private const int GWL_STYLE = (-16);
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CLOSE = 0x10;

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;
        }

        private string proc = "";
        private string args = "";
        private bool running = false;
        private int width = 320;
        private int height = 240;

        public delegate void ProcEventHandler(object sender, EventArgs e);
        public event ProcEventHandler ProcessExited;

        private Process p;
        private Thread proc_thread;

        public ProcessWindow(string process, string arguments)
        {
            proc = process;
            args = arguments;
            InitializeComponent();
        }

        public void RunProcess()
        {
            try
            {
                p = Process.Start(proc, args);
                p.WaitForInputIdle();
                AppWin = p.MainWindowHandle;
                p.Exited += new EventHandler(p_Exited);
                p.EnableRaisingEvents = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(this, e.Message, "Process Error");
            }

            // Set the parent window handle to the processes.
            SetParent(AppWin, this.Handle);
            // Remove the border and what-not.
            SetWindowLong(AppWin, GWL_STYLE, WS_VISIBLE);
            RECT size = new RECT();
            GetClientRect(AppWin, out size);
            width = size.right-6;
            height = size.bottom-28;
            // Reset its position.
            MoveWindow(AppWin, (Width - width) / 2, (Height - height) / 2, width, height, true);
        }

        /* I callback to this thread safely via another thread when process exits. */
        void p_Exited(object sender, EventArgs e)
        {
            this.proc_thread = new Thread(new ThreadStart(this.Exit));
            this.proc_thread.Start();
        }

        public delegate void OnExit();

        /* Thread-safe wrapper to get thread's correct call. */
        public void Exit()
        {
            if (!this.running) return;
            if (this.InvokeRequired)
            {
                OnExit exit = new OnExit(this.Close);
                this.Invoke(exit);
            }
            else this.Close();
        }

        public void Close()
        {
            if (p.HasExited && ProcessExited != null) ProcessExited(this, new EventArgs());
        }

        protected override void OnVisibleChanged(EventArgs e)
        {
            if (!running) { running = true; RunProcess(); }
            base.OnVisibleChanged(e);
        }

        protected override void OnHandleDestroyed(EventArgs e)
        {
            if (AppWin != IntPtr.Zero)
            {
                // Send the message to close the process window:
                running = false;
                PostMessage(AppWin, WM_CLOSE, 0, 0);
                System.Threading.Thread.Sleep(250);
                AppWin = IntPtr.Zero;
            }
            base.OnHandleDestroyed(e);
        }

        protected override void OnResize(EventArgs e)
        {
            if (AppWin != IntPtr.Zero)
                MoveWindow(AppWin, (Width - width) / 2, (Height - height) / 2, width, height, true);
            base.OnResize(e);
        }

        private void ProcessWindow_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.DrawString(Global.CurrentProject.Path, this.Font, System.Drawing.Brushes.White, 0F, 0F); 
            e.Graphics.DrawString("Running: " + Global.CurrentProject.Name, this.Font, System.Drawing.Brushes.White, 0F, 12F);
            e.Graphics.DrawString("By: " + Global.CurrentProject.Author, this.Font, System.Drawing.Brushes.White, 0F, 24F);
        }
    }
}
