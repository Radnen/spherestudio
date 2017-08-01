using SphereStudio.Base;
using SphereStudio.Plugins.Components;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain
    {
        public string Name { get; } = "Legacy Support";
        public string Description { get; } = "Provides support for legacy \"vanilla\" Sphere 1.x.";
        public string Version { get; } = Versioning.Version;
        public string Author { get; } = Versioning.Author;

        public void Initialize(ISettings conf)
        {
            PluginManager.Register(this, new SphereCompiler(), "Vanilla");
            PluginManager.Register(this, new SphereStarter(conf), "Sphere 1.x");
            PluginManager.Register(this, new SettingsPage(conf), "Classic Sphere Setup");
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
        }
    }
}
