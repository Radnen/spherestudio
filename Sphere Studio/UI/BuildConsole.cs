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
    public partial class BuildConsole : UserControl, IConsole
    {
        private string output = "";

        public BuildConsole()
        {
            InitializeComponent();

            DockPane = PluginManager.IDE.Docking.AddPane(this, "Build", null, DockHint.Bottom);
            DockPane.Hide();
        }

        public IDockPane DockPane { get; private set; }

        public void Clear()
        {
            output = "";
            PluginManager.IDE.Invoke(new Action(() =>
            {
                printTimer.Enabled = true;
            }), null);
        }

        public void Print(string lineText)
        {
            output += Regex.Replace(lineText, "\r?\n", "\r\n");
            PluginManager.IDE.Invoke(new Action(() =>
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
