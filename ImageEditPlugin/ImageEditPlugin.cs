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

        #region wire up Image menu items
        private static ToolStripMenuItem _imageMenu;
        private static ToolStripMenuItem _rescaleMenuItem;
        private static ToolStripMenuItem _resizeMenuItem;
        
        static ImageEditPlugin()
        {
            _imageMenu = new ToolStripMenuItem("&Image") { Visible = false };
            _rescaleMenuItem = new ToolStripMenuItem("Re&scale...", Properties.Resources.arrow_inout, menuRescale_Click);
            _resizeMenuItem = new ToolStripMenuItem("&Resize...", Properties.Resources.arrow_inout, menuResize_Click);
            _imageMenu.DropDownItems.AddRange(new ToolStripItem[] {
                _resizeMenuItem,
                _rescaleMenuItem });
        }

        private static void menuRescale_Click(object sender, EventArgs e)
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

        private static void menuResize_Click(object sender, EventArgs e)
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
        
        internal static void ShowMenus(bool show)
        {
            _imageMenu.Visible = show;
        }

        private readonly string[] _extensions = new[] { ".bmp", ".gif", ".jpg", ".png", ".tif", ".tiff" };
        private readonly string _openFileFilters = "*.bmp;*.gif;*.jpg;*.png";

        public ImageEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.palette.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            PluginManager.RegisterExtensions(this, "png", "bmp", "gif", "jpg", "jpeg");
            PluginManager.RegisterEditor(EditorType.Image, this);
            PluginManager.IDE.AddMenuItem(_imageMenu, "Tools");
            PluginManager.IDE.RegisterNewHandler(this, "Image");
            PluginManager.IDE.RegisterOpenFileType("Images", _openFileFilters);
        }

        public void Destroy()
        {
            PluginManager.UnregisterExtensions("png", "bmp", "gif", "jpg", "jpeg");
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem(_imageMenu);
            PluginManager.UnregisterEditor(this);
        }

        public DocumentView CreateEditView()
        {
            return new ImageEditView();
        }

        public DocumentView NewDocument()
        {
            DocumentView view = new ImageEditView();
            return view.NewDocument() ? view : null;
        }

        public DocumentView OpenDocument(string filepath)
        {
            DocumentView view = new ImageEditView();
            view.Load(filepath);
            return view;
        }
    }
}
