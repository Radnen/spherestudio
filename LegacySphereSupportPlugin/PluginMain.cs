using SphereStudio.Base;
using SphereStudio.Plugins.Components;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain
    {
        public string Name { get; } = "Sphere 1.x Support";
        public string Description { get; } = "Provides support for Sphere 1.x, the legacy engine.";
        public string Version { get; } = Versioning.Version;
        public string Author { get; } = Versioning.Author;

        public void Initialize(ISettings conf)
        {
            PluginManager.Register(this, new SphereCompiler(), "Classic");
            PluginManager.Register(this, new SphereStarter(conf), "Sphere 1.x");
            PluginManager.Register(this, new SettingsPage(conf), "Sphere 1.x Setup");
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
        }
    }
}
