using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace minisphere.Remote.Panes
{
    public partial class DebugPane : UserControl
    {
        private DebugPane()
        {
            InitializeComponent();
        }

        public DebugPane(string name, Bitmap icon = null, DockHint dockHint = DockHint.Right):
            this()
        {
            DockPane = PluginManager.IDE.Docking.AddPane(this, name,
                icon != null ? Icon.FromHandle(icon.GetHicon()) : null,
                dockHint);

            Disposed += this_Disposed;
        }

        public IDockForm DockPane { get; private set; }

        private void this_Disposed(object sender, EventArgs e)
        {
            DockPane.Hide();
        }
    }
}
