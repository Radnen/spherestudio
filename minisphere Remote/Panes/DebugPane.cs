using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace minisphere.Remote.Panes
{
    public partial class DebugPane : UserControl
    {
        private IDockPane dockPane;

        private DebugPane()
        {
            InitializeComponent();
        }

        public DebugPane(string name, Bitmap icon = null, DockHint dockHint = DockHint.RightSide):
            this()
        {
            dockPane = PluginManager.IDE.Docking.AddPane(this, name,
                icon != null ? Icon.FromHandle(icon.GetHicon()) : null,
                dockHint);

            Disposed += this_Disposed;
        }

        public void Activate()
        {
            dockPane.Activate();
        }

        private void this_Disposed(object sender, EventArgs e)
        {
            dockPane.Hide();
        }
    }
}
