using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Sphere.Core.Editor;

namespace Sphere.Plugins
{
    /// <summary>
    /// Manages Sphere Studio plugins. This is a singleton.
    /// </summary>
    public static class PluginManager
    {
        static Dictionary<EditorType, IEditorPlugin> _editors;
        static HashSet<IEditorPlugin> _wildcards;
        
        static PluginManager()
        {
            _editors = new Dictionary<EditorType, IEditorPlugin>();
            _wildcards = new HashSet<IEditorPlugin>();
        }

        /// <summary>
        /// Creates an edit control for the specified type of object.
        /// </summary>
        /// <param name="type">The type of object to be edited.</param>
        /// <returns>The new edit control, or null if no suitable plugin is available.</returns>
        public static EditorObject CreateEditControl(EditorType type)
        {
            if (_editors.Keys.Contains(type))
                return _editors[type].CreateEditControl();
            else
                return null;
        }

        /// <summary>
        /// Registers a plugin as an editor for a specified type of data.
        /// </summary>
        /// <param name="type">The data type which is to be edited.</param>
        /// <param name="editor">The plugin object which will handle editing. Must implement IEditorPlugin</param>
        public static void RegisterEditor(EditorType type, IEditorPlugin editor)
        {
            _editors[type] = editor;
        }

        /// <summary>
        /// Unregisters a previously-registered editor plugin.
        /// </summary>
        /// <param name="editor">The plugin object to unregister.</param>
        public static void UnregisterEditor(IEditorPlugin editor)
        {
            while (_editors.ContainsValue(editor)) {
                var key = _editors.Keys.FirstOrDefault(n => _editors[n] == editor);
                if (key != default(EditorType)) _editors.Remove(key);
            }
        }

        /// <summary>
        /// Gets an array of active wildcard plugins.
        /// </summary>
        /// <returns></returns>
        public static IEditorPlugin[] GetWildcards()
        {
            return _wildcards.ToArray();
        }
        
        /// <summary>
        /// Registers an editor plugin as a wildcard. Wildcards are used to open files
        /// when no other plugin claims the file type.
        /// </summary>
        /// <param name="editor">An editor plugin to register as a wildcard.</param>
        public static void RegisterWildcard(IEditorPlugin editor)
        {
            _wildcards.Add(editor);
        }

        /// <summary>
        /// Unregisters a wildcard plugin registered with RegisterWildcard().
        /// </summary>
        /// <param name="editor">The plugin to unregister.</param>
        public static void UnregisterWildcard(IEditorPlugin editor)
        {
            _wildcards.Remove(editor);
        }

        /// <summary>
        /// Gets or sets the object representing the Sphere Studio IDE.
        /// </summary>
        public static ICore Core { get; set; }
    }
}
