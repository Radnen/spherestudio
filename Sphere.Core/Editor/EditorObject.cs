using System;
using System.Windows.Forms;

namespace Sphere.Core.Editor
{
    /// <summary>
    /// A class that opens up editor abilities.
    /// </summary>
    public class EditorObject : UserControl
    {
        /// <summary>
        /// Event handler used to attach a custom restyling callback.
        /// </summary>
        public event EventHandler OnRestyle;

        /// <summary>
        /// Invoke the restyle callback.
        /// </summary>
        public void Restyle()
        {
            if (OnRestyle != null)
                OnRestyle(this, EventArgs.Empty);
        }

        /// <summary>
        /// Gets the FileName associated with this control.
        /// </summary>
        public string FileName { get; protected set; }

        // editor stuff:

        /// <summary>
        /// Event handler; triggers when the control goes into view.
        /// </summary>
        public event EventHandler OnActivate;

        /// <summary>
        /// Event handler; triggers when control leaves view.
        /// </summary>
        public event EventHandler OnDeactivate;

        /// <summary>
        /// Event handler; triggers when tab text changes.
        /// </summary>
        public event EventHandler<string> OnTabTextChange;

        /// <summary>
        /// Occurs when entering the control on the main dock panel.
        /// </summary>
        public void Activate()
        {
            if (OnActivate != null) OnActivate(this, EventArgs.Empty);
        }

        /// <summary>
        /// Occurs when leaving the control on the main dock panel.
        /// </summary>
        public void Deactivate()
        {
            if (OnDeactivate != null) OnDeactivate(this, EventArgs.Empty);
        }

        /// <summary>
        /// Sets the tab text on the main dock panel.
        /// </summary>
        /// <param name="text">The title of this editor.</param>
        public void SetTabText(string text)
        {
            if (OnTabTextChange != null) OnTabTextChange(this, text);
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
            Parent.Text += @"*";
        }
    }
}
