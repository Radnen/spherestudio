using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace minisphere.GDK.Debugger.UI
{
    partial class DebugPane : UserControl, IDockPane
    {
        private DebugPane()
        {
            InitializeComponent();
        }

        public DebugPane(Bitmap icon = null, DockHint dockHint = DockHint.Right)
            : this()
        {
            DockHint = dockHint;
            DockIcon = icon;
        }

        public Control Control { get { return this; } }

        public DockHint DockHint { get; private set; }

        public Bitmap DockIcon { get; private set; }

        public bool ShowInViewMenu { get { return false; } }
    }
}
