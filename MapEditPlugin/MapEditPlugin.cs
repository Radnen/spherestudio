using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sphere.Plugins;
using SphereStudio.Plugins.Forms;
using System.IO;

namespace SphereStudio.Plugins
{
    public class MapEditPlugin : IPlugin
    {
        public string Name { get { return "Map Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default map editor"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; set; }

        public MapEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.MapIcon.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            // initialize the menu items
            _newMapMenuItem = new ToolStripMenuItem("&Map", Properties.Resources.MapIcon, _newMapMenuItem_Click);
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
            PluginManager.IDE.TryEditFile += IDE_TryEditFile;
            PluginManager.IDE.AddMenuItem("File.New", _newMapMenuItem);
            PluginManager.IDE.AddMenuItem(_mapMenu, "View");
            PluginManager.IDE.RegisterOpenFileType("Sphere Map Files", _openFileFilters);
        }

        private void _importTilesetMenuItem_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem(_newMapMenuItem);
            PluginManager.IDE.RemoveMenuItem("Map");
            PluginManager.IDE.TryEditFile -= IDE_TryEditFile;
        }

        private const string _openFileFilters = "*.rmp";
        private readonly string[] _extensions = new[] { ".rmp" };

        #region menu item declarations
        private ToolStripMenuItem _newMapMenuItem;
        private ToolStripMenuItem _mapMenu;
        private ToolStripMenuItem _exportTilesetMenuItem;
        private ToolStripMenuItem _mapPropertiesMenuItem;
        private ToolStripMenuItem _recenterMenuItem;
        private ToolStripMenuItem _importTilesetMenuItem;
        #endregion

        private void IDE_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensions.Contains(e.Extension.ToLowerInvariant()))
            {
                PluginManager.IDE.DockControl(OpenEditor(e.Path));
                e.Handled = true;
            }
        }

        private void document_Activate(object sender, EventArgs e)
        {
        	_mapMenu.Visible = true;
        }

        private void document_Deactivate(object sender, EventArgs e)
        {
        	_mapMenu.Visible = false;
        }
        
        #region menu item click handlers
        private void _exportTilesetItem_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.InitialDirectory = PluginManager.IDE.CurrentGame.RootPath;
                diag.Filter = @"Image Files (.png)|*.png;";
                diag.DefaultExt = "png";

                if (diag.ShowDialog() == DialogResult.OK)
                    (PluginManager.IDE.CurrentDocument as MapEditor).SaveTileset(diag.FileName);
            }
        }

        private void _mapPropertiesMenuItem_Click(object sender, EventArgs e)
        {
            MapEditor editor = PluginManager.IDE.CurrentDocument as MapEditor;
            using (MapPropertiesForm form = new MapPropertiesForm(editor.Map))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    editor.SetTileSize(editor.Map.Tileset.TileWidth, editor.Map.Tileset.TileHeight);
            }
        }

        private void _newMapMenuItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor());
        }

        private void _recenterMapItem_Click(object sender, EventArgs e)
        {
            MapEditor editor = PluginManager.IDE.CurrentDocument as MapEditor;
            if (editor != null) editor.MapControl.CenterMap();
        }

        private void _updateFromFileItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                diag.InitialDirectory = PluginManager.IDE.CurrentGame.RootPath;
                diag.Filter = @"Image Files (.png)|*.png";

                if (diag.ShowDialog() == DialogResult.OK)
                    (PluginManager.IDE.CurrentDocument as MapEditor).UpdateTileset(diag.FileName);
            }
        }
        #endregion
		
        private DockDescription OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            MapEditor editor = new MapEditor() { Dock = DockStyle.Fill };
            editor.OnActivate += document_Activate;
            editor.OnDeactivate += document_Deactivate;

            // if no filename provided, initialize a new map
            if (string.IsNullOrEmpty(filename))
            {
                using (Forms.NewMapDialogue diag = new Forms.NewMapDialogue())
                {
                    if (diag.ShowDialog() == DialogResult.OK)
                    {
                        editor.CreateNew(diag.MapWidth, diag.MapHeight, diag.TileWidth, diag.TileHeight, diag.Tileset);
                    }
                    else
                    {
                        editor.Dispose();
                        return null;
                    }
                }
            }

            // And creates + styles a dock panel:
            DockDescription description = new DockDescription();
            description.TabText = @"Untitled";
            description.Control = editor;
            description.Icon = Icon;
            description.DockState = DockDescStyle.Document;

            if (!string.IsNullOrEmpty(filename))
            {
                editor.LoadFile(filename);
                description.TabText = Path.GetFileName(filename);
            }

            return description;
        }
    }
}
