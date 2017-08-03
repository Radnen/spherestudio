using System;
using System.Collections.Generic;
using System.Linq;

using SphereStudio.Base;

namespace SphereStudio.Base
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
        static List<PluginEntry> m_plugins = new List<PluginEntry>();
        
        /// <summary>
        /// Registers a plugin. Plugins add new functionality to the IDE.
        /// </summary>
        /// <param name="main">The plugin module doing the registering.</param>
        /// <param name="plugin">The IPlugin to register.</param>
        /// <param name="name">The friendly name of the plugin, used in the UI.</param>
        public static void Register(IPluginMain main, IPlugin plugin, string name)
        {
            if (name.Contains('|'))
                throw new ArgumentException("Registered name of plugin cannot contain pipe characters.");
            m_plugins.Add(new PluginEntry(main, plugin, name));
        }

        /// <summary>
        /// Unregisters a previously registered plugin.
        /// </summary>
        /// <param name="plugin">The plugin to unregister.</param>
        public static void Unregister(IPlugin plugin)
        {
            m_plugins.RemoveAll(x => x.Plugin == plugin);
        }
        
        /// <summary>
        /// Unregisters all plugins registered by a plugin module.
        /// </summary>
        /// <param name="main">The plugin module whose plugins are being unregistered.</param>
        public static void UnregisterAll(IPluginMain main)
        {
            m_plugins.RemoveAll(x => x.PluginMain == main);
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
            var foundPluginEntry = m_plugins
                .Where(it => it.Plugin is T)
                .FirstOrDefault(it => it.Name == name);
            return (T)foundPluginEntry.Plugin;
        }

        /// <summary>
        /// Gets the registered names of all active plugins of a given type.
        /// </summary>
        /// <typeparam name="T">The type of plugin to get the names of.</typeparam>
        /// <returns></returns>
        public static string[] GetNames<T>()
            where T : IPlugin
        {
            return m_plugins
                .Where(it => it.Plugin is T)
                .OrderBy(it => it.Name)
                .OrderBy(it => it.PluginMain == null ? 0 : 1)
                .Select(it => it.Name)
                .Distinct().ToArray();
        }

        /// <summary>
        /// Gets the interface to the Sphere Studio IDE.
        /// </summary>
        public static ICore Core { get; set; }
    }
}
