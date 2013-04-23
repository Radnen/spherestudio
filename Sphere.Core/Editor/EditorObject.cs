using System;
using System.Windows.Forms;

namespace Sphere.Core
{
    /// <summary>
    /// A class that opens up editor abilities.
    /// </summary>
    public partial class EditorObject : UserControl
    {
        /// <summary>
        /// Gets the FileName associated with this control.
        /// </summary>
        public string FileName { get; protected set; }

        // editor stuff:

        public event EventHandler OnActivate;
        public event EventHandler OnDeactivate;

        public void Activate()
        {
            if (OnActivate != null) OnActivate(this, EventArgs.Empty);
        }

        public void Deactivate()
        {
            if (OnDeactivate != null) OnDeactivate(this, EventArgs.Empty);
        }

        // file maintanence:

        /// <summary>
        /// Override this to add custom saving logic.
        /// </summary>
        public virtual void Save() { }

        /// <summary>
        /// Override this to add custom save as logic.
        /// </summary>
        public virtual void SaveAs() { }

        /// <summary>
        /// Override this to add custom file loading logic.
        /// </summary>
        /// <param name="filename"></param>
        public virtual void LoadFile(string filename) { FileName = filename; }

        /// <summary>
        /// Override this to do something on new file.
        /// </summary>
        public virtual void CreateNew() { }
        
        // clipboard maintanence:

        /// <summary>
        /// Override this to add copy logic.
        /// </summary>
        public virtual void Copy() { }

        /// <summary>
        /// Override this to add paste logic.
        /// </summary>
        public virtual void Paste() { }

        /// <summary>
        /// Override this to add cut logic.
        /// </summary>
        public virtual void Cut() { }

        /// <summary>
        /// Override this to add select all logic.
        /// </summary>
        public virtual void SelectAll() { }

        // history maintanence:
        /// <summary>
        /// Override this to add undo logic.
        /// </summary>
        public virtual void Undo() { }

        /// <summary>
        /// Override this to add redo logic.
        /// </summary>
        public virtual void Redo() { }

        /// <summary>
        /// Override this to add zoom in logic.
        /// </summary>
        public virtual void ZoomIn() { }

        /// <summary>
        /// Override this to add zoom out logic.
        /// </summary>
        public virtual void ZoomOut() { }

        // misc:

        /// <summary>
        /// Gets or sets the help label associated with this control.
        /// </summary>
        public ToolStripStatusLabel HelpLabel { get; set; }

        /// <summary>
        /// Override this to save it's layout.
        /// </summary>
        public virtual void SaveLayout() { }

        /// <summary>
        /// Gets whether or not the file has a save path.
        /// </summary>
        /// <returns>True if saved, false otherwise.</returns>
        protected bool IsSaved()
        {
            return !string.IsNullOrEmpty(FileName);
        }

        /// <summary>
        /// Gets whether or not the file has been modified.
        /// </summary>
        /// <returns>True if modified, otherwise false.</returns>
        protected bool IsDirty()
        {
            return Parent.Text.EndsWith("*");
        }

        /// <summary>
        /// Marks the document as modified if it already hasn't.
        /// </summary>
        protected void MakeDirty()
        {
            if (Parent == null || Parent.Text.EndsWith("*")) return;
            Parent.Text += "*";
        }
    }
}
