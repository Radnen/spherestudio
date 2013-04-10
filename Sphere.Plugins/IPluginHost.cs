using System;
using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere.Plugins
{
    public interface IPluginHost
    {
        string ProjectPath { get; }

        event EventHandler OnOpenProject;
        event EventHandler OnCloseProject;

        void DockControl(DockContent content, DockState state);
        void RemoveControl(string name);
        void AddMenuItem(string location, ToolStripItem item);
        void RemoveMenuItem(ToolStripItem item);
    }
}
