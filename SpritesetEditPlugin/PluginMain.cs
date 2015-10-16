using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, INewFileOpener
    {
        public string Name { get { return "Spriteset Editor"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Sphere Studio default spriteset editor"; } }
        public string Version { get { return "1.2.0"; } }

        public string FileTypeName { get; private set; }
        public string[] FileExtensions { get; private set; }
        public Bitmap FileIcon { get; private set; }

        internal ISettings Settings { get; private set; }

        internal static void ShowMenus(bool show)
        {
            _spritesetMenu.Visible = show;
        }
        
        public void Initialize(ISettings conf)
        {
            FileTypeName = "Sphere Spriteset";
            FileExtensions = new[] { "rss" };
            FileIcon = Properties.Resources.PersonIcon;

            Settings = conf;

            PluginManager.Register(this, this, Name);
            PluginManager.Core.AddMenuItem(_spritesetMenu, "View");
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
        }

        public DocumentView New()
        {
            SpritesetEditView view = new SpritesetEditView(this);
            return view.NewDocument() ? view : null;
        }

        public DocumentView Open(string fileName)
        {
            SpritesetEditView view = new SpritesetEditView(this);
            view.Load(fileName);
            return view;
        }

        #region initialize the Spriteset menu
        private static ToolStripMenuItem _spritesetMenu;
        private static ToolStripMenuItem _exportMenuItem;
        private static ToolStripMenuItem _importMenuItem;
        private static ToolStripMenuItem _rescaleMenuItem;
        private static ToolStripMenuItem _resizeMenuItem;

        static PluginMain()
        {
            _spritesetMenu = new ToolStripMenuItem("&Spriteset") { Visible = false };
            _resizeMenuItem = new ToolStripMenuItem("&Resize...", Properties.Resources.arrow_inout, menuResize_Click);
            _rescaleMenuItem = new ToolStripMenuItem("Re&scale...", Properties.Resources.arrow_inout, menuRescale_Click);
            _importMenuItem = new ToolStripMenuItem("&Import...", null, menuImport_Click);
            _exportMenuItem = new ToolStripMenuItem("E&xport...", null, menuExport_Click);
            _spritesetMenu.DropDownItems.AddRange(new ToolStripItem[] {
                _resizeMenuItem,
                _rescaleMenuItem,
                new ToolStripSeparator(),
                _importMenuItem,
                _exportMenuItem
            });
        }

        private static void menuExport_Click(object sender, EventArgs e)
        {
            // TODO: Implement spriteset export
            throw new NotImplementedException();
        }

        private static void menuImport_Click(object sender, EventArgs e)
        {
            // TODO: Implement spriteset import
            throw new NotImplementedException();
        }

        private static void menuRescale_Click(object sender, EventArgs e)
        {
            (PluginManager.Core.ActiveDocument as SpritesetEditView).RescaleAll();
        }

        private static void menuResize_Click(object sender, EventArgs e)
        {
            (PluginManager.Core.ActiveDocument as SpritesetEditView).ResizeAll();
        }
        #endregion
    }
}
