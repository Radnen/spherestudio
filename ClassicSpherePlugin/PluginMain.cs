using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using SphereStudio.Vanilla.Plugins;
using SphereStudio.Vanilla.SettingsPages;

namespace SphereStudio.Vanilla
{
    public class PluginMain : IPluginMain
    {
        public string Name { get; } = "Classic Sphere";
        public string Author { get; } = "Spherical";
        public string Description { get; } = "Provides support for classic vanilla Sphere 1.x.";
        public string Version { get; } = "X.X.X";

        public void Initialize(ISettings conf)
        {
            PluginManager.Register(this, new SphereCompiler(), "Vanilla");
            PluginManager.Register(this, new SphereStarter(conf), "Sphere 1.x");
            PluginManager.Register(this, new SettingsPage(conf), "Sphere 1.x Setup");
        }

        public void ShutDown() => PluginManager.UnregisterAll(this);
    }
}
