using System;
using System.Windows.Forms;
using Sphere.Core.Settings;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere.Plugins
{
    /// <summary>
    /// Used by a host program to implement an API the
    /// plugins use to talk to it.
    /// </summary>
    public interface IPluginHost
    {
        SphereSettings EditorSettings { get; }
        ProjectSettings CurrentGame { get; }

        event EventHandler OnOpenProject;
        event EventHandler OnCloseProject;

        void Register(string[] types, string plugin_name);
        void Unregister(string[] types);

        void DockControl(DockContent content, DockState state);
        void RemoveControl(string name);
        void AddMenuItem(string location, ToolStripItem item);
        void RemoveMenuItem(ToolStripItem item);
    }
}
