using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Sphere.Plugins
{
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        string Description { get; }
        string Version { get; }

        IPluginHost Host { get; set; }

        void OnProjectLoad();
        void OnProjectClose();

        void Initialize();
        void Destroy();
    }
}
