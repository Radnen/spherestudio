using System;
using System.Collections.Generic;
using System.Text;
using Sphere.Plugins;

namespace Sphere_Editor.Utility
{
    public class PluginWrapper
    {
        public IPlugin Plugin { get; private set; }
        public bool Enabled { get; private set; }

        public PluginWrapper(IPlugin plugin)
        {
            Plugin = plugin;
        }

        public void Activate()
        {
            if (Enabled) return;
            Plugin.Initialize();
            Enabled = true;
        }

        public void Deactivate()
        {
            if (!Enabled) return;
            Plugin.Destroy();
            Enabled = false;
        }
    }
}
