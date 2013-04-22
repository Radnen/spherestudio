
namespace Sphere.Plugins
{
    /// <summary>
    /// A simple wrapper of a plugin object, used to activate and deactivate them.
    /// </summary>
    public class PluginWrapper
    {
        public IPlugin Plugin { get; private set; }
        public bool Enabled { get; private set; }
        public string Name { get; private set; }

        public PluginWrapper(IPlugin plugin, string name)
        {
            Plugin = plugin;
            Name = name;
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
