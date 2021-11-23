using System;
using System.Drawing;
using System.Windows.Forms;

using SphereStudio.Base;
using SphereStudio.Plugins.Forms;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain, INewFileOpener
    {
        public string Name { get; } = "Sphere Map Editor";
        public string Description { get; } = "Sphere v1 RMP format tilemap editor";
        public string Version { get; } = Versioning.Version;
        public string Author { get; } = Versioning.Author;

        public string FileTypeName { get; private set; }
        public string[] FileExtensions { get; private set; }
        public Bitmap FileIcon { get; private set; }

        internal static void ShowMenus(bool show)
        {
            _mapMenu.Visible = show;
        }
        
        public void Initialize(ISettings conf)
        {
            FileTypeName = "RMP Tilemap";
            FileExtensions = new[] { "rmp" };
            FileIcon = Properties.Resources.MapIcon;

            PluginManager.Register(this, this, Name);
            PluginManager.Core.AddMenuItem(_mapMenu, "Tools");
        }

        public void ShutDown()
        {
            PluginManager.UnregisterAll(this);
            PluginManager.Core.RemoveMenuItem(_mapMenu);
        }

        public DocumentView New()
        {
            DocumentView view = new MapEditView();
            return view.NewDocument() ? view : null;
        }

        public DocumentView Open(string fileName)
        {
            DocumentView view = new MapEditView();
            view.Load(fileName);
            return view;
        }
        
        #region initialize the Map menu
        private static ToolStripMenuItem _mapMenu;
        private static ToolStripMenuItem _exportTilesetMenuItem;
        private static ToolStripMenuItem _mapPropertiesMenuItem;
        private static ToolStripMenuItem _recenterMenuItem;
        private static ToolStripMenuItem _importTilesetMenuItem;

        static PluginMain()
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
            MapEditView editor = PluginManager.Core.ActiveDocument as MapEditView;
            editor?.MapControl.CenterMap();
        }

        private static void menuImportTileset_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private static void menuExportTileset_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog diag = new SaveFileDialog())
            {
                diag.InitialDirectory = PluginManager.Core.Project.RootPath;
                diag.Filter = @"Image Files (.png)|*.png;";
                diag.DefaultExt = "png";

                if (diag.ShowDialog() == DialogResult.OK)
                    (PluginManager.Core.ActiveDocument as MapEditView).SaveTileset(diag.FileName);
            }
        }

        private static void menuUpdateFromFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                diag.InitialDirectory = PluginManager.Core.Project.RootPath;
                diag.Filter = @"Image Files (.png)|*.png";

                if (diag.ShowDialog() == DialogResult.OK)
                    (PluginManager.Core.ActiveDocument as MapEditView).UpdateTileset(diag.FileName);
            }
        }

        private static void menuMapProps_Click(object sender, EventArgs e)
        {
            MapEditView editor = PluginManager.Core.ActiveDocument as MapEditView;
            using (MapPropertiesForm form = new MapPropertiesForm(editor.Map))
            {
                if (form.ShowDialog() == DialogResult.OK)
                    editor.SetTileSize(editor.Map.Tileset.TileWidth, editor.Map.Tileset.TileHeight);
            }
        }
        #endregion
    }
}
