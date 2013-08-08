using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Sphere.Plugins;
using MapEditPlugin.Forms;

namespace MapEditPlugin
{
    public class MapEditorPlugin : IPlugin
    {
        public string Name { get { return "Map Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default map editor"; } }
        public string Version { get { return "1.1.6.0"; } }
        public Icon Icon { get; set; }

        public MapEditorPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.MapIcon.GetHicon());
            _extensions.AddRange(new[] { ".rmp" });
            _newMapMenuItem.Click += _newMapMenuItem_Click;
        }

        public void Initialize()
        {
            // initialize the menu items
            _mapMenu = new ToolStripMenuItem("&Map");
            _exportTilesetMenuItem = new ToolStripMenuItem("E&xport Tileset...", null, _exportTilesetItem_Click);
            _importTilesetMenuItem = new ToolStripMenuItem("&Import Tileset...", null, _mapPropertiesMenuItem_Click);
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
            PluginManager.IDE.TryEditFile += OnTryEditFile;
            PluginManager.IDE.AddMenuItem("File.New", _newMapMenuItem);
            PluginManager.IDE.AddMenuItem(_mapMenu, "Help");
            PluginManager.IDE.RegisterOpenFileType("Sphere Map Files", _mapOpenFilters);
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterOpenFileType(_mapOpenFilters);
            PluginManager.IDE.RemoveMenuItem(_newMapMenuItem);
            PluginManager.IDE.RemoveMenuItem(_mapMenu);
            PluginManager.IDE.TryEditFile -= OnTryEditFile;
        }

        private readonly List<string> _extensions = new List<string>();
        private const string _mapOpenFilters = "*.rmp";

        #region menu item declarations
        private ToolStripMenuItem _newMapMenuItem = new ToolStripMenuItem("Map", Properties.Resources.MapIcon);
        private ToolStripMenuItem _mapMenu;
        private ToolStripMenuItem _exportTilesetMenuItem;
        private ToolStripMenuItem _mapPropertiesMenuItem;
        private ToolStripMenuItem _recenterMenuItem;
        private ToolStripMenuItem _importTilesetMenuItem;
        #endregion

        private void OnTryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensions.Contains(e.Extension.ToLowerInvariant())) {
                PluginManager.IDE.DockControl(OpenEditor(e.Path), DockState.Document);
                e.Handled = true;
            }
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
            PluginManager.IDE.DockControl(OpenEditor(), DockState.Document);
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

        private DockContent OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            MapEditor editor = new MapEditor() { Dock = DockStyle.Fill };

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
            DockContent content = new DockContent { Text = @"Untitled" };
            content.Controls.Add(editor);
            content.DockAreas = DockAreas.Document;
            content.Icon = Icon;

            if (!string.IsNullOrEmpty(filename)) editor.LoadFile(filename);

            return content;
        }
        #endregion
    }
}
