using System.Drawing;

using Sphere.Plugins.Interfaces;

namespace Sphere.Plugins
{
    /// <summary>
    /// Specifies the interface for a Sphere Studio plugin module.
    /// </summary>
    public interface IPluginMain
    {
        /// <summary>
        /// Gets the display name of the plugin.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the name(s) of the plugin's author(s).
        /// </summary>
        string Author { get; }

        /// <summary>
        /// Gets a one-line description of the plugin.
        /// </summary>
        string Description { get; }

        /// <summary>
        /// Gets the plugin's version number string.
        /// </summary>
        string Version { get; }

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
