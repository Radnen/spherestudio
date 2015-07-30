using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;

using Sphere.Core.Editor;
using SphereStudio.Plugins.Forms;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    public class MapEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Map Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default map editor"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; set; }

        #region wire up Map menu items
        private static ToolStripMenuItem _mapMenu;
        private static ToolStripMenuItem _exportTilesetMenuItem;
        private static ToolStripMenuItem _mapPropertiesMenuItem;
        private static ToolStripMenuItem _recenterMenuItem;
        private static ToolStripMenuItem _importTilesetMenuItem;

        static MapEditPlugin()
        {
            _mapMenu = new ToolStripMenuItem("&Map") { Visible = false };
            _exportTilesetMenuItem = new ToolStripMenuItem("E&xport Tileset...", null, menuExportTileset_Click);
            _importTilesetMenuItem = new ToolStripMenuItem("&Import Tileset...", null, menuImportTileset_Click);
            _mapPropertiesMenuItem = new ToolStripMenuItem("Map &Properties...", null, menuMapProps_Click);
            _recenterMenuItem = new ToolStripMenuItem("Re&center Map", Properties.Resources.arrow_inout, menuMapProps_Click);
            _mapMenu.DropDownItems.AddRange(new ToolStripItem[] {
                _recenterMenuItem,
                new ToolStripSeparator(),
                _exportTilesetMenuItem,
                _importTilesetMenuItem,
                new ToolStripSeparator(),
                _mapPropertiesMenuItem });
        }
        
        private static void menuRecenter_Click(object sender, EventArgs e)
        {
            MapEditView editor = PluginManager.IDE.CurrentDocument as MapEditView;
            if (editor != null) editor.MapControl.CenterMap();
        }

        private static void menuImportTileset_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void menuExportTileset_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.InitialDirectory = PluginManager.IDE.CurrentGame.RootPath;
                diag.Filter = @"Image Files (.png)|*.png;";
                diag.DefaultExt = "png";

                if (diag.ShowDialog() == DialogResult.OK)
                    (PluginManager.IDE.CurrentDocument as MapEditView).SaveTileset(diag.FileName);
            }
        }

        private static void menuUpdateFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                diag.InitialDirectory = PluginManager.IDE.CurrentGame.RootPath;
                diag.Filter = @"Image Files (.png)|*.png";

                if (diag.ShowDialog() == DialogResult.OK)
                    (PluginManager.IDE.CurrentDocument as MapEditView).UpdateTileset(diag.FileName);
            }
        }

        private static void menuMapProps_Click(object sender, EventArgs e)
        {
            MapEditView editor = PluginManager.IDE.CurrentDocument as MapEditView;
            using (MapPropertiesForm form = new MapPropertiesForm(editor.Map))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    editor.SetTileSize(editor.Map.Tileset.TileWidth, editor.Map.Tileset.TileHeight);
            }
        }
        #endregion
        
        internal static void ShowMenus(bool show)
        {
            _mapMenu.Visible = show;
        }
        
        private readonly string[] _extensions = new[] { "rmp" };
        private readonly string _openFileFilters = "*.rmp";

        public MapEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.MapIcon.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            PluginManager.IDE.RegisterNewHandler(this, "Map");
            PluginManager.IDE.RegisterOpenFileType("Sphere Map Files", _openFileFilters);
            PluginManager.IDE.AddMenuItem(_mapMenu, "Tools");
            PluginManager.RegisterExtensions(this, _extensions);
        }

        public void ShutDown()
        {
            PluginManager.IDE.UnregisterNewHandler(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem(_mapMenu);
            PluginManager.UnregisterExtensions(_extensions);
        }

        public DocumentView CreateEditView() { return null; }

        public DocumentView NewDocument()
        {
            DocumentView view = new MapEditView();
            return view.NewDocument() ? view : null;
        }

        public DocumentView OpenDocument(string filepath)
        {
            DocumentView view = new MapEditView();
            view.Load(filepath);
            return view;
        }
    }
}
