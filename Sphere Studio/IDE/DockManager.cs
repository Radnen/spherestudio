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

        public IDockForm AddPane(Control control, string title, Icon icon, DockHint state)
        {
            return new DockForm(_panel, control, title, icon, state);
        }

        public void RemovePane(IDockForm pane)
        {
            ((DockForm)pane).Dispose();
        }
    }

    class DockForm : IDisposable, IDockForm
    {
        DockContent _content;
        Control _control;
        Control _main_form;

        public DockForm(DockPanel panel, Control control, string title, Icon icon, DockHint hint)
        {
            _main_form = panel.Parent;
            _control = control;

            DockState state = hint == DockHint.Float ? DockState.Float
                : hint == DockHint.Left ? DockState.DockLeft
                : hint == DockHint.Right ? DockState.DockRight
                : hint == DockHint.Top ? DockState.DockTop
                : hint == DockHint.Bottom ? DockState.DockBottom
                : DockState.Float;

            _content = new DockContent() { Name = title, TabText = title, Icon = icon };
            _content.Controls.Add(_control);
            _control.Dock = DockStyle.Fill;
            _content.DockAreas = DockAreas.Float
                | DockAreas.DockLeft | DockAreas.DockRight
                | DockAreas.DockBottom | DockAreas.DockTop;

            _content.Show(panel, state);
        }

        public void Dispose()
        {
            _content.Dispose();
            _control.Dispose();
        }

        public void Show()
        {
            Control oldFocus = _main_form;
            while (oldFocus is ContainerControl)
                oldFocus = ((ContainerControl)oldFocus).ActiveControl;
            _content.Show();
            if (oldFocus != null) oldFocus.Focus();
        }

        public void Hide()
        {
            _content.Hide();
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
