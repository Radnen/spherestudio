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
        public ConsolePane(DebugSession session):
            base("Console", Properties.Resources.Console)
        {
            InitializeComponent();
        }

        public void Print(string text)
        {
            textOutput.Text += text + "\r\n";
            textOutput.SelectionStart = textOutput.Text.Length;
            textOutput.SelectionLength = 0;
            textOutput.ScrollToCaret();
        }
    }
}
