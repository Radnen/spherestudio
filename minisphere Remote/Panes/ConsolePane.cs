using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace minisphere.Remote.Panes
{
    partial class ConsolePane : DebugPane
    {
        List<string> lines = new List<string>();

        public ConsolePane():
            base("Console", Properties.Resources.Console)
        {
            InitializeComponent();
        }

        public void Clear()
        {
            lines.Clear();
            updateTimer.Start();
        }

        public void Print(string text)
        {
            lines.Add(text);
            updateTimer.Start();
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            updateTimer.Stop();
            textOutput.Text = string.Join("\r\n", lines) + "\r\n";
            textOutput.SelectionStart = textOutput.Text.Length;
            textOutput.SelectionLength = 0;
            textOutput.ScrollToCaret();
        }
    }
}
