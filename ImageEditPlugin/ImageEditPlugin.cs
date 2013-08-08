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
using ImageEditPlugin.Forms;

namespace ImageEditPlugin
{
    public class ImageEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Image Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default image editor"; } }
        public string Version { get { return "1.1.6.0"; } }
        public Icon Icon { get; set; }
        
        #region IEditorPlugin implementation
        public EditorObject CreateEditControl()
        {
            return new Drawer2();
        }
        #endregion

        public ImageEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.palette.GetHicon());
            _extensions.AddRange(new[] { ".bmp", ".gif", ".jpg", ".png" });
        }

        public void Initialize()
        {
            // initialize the menu items
            _newImageMenuItem = new ToolStripMenuItem("Image", Properties.Resources.palette, _newImageMenuItem_Click);
            _imageMenu = new ToolStripMenuItem("&Image");
            _rescaleMenuItem = new ToolStripMenuItem("Re&scale...", Properties.Resources.arrow_inout, _rescaleMenuItem_Click);
            _resizeMenuItem = new ToolStripMenuItem("&Resize...", Properties.Resources.arrow_inout, _resizeMenuItem_Click);
            _imageMenu.DropDownItems.AddRange(new ToolStripItem[] {
                _resizeMenuItem,
                _rescaleMenuItem });
            
            // check everything in with the plugin manager
            PluginManager.IDE.TryEditFile += OnTryEditFile;
            PluginManager.RegisterEditor(EditorType.Image, this);
            PluginManager.IDE.AddMenuItem("File.New", _newImageMenuItem);
            PluginManager.IDE.AddMenuItem(_imageMenu, "Help");
            PluginManager.IDE.RegisterOpenFileType("Images", _openFileFilters);
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem(_newImageMenuItem);
            PluginManager.IDE.RemoveMenuItem(_imageMenu);
            PluginManager.UnregisterEditor(this);
            PluginManager.IDE.TryEditFile -= OnTryEditFile;
        }

        private readonly List<string> _extensions = new List<string>();
        private const string _openFileFilters = "*.bmp;*.gif;*.jpg;*.png";

        #region menu item declarations
        private ToolStripMenuItem _newImageMenuItem;
        private ToolStripMenuItem _imageMenu;
        private ToolStripMenuItem _rescaleMenuItem;
        private ToolStripMenuItem _resizeMenuItem;
        #endregion

        private void OnTryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensions.Contains(e.Extension.ToLowerInvariant()))
            {
                PluginManager.IDE.DockControl(OpenEditor(e.Path), DockState.Document);
                e.Handled = true;
            }
        }

        #region menu item click handlers
        private void _newImageMenuItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor(), DockState.Document);
        }

        private void _rescaleMenuItem_Click(object sender, EventArgs e)
        {
            using (SizeForm form = new SizeForm())
            {
                Drawer2 editor = PluginManager.IDE.CurrentDocument as Drawer2;
                form.WidthSize = editor.ImageWidth;
                form.HeightSize = editor.ImageHeight;
                if (form.ShowDialog() == DialogResult.OK)
                    editor.SetScale(form.WidthSize, form.HeightSize, form.Mode);
            }
        }

        private void _resizeMenuItem_Click(object sender, EventArgs e)
        {
            using (SizeForm form = new SizeForm())
            {
                Drawer2 editor = PluginManager.IDE.CurrentDocument as Drawer2;
                form.WidthSize = editor.ImageWidth;
                form.HeightSize = editor.ImageHeight;
                form.UseScale = false;
                if (form.ShowDialog() == DialogResult.OK)
                    editor.SetSize(form.WidthSize, form.HeightSize);
            }
        }
        #endregion

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
