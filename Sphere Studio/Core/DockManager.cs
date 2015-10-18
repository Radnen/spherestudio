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
    struct DockPaneShim
    {
        public string Name;
        public DockContent Content;
        public IDockPane Pane;
    }

    class DockManager : IDock
    {
        List<DockPaneShim> _activePanes = new List<DockPaneShim>();
        DockPanel _mainPanel;

        public DockManager(DockPanel mainPanel)
        {
            _mainPanel = mainPanel;
        }

        public void Refresh()
        {
            DockPaneShim[] removedForms = _activePanes
                .Where(x => PluginManager.Get<IDockPane>(x.Name) == null)
                .ToArray();
            foreach (DockPaneShim form in removedForms)
            {
                form.Content.Dispose();
                _activePanes.Remove(form);
            }
            var newPanels = from name in PluginManager.GetNames<IDockPane>()
                            where _activePanes.All(form => form.Name != name)
                            select name;
            foreach (string name in newPanels)
            {
                IDockPane plugin = PluginManager.Get<IDockPane>(name);
                DockPaneShim shim = new DockPaneShim() { Name = name, Pane = plugin };
                shim.Content = new DockContent() { Name = name, TabText = name };
                shim.Content.Controls.Add(plugin.Control);
                shim.Content.Icon = plugin.DockIcon != null
                    ? Icon.FromHandle(plugin.DockIcon.GetHicon())
                    : null;
                shim.Content.HideOnClose = true;
                shim.Content.DockAreas = DockAreas.Float
                    | DockAreas.DockLeft | DockAreas.DockRight
                    | DockAreas.DockTop | DockAreas.DockBottom;
                bool autoHide = Core.Settings.AutoHidePanes.Contains(name);
                DockState state = plugin.DockHint == DockHint.Float ? DockState.Float
                    : plugin.DockHint == DockHint.Left ? (autoHide ? DockState.DockLeftAutoHide : DockState.DockLeft)
                    : plugin.DockHint == DockHint.Right ? (autoHide ? DockState.DockRightAutoHide : DockState.DockRight)
                    : plugin.DockHint == DockHint.Top ? (autoHide ? DockState.DockTopAutoHide : DockState.DockTop)
                    : plugin.DockHint == DockHint.Bottom ? (autoHide ? DockState.DockBottomAutoHide : DockState.DockBottom)
                    : DockState.Float;  // this is the ugliest thing ever
                plugin.Control.Dock = DockStyle.Fill;
                shim.Content.Show(_mainPanel, state);
                if (!plugin.ShowInViewMenu || Core.Settings.HiddenPanes.Contains(name))
                    shim.Content.Hide();
                _activePanes.Add(shim);
            }
        }

        public bool IsVisible(IDockPane pane)
        {
            DockPaneShim shim = _activePanes.Find(x => x.Pane == pane);
            return shim.Pane != null && !shim.Content.IsHidden;
        }

        public void Persist()
        {
            Core.Settings.AutoHidePanes = _activePanes
                .Where(form => IsAutoHidden(form))
                .Select(form => form.Name).ToArray();
            Core.Settings.HiddenPanes = _activePanes
                .Where(x => x.Pane.ShowInViewMenu)
                .Where(x => !IsVisible(x.Pane))
                .Select(x => x.Name).ToArray();
        }

        public void Show(IDockPane pane)
        {
            Refresh();
            DockPaneShim form = _activePanes.Find(x => x.Pane == pane);
            if (form.Pane != null)
            {
                Control oldFocus = _mainPanel.Parent;
                while (oldFocus is ContainerControl)
                    oldFocus = ((ContainerControl)oldFocus).ActiveControl;
                form.Content.Show();
                if (IsAutoHidden(form))
                    _mainPanel.ActiveAutoHideContent = form.Content;
                if (oldFocus != null) oldFocus.Focus();
            }
        }

        public void Hide(IDockPane pane)
        {
            Refresh();
            DockPaneShim form = _activePanes.Find(x => x.Pane == pane);
            if (form.Pane != null)
            {
                form.Content.Hide();
            }
        }

        public void Toggle(IDockPane pane)
        {
            DockPaneShim form = _activePanes.Find(x => x.Pane == pane);
            if (form.Pane != null)
            {
                if (!IsVisible(form.Pane))
                    Show(pane);
                else
                    Hide(pane);
            }
        }

        private static bool IsAutoHidden(DockPaneShim form)
        {
            DockState state = form.Content.DockState;
            return state == DockState.DockLeftAutoHide
                || state == DockState.DockRightAutoHide
                || state == DockState.DockTopAutoHide
                || state == DockState.DockBottomAutoHide;
        }
    }
}
