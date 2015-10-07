using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace minisphere.GDK.Debugger.UI
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
            this.Disposed += (sender, e) => DockPane.Dispose();
        }

        public IDockPane DockPane { get; private set; }
    }
}
