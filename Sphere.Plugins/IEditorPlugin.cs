using System.Drawing;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere.Plugins
{
    /// <summary>
    /// Used to implement a plugin that adds a custom editor control.
    /// </summary>
    public interface IEditorPlugin : IPlugin
    {
        /// <summary>
        /// Opens the editor component and returns a dock content
        /// to be added back into the Sphere Studio editor.
        /// </summary>
        /// <param name="filename">if present, it loads the file.</param>
        /// <returns></returns>
        DockContent OpenEditor(string filename);
    }
}
