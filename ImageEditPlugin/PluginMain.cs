using System;
using System.Drawing;
using System.Windows.Forms;

using SphereStudio.Plugins.Forms;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, INewFileOpener, IEditor<ImageView>
    {
        public string Name { get { return "Image Editor"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Sphere Studio default image editor"; } }
        public string Version { get { return "1.2.0"; } }

        public string FileTypeName { get; private set; }
        public string[] FileExtensions { get; private set; }
        public Bitmap FileIcon { get; private set; }

        internal static void ShowMenus(bool show)
        {
            _imageMenu.Visible = show;
        }

        public void Initialize(ISettings conf)
        {
            FileTypeName = "Bitmap Image";
            FileExtensions = new[] { "bmp", "gif", "jpg", "png", "tif", "tiff" };
            FileIcon = Properties.Resources.palette;

            PluginManager.Register(this, this, Name);
            PluginManager.Core.AddMenuItem(_imageMenu, "Tools");
        }

        public void ShutDown()
        {
            PluginManager.Core.RemoveMenuItem(_imageMenu);
            PluginManager.UnregisterAll(this);
        }

        public ImageView CreateEditView()
        {
            return new ImageEditView();
        }

        public DocumentView New()
        {
            DocumentView view = new ImageEditView();
            return view.NewDocument() ? view : null;
        }

        public DocumentView Open(string fileName)
        {
            DocumentView view = new ImageEditView();
            view.Load(fileName);
            return view;
        }

        #region Initialize the Image menu
        private static ToolStripMenuItem _imageMenu;
        private static ToolStripMenuItem _rescaleMenuItem;
        private static ToolStripMenuItem _resizeMenuItem;

        static PluginMain()
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
                ImageEditView editor = PluginManager.Core.ActiveDocument as ImageEditView;
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
                ImageEditView editor = PluginManager.Core.ActiveDocument as ImageEditView;
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
