using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using SphereStudio.IDE;

namespace SphereStudio.UI
{
    [ToolboxItem(false)]
    partial class BuildConsole : UserControl, IConsole, IDockPane
    {
        private string output = "";

        public BuildConsole()
        {
            InitializeComponent();
        }

        public Control Control { get { return this; } }

        public DockHint DockHint { get { return DockHint.Bottom; } }

        public Bitmap DockIcon { get { return Properties.Resources.application_view_list; } }

        public bool ShowInViewMenu { get { return true; } }

        public void Clear()
        {
            output = "";
            Sphere.Plugins.PluginManager.IDE.Invoke(new Action(() =>
            {
                printTimer.Enabled = true;
            }), null);
        }

        public void Print(string lineText)
        {
            output += Regex.Replace(lineText, "\r?\n", "\r\n");
            Sphere.Plugins.PluginManager.IDE.Invoke(new Action(() =>
            {
                printTimer.Enabled = true;
            }), null);
        }

        private void printTimer_Tick(object sender, EventArgs e)
        {
            printTimer.Enabled = false;
            textbox.Text = output;
            textbox.SelectionStart = textbox.Text.Length;
            textbox.SelectionLength = 0;
            textbox.ScrollToCaret();
        }
    }
}
