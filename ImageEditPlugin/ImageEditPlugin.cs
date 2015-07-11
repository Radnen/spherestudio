using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sphere.Core.Editor;
using Sphere.Plugins;
using SphereStudio.Plugins.Forms;
using System.IO;

namespace SphereStudio.Plugins
{
    public class ImageEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Image Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default image editor"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; private set; }

        private const string _openFileFilters = "*.bmp;*.gif;*.jpg;*.png";
        private readonly string[] _extensions = new[] { ".bmp", ".gif", ".jpg", ".png", ".tif", ".tiff" };

        public ImageEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.palette.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            // initialize the menu items
            _imageMenu = new ToolStripMenuItem("&Image") { Visible = false };
            _rescaleMenuItem = new ToolStripMenuItem("Re&scale...", Properties.Resources.arrow_inout, _rescaleMenuItem_Click);
            _resizeMenuItem = new ToolStripMenuItem("&Resize...", Properties.Resources.arrow_inout, _resizeMenuItem_Click);
            _imageMenu.DropDownItems.AddRange(new ToolStripItem[] {
                _resizeMenuItem,
                _rescaleMenuItem });
            
            // check everything in with the plugin manager
            PluginManager.RegisterExtensions(this, "png", "bmp", "gif", "jpg", "jpeg");
            PluginManager.RegisterEditor(EditorType.Image, this);
            PluginManager.IDE.AddMenuItem(_imageMenu, "View");
            PluginManager.IDE.RegisterNewHandler(this, "Image");
            PluginManager.IDE.RegisterOpenFileType("Images", _openFileFilters);
        }

        public void Destroy()
        {
            PluginManager.UnregisterExtensions("png", "bmp", "gif", "jpg", "jpeg");
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem("Image");
            PluginManager.UnregisterEditor(this);
        }

        public IDocumentView CreateEditView()
        {
            return new ImageEditView();
        }

        public IDocumentView NewDocument()
        {
            IDocumentView view = new ImageEditView();
            return view.NewDocument() ? view : null;
        }

        public IDocumentView OpenDocument(string filepath)
        {
            IDocumentView view = new ImageEditView();
            view.Load(filepath);
            return view;
        }

        #region menu item declarations
        private ToolStripMenuItem _imageMenu;
        private ToolStripMenuItem _rescaleMenuItem;
        private ToolStripMenuItem _resizeMenuItem;
        #endregion

        private void document_Activate(object sender, EventArgs e)
        {
        	_imageMenu.Visible = true;
        }

        private void document_Deactivate(object sender, EventArgs e)
        {
       		_imageMenu.Visible = false;
        }
        
        #region menu item click handlers
        private void _rescaleMenuItem_Click(object sender, EventArgs e)
        {
            using (SizeForm form = new SizeForm())
            {
                ImageEditView editor = PluginManager.IDE.CurrentDocument as ImageEditView;
                form.WidthSize = editor.Content.Width;
                form.HeightSize = editor.Content.Height;
                if (form.ShowDialog() == DialogResult.OK)
                    editor.Rescale(form.WidthSize, form.HeightSize, form.Mode);
            }
        }

        private void _resizeMenuItem_Click(object sender, EventArgs e)
        {
            using (SizeForm form = new SizeForm())
            {
                ImageEditView editor = PluginManager.IDE.CurrentDocument as ImageEditView;
                form.WidthSize = editor.Content.Width;
                form.HeightSize = editor.Content.Height;
                form.UseScale = false;
                if (form.ShowDialog() == DialogResult.OK)
                    editor.Resize(form.WidthSize, form.HeightSize);
            }
        }
        #endregion
    }
}
