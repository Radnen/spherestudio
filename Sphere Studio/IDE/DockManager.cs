using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using WeifenLuo.WinFormsUI.Docking;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.IDE
{
    class DockManager : IDock
    {
        DockPanel _panel;

        public DockManager(DockPanel panel)
        {
            _panel = panel;
        }

        public IDockPane AddPane(Control control, string title, Icon icon, DockHint state)
        {
            return new DockPane(_panel, control, title, icon, state);
        }

        public void RemovePane(IDockPane pane)
        {
            ((DockPane)pane).Dispose();
        }
    }

    class DockPane : IDisposable, IDockPane
    {
        DockContent _content;
        Control _owner;

        public DockPane(DockPanel panel, Control control, string title, Icon icon, DockHint hint)
        {
            control.Dock = DockStyle.Fill;

            _owner = panel.Parent;

            _content = new DockContent() { Text = title, Icon = icon };
            _content.Controls.Add(control);
            _content.DockAreas = DockAreas.Float;
            _content.DockAreas |= (hint != DockHint.Document)
                ? DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop
                : DockAreas.Document;

            DockState state = hint == DockHint.Document ? DockState.Document
                : hint == DockHint.LeftSide ? DockState.DockLeft
                : hint == DockHint.RightSide ? DockState.DockRight
                : hint == DockHint.Top ? DockState.DockTop
                : hint == DockHint.Bottom ? DockState.DockBottom
                : DockState.Float;
            _content.Show(panel, state);
        }

        public void Dispose()
        {
            _content.Dispose();
        }

        public void Activate()
        {
            Control oldFocus = _owner;
            while (oldFocus is ContainerControl)
                oldFocus = ((ContainerControl)oldFocus).ActiveControl;
            _content.Show();
            if (oldFocus != null) oldFocus.Focus();
        }

        public void Hide()
        {
            _content.Hide();
        }

        public void Show()
        {
            _content.Show();
        }

        public void Toggle()
        {
            if (_content.Visible)
                Hide();
            else
                Show();
        }
    }
}
