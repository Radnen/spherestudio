
namespace Sphere.Plugins
{
    /// <summary>
    /// A simple wrapper of a plugin object, used to activate and deactivate them.
    /// </summary>
    public class PluginWrapper
    {
        /// <summary>
        /// Gets the plugin this handler handles.
        /// </summary>
        public IPlugin Plugin { get; private set; }

        /// <summary>
        /// Gets whether or not this plugin is activated.
        /// </summary>
        public bool Enabled { get; private set; }

        /// <summary>
        /// Gets the registered name of this plugin.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// A wrapper used by Sphere Studio to manage plugins.
        /// </summary>
        /// <param name="plugin"></param>
        /// <param name="name"></param>
        public PluginWrapper(IPlugin plugin, string name)
        {
            Plugin = plugin;
            Name = name;
        }

        /// <summary>
        /// Activates the plugin.
        /// </summary>
        public void Activate()
        {
            if (Enabled) return;
            Plugin.Initialize();
            Enabled = true;
        }

        /// <summary>
        /// Deactivates the plugin.
        /// </summary>
        public void Deactivate()
        {
            if (!Enabled) return;
            Plugin.Destroy();
            Enabled = false;
        }
    }
}
