using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace Sphere.Plugins
{
    struct PluginEntry
    {
        public IPlugin Plugin;
        public IPluginMain PluginMain;
        public string Name;

        public PluginEntry(IPluginMain main, IPlugin plugin, string name)
        {
            PluginMain = main;
            Plugin = plugin;
            Name = name;
        }
    }
    
    /// <summary>
    /// Manages Sphere Studio plugins. This is a singleton.
    /// </summary>
    public static class PluginManager
    {
        static List<PluginEntry> _plugins = new List<PluginEntry>();
        
        /// <summary>
        /// Registers a plugin. Plugins add new functionality to the IDE.
        /// </summary>
        /// <param name="main">The plugin module doing the registering.</param>
        /// <param name="plugin">The IPlugin to register.</param>
        /// <param name="name">The friendly name of the compiler, used in the UI.</param>
        public static void Register(IPluginMain main, IPlugin plugin, string name)
        {
            _plugins.Add(new PluginEntry(main, plugin, name));
        }

        /// <summary>
        /// Unregisters a previously registered plugin.
        /// </summary>
        /// <param name="plugin">The plugin to unregister.</param>
        public static void Unregister(IPlugin plugin)
        {
            _plugins.RemoveAll(x => x.Plugin == plugin);
        }
        
        /// <summary>
        /// Unregisters all plugins registered by a plugin module.
        /// </summary>
        /// <param name="main">The plugin module whose plugins are being unregistered.</param>
        public static void UnregisterAll(IPluginMain main)
        {
            _plugins.RemoveAll(x => x.PluginMain == main);
        }

        /// <summary>
        /// Gets the registered names of all active plugins of a given type.
        /// </summary>
        /// <typeparam name="T">The type of plugin to get the names of.</typeparam>
        /// <returns></returns>
        public static string[] GetNames<T>()
            where T : IPlugin
        {
            return _plugins
                .Where(x => typeof(T).IsAssignableFrom(x.Plugin.GetType()))
                .OrderBy(x => x.Name)
                .OrderBy(x => x.PluginMain == null ? 0 : 1)
                .Select(x => x.Name)
                .Distinct().ToArray();
        }

        /// <summary>
        /// Searches for a plugin by name and returns its interface.
        /// </summary>
        /// <typeparam name="T">The type of plugin being requested.</typeparam>
        /// <param name="name">The registered name of the plugin to find.</param>
        /// <returns></returns>
        public static T Get<T>(string name)
            where T : IPlugin
        {
            return (T)_plugins
                .Where(i => typeof(T).IsAssignableFrom(i.Plugin.GetType()))
                .FirstOrDefault(x => x.Name == name).Plugin;
        }

        /// <summary>
        /// Gets the interface to the Sphere Studio IDE.
        /// </summary>
        public static IIDE IDE { get; set; }
    }
}
