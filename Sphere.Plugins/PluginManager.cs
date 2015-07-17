using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Sphere.Core.Editor;

namespace Sphere.Plugins
{
    /// <summary>
    /// Manages Sphere Studio plugins. This is a singleton.
    /// </summary>
    public static class PluginManager
    {
        static Dictionary<EditorType, IEditorPlugin> _embedders;
        static Dictionary<string, IEditorPlugin> _handlers;
        static HashSet<IEditorPlugin> _wildcards;
        
        static PluginManager()
        {
            _embedders = new Dictionary<EditorType, IEditorPlugin>();
            _handlers = new Dictionary<string, IEditorPlugin>();
            _wildcards = new HashSet<IEditorPlugin>();
        }

        /// <summary>
        /// Creates an edit control for the specified type of object.
        /// </summary>
        /// <param name="type">The type of object to be edited.</param>
        /// <returns>The new edit control, or null if no suitable plugin is available.</returns>
        public static DocumentView CreateEditView(EditorType type)
        {
            if (_embedders.Keys.Contains(type))
                return _embedders[type].CreateEditView();
            else
                return null;
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
            if (_handlers.Keys.Contains(extension))
            {
                IEditorPlugin plugin = _handlers[extension];
                DocumentView view = plugin.NewDocument();
                return view;
            }

            return null;
        }

        /// <summary>
        /// Opens a specified file as an IDocumentView.
        /// </summary>
        /// <param name="filename">The fully qualified path to the file to open.</param>
        /// <returns>
        /// An IDocumentView of the opened document, or null if the file couldn't
        /// be opened with any active plugin.
        /// </returns>
        public static bool OpenDocument(string filename, out DocumentView view)
        {
            view = null;
            
            string extension = Path.GetExtension(filename);
            if (extension != "") extension = extension.Substring(1);
            if (_handlers.Keys.Contains(extension))
            {
                IEditorPlugin plugin = _handlers[extension];
                view = plugin.OpenDocument(filename);
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Registers a file extension with a specified editor plugin.
        /// </summary>
        /// <param name="editor">The IEditorPlugin which will handle editing.</param>
        /// <param name="extensions">A list of file extensions to register, sans dot.</param>
        public static void RegisterExtensions(IEditorPlugin editor, params string[] extensions)
        {
            foreach (string ext in extensions)
            {
                _handlers[ext] = editor;
            }
        }

        public static void UnregisterExtensions(params string[] extensions)
        {
            foreach (string ext in extensions)
            {
                _handlers.Remove(ext);
            }
        }

        /// <summary>
        /// Registers a plugin as an editor for a specified type of data.
        /// </summary>
        /// <param name="type">The data type which is to be edited.</param>
        /// <param name="editor">The plugin object which will handle editing. Must implement IEditorPlugin</param>
        public static void RegisterEditor(EditorType type, IEditorPlugin editor)
        {
            _embedders[type] = editor;
        }

        /// <summary>
        /// Unregisters a previously-registered editor plugin.
        /// </summary>
        /// <param name="editor">The plugin object to unregister.</param>
        public static void UnregisterEditor(IEditorPlugin editor)
        {
            while (_embedders.ContainsValue(editor)) {
                var key = _embedders.Keys.FirstOrDefault(n => _embedders[n] == editor);
                if (key != default(EditorType)) _embedders.Remove(key);
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
        public static IIDE IDE { get; set; }
    }
}
