using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class SpritesetEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Spriteset Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default spriteset editor"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; set; }

        #region wire up Spriteset menu
        private static ToolStripMenuItem _spritesetMenu;
        private static ToolStripMenuItem _exportMenuItem;
        private static ToolStripMenuItem _importMenuItem;
        private static ToolStripMenuItem _rescaleMenuItem;
        private static ToolStripMenuItem _resizeMenuItem;

        static SpritesetEditPlugin()
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
            // TODO: implement spriteset export!
            throw new NotImplementedException();
        }

        private static void menuImport_Click(object sender, EventArgs e)
        {
            // TODO: implement spriteset import!
            throw new NotImplementedException();
        }

        private static void menuRescale_Click(object sender, EventArgs e)
        {
            (PluginManager.IDE.CurrentDocument as SpritesetEditView).RescaleAll();
        }

        private static void menuResize_Click(object sender, EventArgs e)
        {
            (PluginManager.IDE.CurrentDocument as SpritesetEditView).ResizeAll();
        }
        #endregion

        internal static void ShowMenus(bool show)
        {
            _spritesetMenu.Visible = show;
        }
        
        private readonly string[] _extensions = new[] { "rss" };
        private const string _openFileFilters = "*.rss";

        public SpritesetEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.PersonIcon.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            PluginManager.RegisterExtensions(this, _extensions);
            PluginManager.IDE.RegisterNewHandler(this, "Spriteset", "spritesets");
            PluginManager.IDE.RegisterOpenFileType("Sphere Spritesets", _openFileFilters);
            PluginManager.IDE.AddMenuItem(_spritesetMenu, "View");
        }

        public void ShutDown()
        {
            PluginManager.UnregisterExtensions(_extensions);
            PluginManager.IDE.UnregisterNewHandler(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
        }

        public DocumentView CreateEditView() { return null; }

        public DocumentView NewDocument()
        {
            SpritesetEditView view = new SpritesetEditView();
            return view.NewDocument() ? view : null;
        }

        public DocumentView OpenDocument(string filepath)
        {
            SpritesetEditView view = new SpritesetEditView();
            view.Load(filepath);
            return view;
        }
    }
}
