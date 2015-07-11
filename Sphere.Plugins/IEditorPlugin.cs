using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sphere.Core.Editor;

namespace Sphere.Plugins
{
    /// <summary>
    /// Specifies the type of object supported by an editor.
    /// </summary>
    public enum EditorType
    {
        Audio,
        Image,
        Script
    }

    /// <summary>
    /// Defines a plugin that allows the user to edit something.
    /// </summary>
    public interface IEditorPlugin : IPlugin
    {
        /// <summary>
        /// Creates a new editor view.
        /// </summary>
        IDocumentView CreateEditView();
        
        /// <summary>
        /// Opens the specified file as an IDocumentView.
        /// </summary>
        bool OpenDocument(string filename, out IDocumentView view);
    }
}
