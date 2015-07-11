using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sphere.Plugins
{
    /// <summary>
    /// Specifies the interface for editable documents in Sphere Studio.
    /// </summary>
    public interface IDocumentView : IDisposable
    {
        /// <summary>
        /// Gets whether the document has been edited since the last save.
        /// </summary>
        bool IsDirty { get; }

        /// <summary>
        /// Gets the Windows Forms control used for the document UI.
        /// </summary>
        Control Control { get; }

        /// <summary>
        /// Gets the recommended file extension (sans dot) when saving the document.
        /// </summary>
        string[] FileExtensions { get; }

        /// <summary>
        /// Gets the icon associated with the document.
        /// </summary>
        Icon Icon { get; }

        /// <summary>
        /// Gets or sets the current view state of the document. (e.g. caret position,
        /// current selection, etc.)
        /// </summary>
        string ViewState { get; set; }

        /// <summary>
        /// Fires when the document's 'dirty' status changes.
        /// </summary>
        event EventHandler DirtyChanged;

        /// <summary>
        /// Notifies the document that it received focus.
        /// </summary>
        void Activate();

        /// <summary>
        /// Deletes the selected content and puts it on the clipbord.
        /// </summary>
        void Cut();

        /// <summary>
        /// Copies the current selection to the clipboard.
        /// </summary>
        void Copy();

        /// <summary>
        /// Pastes the contents of the clipboard into the document.
        /// </summary>
        void Paste();
        
        /// <summary>
        /// Notifies the document that it lost focus.
        /// </summary>
        void Deactivate();

        /// <summary>
        /// Sets up the document view for a new file.
        /// </summary>
        /// <returns>true if a fresh slate was set up, false otherwise.</returns>
        bool NewDocument();
        
        /// <summary>
        /// Loads a file into the document view.
        /// </summary>
        /// <param name="filename">The filename of the file to load.</param>
        void Load(string filename);

        /// <summary>
        /// Reverts the last Undo operation. If the document has been modified since the
        /// last Undo, this does nothing.
        /// </summary>
        void Redo();
        
        /// <summary>
        /// Refreshes the document when the UI style has changed.
        /// </summary>
        void Restyle();

        /// <summary>
        /// Saves the contents of the document to a specified filename.
        /// </summary>
        /// <param name="filename">The filename to save under.</param>
        void Save(string filename);
        
        /// <summary>
        /// Undoes the user's last modification to the document.
        /// </summary>
        void Undo();

        /// <summary>
        /// Increases the document zoom level.
        /// </summary>
        void ZoomIn();

        /// <summary>
        /// Decreses the document zoom level.
        /// </summary>
        void ZoomOut();
    }
}
