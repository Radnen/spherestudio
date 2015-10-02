using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain
    {
        public string Name { get { return "Sphere Classic"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Provides support for classic vanilla Sphere 1.x."; } }
        public string Version { get { return "1.2.0"; } }

        public Icon Icon { get; private set; }

        public void Initialize(ISettings conf)
        {
            PluginManager.RegisterPlugin(this, new SphereCompiler(), "Sphere Classic");
            PluginManager.RegisterPlugin(this, new SphereStarter(conf), "Sphere 1.x");
            PluginManager.RegisterPlugin(this, new SettingsPage(conf), "Sphere Classic");
        }

        public void ShutDown()
        {
            PluginManager.UnregisterPlugins(this);
        }
    }
}
