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
    /// Specifies the interface for an editing plugin.
    /// </summary>
    public interface IEditorPlugin : IPlugin
    {
        /// <summary>
        /// Creates a new document view.
        /// </summary>
        DocumentView CreateEditView();

        /// <summary>
        /// Creates a new document as an IDocumentView.
        /// </summary>
        /// <returns>The IDocumentView of the new document, or null on failure.</returns>
        DocumentView NewDocument();
        
        /// <summary>
        /// Opens the specified file as an IDocumentView.
        /// </summary>
        DocumentView OpenDocument(string filepath);
    }
}
