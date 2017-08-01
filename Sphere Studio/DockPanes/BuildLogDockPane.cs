using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

using SphereStudio.UI;
using SphereStudio.Base;

namespace SphereStudio.Ide.BuiltIns
{
    [ToolboxItem(false)]
    partial class BuildLogDockPane : UserControl, IConsole, IDockPane, IStyleable
    {
        private string output = "";

        public BuildLogDockPane()
        {
            InitializeComponent();
            Styler.AutoStyle(this);
        }

        public Control Control { get { return this; } }

        public DockHint DockHint { get { return DockHint.Bottom; } }

        public Bitmap DockIcon { get { return Properties.Resources.application_view_list; } }

        public bool ShowInViewMenu { get { return true; } }

        public void Clear()
        {
            output = "";
            PluginManager.Core.Invoke(new Action(() =>
            {
                printTimer.Enabled = true;
            }), null);
        }

        public void Print(string lineText)
        {
            output += Regex.Replace(lineText, "\r?\n", "\r\n");
            PluginManager.Core.Invoke(new Action(() =>
            {
                printTimer.Enabled = true;
            }), null);
        }

        public void ApplyStyle(UIStyle theme)
        {
            theme.AsCodeView(textbox);
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
