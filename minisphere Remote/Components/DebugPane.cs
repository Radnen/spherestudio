using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;

namespace minisphere.Remote.Components
{
    public partial class DebugPane : UserControl
    {
        private DockDescription dock;

        private DebugPane()
        {
            InitializeComponent();
        }

        public DebugPane(string name, Bitmap icon = null):
            this()
        {
            Dock = DockStyle.Fill;

            dock = new DockDescription();
            dock.Control = this;
            dock.DockAreas = DockDescAreas.Sides;
            dock.DockState = DockDescStyle.Opposite;
            dock.HideOnClose = true;
            dock.TabText = name;
            dock.Icon = icon != null ? Icon.FromHandle(icon.GetHicon()) : null;
            PluginManager.IDE.DockControl(dock);

            Disposed += this_Disposed;
        }

        public void Activate()
        {
            dock.Activate();
        }

        private void this_Disposed(object sender, EventArgs e)
        {
            dock.Hide();
        }
    }
}
