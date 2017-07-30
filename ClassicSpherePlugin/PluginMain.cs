using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Core;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using SphereStudio.Vanilla.Plugins;
using SphereStudio.Vanilla.SettingsPages;

namespace SphereStudio.Vanilla
{
    public class PluginMain : IPluginMain
    {
        public string Name { get; } = "Classic Sphere";
        public string Description { get; } = "Provides support for classic vanilla Sphere 1.x.";
        public string Version { get; } = Versioning.Version;
        public string Author { get; } = Versioning.Author;

        public void Initialize(ISettings conf)
        {
            PluginManager.Register(this, new SphereCompiler(), "Vanilla");
            PluginManager.Register(this, new SphereStarter(conf), "Sphere 1.x");
            PluginManager.Register(this, new SettingsPage(conf), "Classic Sphere Setup");
        }

        public void ShutDown() => PluginManager.UnregisterAll(this);
    }
}
