using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sphere.Core.Editor;

namespace Sphere.Plugins
{
    public static class PluginManager
    {
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

        public static void RegisterEditor(EditorType type, IEditorPlugin editor)
        {
            _editors[type] = editor;
        }

        public static void RegisterOpenFileType(string typeName, string filters)
        {
            _openFileTypes[filters] = typeName;
        }

        public static void UnregisterEditor(IEditorPlugin editor)
        {
            List<EditorType> toDelete = new List<EditorType>();
            
            foreach (EditorType key in from key in _editors.Keys where _editors[key] == editor select key)
                toDelete.Add(key);
            
            // this is roundabout, but is unfortunately necessary to prevent "collection modified
            // while enumerating" exceptions
            foreach (EditorType key in toDelete)
                _editors.Remove(key);
        }

        public static void UnregisterOpenFileType(string filters)
        {
            if (!_openFileTypes.ContainsKey(filters)) return;
            _openFileTypes.Remove(filters);
        }

        public static IDictionary<string, string> OpenFileTypes
        {
            get
            {
                return _openFileTypes;
            }
        }
        
        private static Dictionary<EditorType, IEditorPlugin> _editors = new Dictionary<EditorType, IEditorPlugin>();
        private static Dictionary<string, string> _openFileTypes = new Dictionary<string, string>();
    }
}
