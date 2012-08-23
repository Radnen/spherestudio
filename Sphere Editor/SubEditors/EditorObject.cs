using System.Windows.Forms;

namespace Sphere_Editor.SubEditors
{
    public partial class EditorObject : UserControl
    {
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
    }
}
