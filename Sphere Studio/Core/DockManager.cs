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

namespace SphereStudio
{
    struct DockForm
    {
        public string Name;
        public DockContent Content;
        public IDockPane Pane;
    }

    class DockManager : IDock
    {
        List<DockForm> _dockForms = new List<DockForm>();
        DockPanel _mainPanel;

        public DockManager(DockPanel mainPanel)
        {
            _mainPanel = mainPanel;
        }

        public void Refresh()
        {
            DockForm[] removedForms = _dockForms
                .Where(x => PluginManager.Get<IDockPane>(x.Name) == null)
                .ToArray();
            foreach (DockForm form in removedForms)
            {
                form.Content.Dispose();
                _dockForms.Remove(form);
            }
            var newPanels = from name in PluginManager.GetNames<IDockPane>()
                            where _dockForms.All(form => form.Name != name)
                            select name;
            foreach (string name in newPanels)
            {
                IDockPane plugin = PluginManager.Get<IDockPane>(name);
                DockForm form = new DockForm() { Name = name, Pane = plugin };
                form.Content = new DockContent() { Name = name, TabText = name };
                form.Content.Controls.Add(plugin.Control);
                form.Content.Icon = plugin.DockIcon != null
                    ? Icon.FromHandle(plugin.DockIcon.GetHicon())
                    : null;
                form.Content.DockAreas = DockAreas.Float
                    | DockAreas.DockLeft | DockAreas.DockRight
                    | DockAreas.DockTop | DockAreas.DockBottom;
                DockState state = plugin.DockHint == DockHint.Float ? DockState.Float
                    : plugin.DockHint == DockHint.Left ? DockState.DockLeft
                    : plugin.DockHint == DockHint.Right ? DockState.DockRight
                    : plugin.DockHint == DockHint.Top ? DockState.DockTop
                    : plugin.DockHint == DockHint.Bottom ? DockState.DockBottom
                    : DockState.Float;
                plugin.Control.Dock = DockStyle.Fill;
                form.Content.Show(_mainPanel, state);
                form.Content.Hide();
                _dockForms.Add(form);
            }
        }

        public bool IsVisible(IDockPane panel)
        {
            DockForm form = _dockForms.Find(x => x.Pane == panel);
            return form.Pane != null && !form.Content.IsHidden;
        }

        public void Show(IDockPane pane)
        {
            Refresh();
            DockForm form = _dockForms.Find(x => x.Pane == pane);
            if (form.Pane != null)
            {
                Control oldFocus = _mainPanel.Parent;
                while (oldFocus is ContainerControl)
                    oldFocus = ((ContainerControl)oldFocus).ActiveControl;
                form.Content.Show();
                if (oldFocus != null) oldFocus.Focus();
            }
        }

        public void Hide(IDockPane pane)
        {
            Refresh();
            DockForm form = _dockForms.Find(x => x.Pane == pane);
            if (form.Pane != null)
            {
                form.Content.Hide();
            }
        }

        public void Toggle(IDockPane pane)
        {
            DockForm form = _dockForms.Find(x => x.Pane == pane);
            if (form.Pane != null)
            {
                if (!IsVisible(form.Pane))
                    Show(pane);
                else
                    Hide(pane);
            }
        }
    }
}
