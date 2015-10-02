using System.Drawing;

using Sphere.Plugins.Interfaces;

namespace Sphere.Plugins
{
    /// <summary>
    /// Specifies the interface for a Sphere Studio plugin module.
    /// </summary>
    public interface IPluginMain
    {
        string Name { get; }
        string Author { get; }
        string Description { get; }
        string Version { get; }

        Icon Icon { get; }

        /// <summary>
        /// Initializes the module. Called by the plugin manager when the plugin is loaded.
        /// </summary>
        /// <param name="conf">Allows access to the plugin's unique INI file.</param>
        void Initialize(ISettings conf);
        
        /// <summary>
        /// Shuts down the module. Called by the plugin manager when the plugin is unloaded.
        /// </summary>
        void ShutDown();
    }
}
