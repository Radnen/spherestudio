using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using SphereStudio.IDE;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Components
{
    public partial class BuildStatusView : UserControl
    {
        public BuildStatusView()
        {
            InitializeComponent();

            Pane = PluginManager.IDE.Docking.AddPane(this, "Build", null, DockHint.Bottom);
            Pane.Hide();
        }

        public IDockForm Pane { get; private set; }

        public void Clear()
        {
            textbox.Text = "";
        }

        public void Print(string text)
        {
            textbox.Text += text + "\r\n";
            textbox.SelectionStart = textbox.Text.Length;
            textbox.SelectionLength = 0;
            textbox.ScrollToCaret();
        }
    }
}
