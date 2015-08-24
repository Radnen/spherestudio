using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace minisphere.Remote.Panes
{
    public partial class DebugPane : UserControl
    {
        private IDockForm dockPane;

        private DebugPane()
        {
            InitializeComponent();
        }

        public DebugPane(string name, Bitmap icon = null, DockHint dockHint = DockHint.Right):
            this()
        {
            dockPane = PluginManager.IDE.Docking.AddPane(this, name,
                icon != null ? Icon.FromHandle(icon.GetHicon()) : null,
                dockHint);

            Disposed += this_Disposed;
        }

        public void Activate()
        {
            dockPane.Show();
        }

        private void this_Disposed(object sender, EventArgs e)
        {
            dockPane.Hide();
        }
    }
}
