using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Sphere.Core.Settings;

namespace Sphere.Plugins
{
    public interface IPluginHost
    {
        SphereSettings EditorSettings { get; }
        ProjectSettings CurrentGame { get; }

        event EventHandler OnOpenProject;
        event EventHandler OnCloseProject;

        void RegisterFiletype(string[] types);
        void DockControl(DockContent content, DockState state);
        void RemoveControl(string name);
        void AddMenuItem(string location, ToolStripItem item);
        void RemoveMenuItem(ToolStripItem item);
    }
}
