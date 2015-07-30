using System.Drawing;

using Sphere.Plugins.Interfaces;

namespace Sphere.Plugins
{
    /// <summary>
    /// Used to implement a general plugin.
    /// </summary>
    public interface IPlugin
    {
        string Name { get; }
        string Author { get; }
        string Description { get; }
        string Version { get; }

        Icon Icon { get; }

        /// <summary>
        /// Called by the plugin manager when the plugin is loaded.
        /// </summary>
        /// <param name="conf">Allows access to the plugin's unique INI file.</param>
        void Initialize(ISettings conf);
        
        /// <summary>
        /// Called by the plugin manager when the plugin is unloaded.
        /// </summary>
        void ShutDown();
    }
}
