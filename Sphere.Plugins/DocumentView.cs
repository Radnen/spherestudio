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
    public abstract class DocumentView : UserControl
    {
        private bool _isDirty = false;
        
        /// <summary>
        /// Gets whether the document has been edited since the last save.
        /// </summary>
        public virtual bool IsDirty
        {
            get { return _isDirty; }
            protected set
            {
                bool oldvalue = value;
                _isDirty = value;
                if (value != oldvalue && DirtyChanged != null)
                    DirtyChanged(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Gets or sets the help text shown in the status bar when this document is
        /// active. Setter is protected.
        /// </summary>
        public string HelpText { get; protected set; }

        /// <summary>
        /// Gets the recommended file extension (sans dot) when saving the document.
        /// </summary>
        public virtual string[] FileExtensions { get { return null; } }

        /// <summary>
        /// Gets the icon associated with the document.
        /// </summary>
        public Icon Icon { get; protected set; }

        /// <summary>
        /// Gets or sets the current view state of the document. (e.g. caret position,
        /// current selection, etc.)
        /// </summary>
        public virtual string ViewState { get; set; }

        /// <summary>
        /// Fires when the document's 'dirty' status changes.
        /// </summary>
        public event EventHandler DirtyChanged;

        /// <summary>
        /// Sets up the document view for a new file.
        /// </summary>
        /// <returns>true if a fresh slate was set up, false otherwise.</returns>
        public virtual bool NewDocument() { return true; }

        /// <summary>
        /// Loads a file into the document view.
        /// </summary>
        /// <param name="filename">The filename of the file to load.</param>
        public abstract new void Load(string filename);

        /// <summary>
        /// Saves the contents of the document to a specified filename.
        /// </summary>
        /// <param name="filename">The filename to save under.</param>
        public abstract void Save(string filename);
        
        /// <summary>
        /// Refreshes the document when the UI style has changed.
        /// </summary>
        public virtual void Restyle() { }

        /// <summary>
        /// Notifies the document that it received focus.
        /// </summary>
        public virtual void Activate() { }

        /// <summary>
        /// Notifies the document that it lost focus.
        /// </summary>
        public virtual void Deactivate() { }

        /// <summary>
        /// Deletes the selected content and puts it on the clipbord.
        /// </summary>
        public virtual void Cut() { }

        /// <summary>
        /// Copies the current selection to the clipboard.
        /// </summary>
        public virtual void Copy() { }

        /// <summary>
        /// Pastes the contents of the clipboard into the document.
        /// </summary>
        public virtual void Paste() { }

        /// <summary>
        /// Undoes the user's last modification to the document.
        /// </summary>
        public virtual void Undo() { }

        /// <summary>
        /// Reverts the last Undo operation. If the document has been modified since the
        /// last Undo, this does nothing.
        /// </summary>
        public virtual void Redo() { }

        /// <summary>
        /// Increases the document zoom level.
        /// </summary>
        public virtual void ZoomIn() { }

        /// <summary>
        /// Decreases the document zoom level.
        /// </summary>
        public virtual void ZoomOut() { }
    }
}
