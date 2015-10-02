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
        static List<PluginEntry> _plugins;
        static Dictionary<string, IFileOpener> _fileOpeners;
        
        static PluginManager()
        {
            _plugins = new List<PluginEntry>();
            _fileOpeners = new Dictionary<string, IFileOpener>();
        }

        /// <summary>
        /// Registers a compiler. Compilers are used to build games.
        /// </summary>
        /// <param name="compiler">The compiler to register.</param>
        /// <param name="name">The friendly name of the compiler, used in the UI.</param>
        public static void RegisterPlugin(IPluginMain main, IPlugin plugin, string name)
        {
            _plugins.Add(new PluginEntry(main, plugin, name));
        }

        /// <summary>
        /// Unregisters a compiler.
        /// </summary>
        /// <param name="compiler"></param>
        public static void UnregisterPlugins(IPluginMain main)
        {
            _plugins.RemoveAll(i => i.PluginMain == main);
        }

        public static string[] GetPluginNames<T>()
        {
            return _plugins
                .Where(x => typeof(T).IsAssignableFrom(x.Plugin.GetType()))
                .OrderBy(x => x.Name)
                .OrderBy(x => x.PluginMain == null ? 0 : 1)
                .Select(x => x.Name)
                .Distinct().ToArray();
        }

        public static T GetPlugin<T>(string name) where T : IPlugin
        {
            return (T)_plugins
                .Where(i => typeof(T).IsAssignableFrom(i.Plugin.GetType()))
                .FirstOrDefault(i => i.Name == name).Plugin;
        }

        /// <summary>
        /// Creates an IDocumentView for a new, untitled document.
        /// </summary>
        /// <param name="extension">The file extension, sans dot, of the document to create.</param>
        /// <returns>
        /// An IDocumentView of the new document, or null if it couldn't be created for
        /// any reason.
        /// </returns>
        public static DocumentView NewDocument(string extension)
        {
            if (_fileOpeners.Keys.Contains(extension))
            {
                IFileOpener opener = _fileOpeners[extension];
                DocumentView view = opener.New();
                return view;
            }

            return null;
        }

        /// <summary>
        /// Opens a specified file as an IDocumentView.
        /// </summary>
        /// <param name="fileName">The fully qualified path to the file to open.</param>
        /// <returns>
        /// An IDocumentView of the opened document, or null if the file couldn't
        /// be opened with any active plugin.
        /// </returns>
        public static bool OpenDocument(string fileName, out DocumentView view)
        {
            view = null;
            
            string extension = Path.GetExtension(fileName);
            if (extension != "") extension = extension.Substring(1);
            if (_fileOpeners.Keys.Contains(extension))
            {
                IFileOpener opener = _fileOpeners[extension];
                view = opener.Open(fileName);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Registers a file opener to open specified file types.
        /// </summary>
        /// <param name="opener">The IFileOpener to use to open the specified types.</param>
        /// <param name="extensions">An array of file extensions to register, sans dots.</param>
        public static void RegisterExtensions(IFileOpener opener, params string[] extensions)
        {
            foreach (string ext in extensions)
            {
                _fileOpeners[ext] = opener;
            }
        }

        /// <summary>
        /// Unregisters file extensions registered with RegisterExtensions.
        /// </summary>
        /// <param name="extensions">An array of file extensions to unregister, sans dot.</param>
        public static void UnregisterExtensions(params string[] extensions)
        {
            foreach (string ext in extensions)
            {
                _fileOpeners.Remove(ext);
            }
        }

        /// <summary>
        /// Gets or sets the object representing the Sphere Studio IDE.
        /// </summary>
        public static IIDE IDE { get; set; }
    }
}
