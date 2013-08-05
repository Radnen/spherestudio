using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Editor;
using WeifenLuo.WinFormsUI.Docking;
using Sphere.Plugins;

namespace ImageEditPlugin
{
    public class ImageEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Image Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default image editor"; } }
        public string Version { get { return "1.1.6.0"; } }
        public Icon Icon { get; set; }
        
        public IPluginHost Host { get; set; }

        #region IEditor implementation
        public EditorObject CreateEditControl()
        {
            return new Drawer2();
        }
        #endregion

        public ImageEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.palette.GetHicon());
            _extensions.AddRange(new[] { ".bmp", ".gif", ".jpg", ".png" });
            _newImageMenuItem.Click += _newImageMenuItem_Click;
        }

        public void Initialize()
        {
            PluginData.Host = Host;
            PluginManager.RegisterEditor(EditorType.Image, this);
            PluginManager.RegisterOpenFileType("Images", _openFileFilters);
            Host.AddMenuItem("File.New", _newImageMenuItem);
            Host.TryEditFile += Host_TryEditFile;
        }

        public void Destroy()
        {
            PluginManager.UnregisterEditor(this);
            Host.TryEditFile -= Host_TryEditFile;
        }

        private readonly List<string> _extensions = new List<string>();
        private const string _openFileFilters = "*.bmp;*.gif;*.jpg;*.png";
        private readonly ToolStripMenuItem _newImageMenuItem = new ToolStripMenuItem("Image", Properties.Resources.palette);
        
        private void Host_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensions.Contains(e.Extension.ToLowerInvariant()))
            {
                Host.DockControl(OpenEditor(e.Path), DockState.Document);
                e.Handled = true;
            }
        }

        private void _newImageMenuItem_Click(object sender, EventArgs e)
        {
            Host.DockControl(OpenEditor(), DockState.Document);
        }

        private DockContent OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            Drawer2 editor = new Drawer2() { Dock = DockStyle.Fill };

            // if no filename provided, initialize a new image
            if (string.IsNullOrEmpty(filename)) editor.CreateNew();

            // And creates + styles a dock panel:
            DockContent content = new DockContent { Text = @"Untitled" };
            content.Controls.Add(editor);
            content.DockAreas = DockAreas.Document;
            content.Icon = Icon;

            if (!string.IsNullOrEmpty(filename)) editor.LoadFile(filename);

            return content;
        }
    }
}
