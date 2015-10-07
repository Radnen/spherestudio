﻿using System;
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
    struct DockForm
    {
        public string Name;
        public DockContent Content;
        public IDockPanel Panel;
    }

    class DockManager : IDock
    {
        List<DockForm> _dockForms = new List<DockForm>();
        DockPanel _panel;

        public DockManager(DockPanel panel)
        {
            _panel = panel;
        }

        public void Refresh()
        {
            var removed = from x in _dockForms
                          where Sphere.Plugins.PluginManager.Get<IDockPanel>(x.Name) == null
                          select x;
            foreach (DockForm form in removed)
            {
                form.Content.Dispose();
                _dockForms.Remove(form);
            }
            var newPanels = from name in Sphere.Plugins.PluginManager.GetNames<IDockPanel>()
                            where _dockForms.All(form => form.Name != name)
                            select name;
            foreach (string name in newPanels)
            {
                IDockPanel plugin = Sphere.Plugins.PluginManager.Get<IDockPanel>(name);
                DockForm form = new DockForm() { Name = name, Panel = plugin };
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
                form.Content.Show(_panel, state);
                form.Content.Hide();
                _dockForms.Add(form);
            }
        }

        public bool IsVisible(IDockPanel panel)
        {
            DockForm form = _dockForms.Find(x => x.Panel == panel);
            return form.Panel != null && form.Content.Visible;
        }

        public void Show(IDockPanel panel)
        {
            Refresh();
            DockForm form = _dockForms.Find(x => x.Panel == panel);
            if (form.Panel != null)
            {
                Control oldFocus = _panel.Parent;
                while (oldFocus is ContainerControl)
                    oldFocus = ((ContainerControl)oldFocus).ActiveControl;
                form.Content.Show();
                if (oldFocus != null) oldFocus.Focus();
            }
        }

        public void Hide(IDockPanel panel)
        {
            Refresh();
            DockForm form = _dockForms.Find(x => x.Panel == panel);
            if (form.Panel != null)
            {
                form.Content.Hide();
            }
        }

        public void Toggle(IDockPanel panel)
        {
            DockForm form = _dockForms.Find(x => x.Panel == panel);
            if (form.Content.Visible) Hide(panel); else Show(panel);
        }
    }
}
