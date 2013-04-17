using System.Windows.Forms;

namespace Sphere_Editor.SubEditors
{
    public partial class EditorObject : UserControl
    {
        public string FileName { get; protected set; }

        // file maintanence:
        public virtual void Save() { }
        public virtual void SaveAs() { }
        public virtual void LoadFile(string filename) { }
        public virtual void CreateNew() { }
        public virtual void Destroy() { }
        
        // clipboard maintanence:
        public virtual void Copy() { }
        public virtual void Paste() { }
        public virtual void Cut() { }
        public virtual void SelectAll() { }

        // history maintanence:
        public virtual void Undo() { }
        public virtual void Redo() { }

        public virtual void ZoomIn() { }
        public virtual void ZoomOut() { }

        // misc:
        public ToolStripStatusLabel HelpLabel { get; set; }
        public virtual void SaveLayout() { }

        /// <summary>
        /// Gets whether or not the file has been saved.
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
