using System;
using System.Drawing;
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
        void AddMenuItem(string location, Image image, EventHandler handler);
        void RemoveMenuItem(string location, EventHandler handler);
    }
}
