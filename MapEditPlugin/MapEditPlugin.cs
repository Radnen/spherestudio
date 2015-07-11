using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sphere.Plugins;
using SphereStudio.Plugins.Forms;
using System.IO;

using Sphere.Core.Editor;

namespace SphereStudio.Plugins
{
    public class MapEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Map Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default map editor"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; set; }

        private const string _openFileFilters = "*.rmp";
        private readonly string[] _extensions = new[] { "rmp" };

        public MapEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.MapIcon.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            // initialize the menu items
            _mapMenu = new ToolStripMenuItem("&Map") { Visible = false };
            _exportTilesetMenuItem = new ToolStripMenuItem("E&xport Tileset...", null, _exportTilesetItem_Click);
            _importTilesetMenuItem = new ToolStripMenuItem("&Import Tileset...", null, _importTilesetMenuItem_Click);
            _mapPropertiesMenuItem = new ToolStripMenuItem("Map &Properties...", null, _mapPropertiesMenuItem_Click);
            _recenterMenuItem = new ToolStripMenuItem("Re&center Map", Properties.Resources.arrow_inout, _mapPropertiesMenuItem_Click);
            _mapMenu.DropDownItems.AddRange(new ToolStripItem[] {
                _recenterMenuItem,
                new ToolStripSeparator(),
                _exportTilesetMenuItem,
                _importTilesetMenuItem,
                new ToolStripSeparator(),
                _mapPropertiesMenuItem });
            
            // check everything in with the plugin manager
            PluginManager.IDE.AddMenuItem(_mapMenu, "View");
            PluginManager.IDE.RegisterNewHandler(this, "Map");
            PluginManager.IDE.RegisterOpenFileType("Sphere Map Files", _openFileFilters);
            PluginManager.RegisterExtensions(this, _extensions);
        }

        public void Destroy()
        {
            PluginManager.UnregisterExtensions(_extensions);
            PluginManager.IDE.UnregisterNewHandler(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem("Map");
        }

        public IDocumentView CreateEditView() { return null; }

        public IDocumentView NewDocument()
        {
            IDocumentView view = new MapEditView();
            return view.NewDocument() ? view : null;
        }

        public IDocumentView OpenDocument(string filepath)
        {
            IDocumentView view = new MapEditView();
            view.Load(filepath);
            return view;
        }

        #region menu item declarations
        private ToolStripMenuItem _mapMenu;
        private ToolStripMenuItem _exportTilesetMenuItem;
        private ToolStripMenuItem _mapPropertiesMenuItem;
        private ToolStripMenuItem _recenterMenuItem;
        private ToolStripMenuItem _importTilesetMenuItem;
        #endregion

        private void document_Activate(object sender, EventArgs e)
        {
        	_mapMenu.Visible = true;
        }

        private void document_Deactivate(object sender, EventArgs e)
        {
        	_mapMenu.Visible = false;
        }
        
        #region menu item click handlers
        private void _importTilesetMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _exportTilesetItem_Click(object sender, EventArgs e)
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

        private void _mapPropertiesMenuItem_Click(object sender, EventArgs e)
        {
            MapEditView editor = PluginManager.IDE.CurrentDocument as MapEditView;
            using (MapPropertiesForm form = new MapPropertiesForm(editor.Map))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    editor.SetTileSize(editor.Map.Tileset.TileWidth, editor.Map.Tileset.TileHeight);
            }
        }

        private void _recenterMapItem_Click(object sender, EventArgs e)
        {
            MapEditView editor = PluginManager.IDE.CurrentDocument as MapEditView;
            if (editor != null) editor.MapControl.CenterMap();
        }

        private void _updateFromFileItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                diag.InitialDirectory = PluginManager.IDE.CurrentGame.RootPath;
                diag.Filter = @"Image Files (.png)|*.png";

                if (diag.ShowDialog() == DialogResult.OK)
                    (PluginManager.IDE.CurrentDocument as MapEditView).UpdateTileset(diag.FileName);
            }
        }
        #endregion
    }
}
