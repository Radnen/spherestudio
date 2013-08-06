using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Sphere.Plugins;

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
            PluginManager.IDE.AddMenuItem("File.New", _newMapMenuItem);
            PluginManager.IDE.RegisterOpenFileType("Sphere Map Files", _mapOpenFilters);
            PluginManager.IDE.TryEditFile += Host_TryEditFile;
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterOpenFileType(_mapOpenFilters);
            PluginManager.IDE.TryEditFile -= Host_TryEditFile;
        }

        private readonly List<string> _extensions = new List<string>();
        private const string _mapOpenFilters = "*.rmp";
        private readonly ToolStripMenuItem _newMapMenuItem = new ToolStripMenuItem("Map", Properties.Resources.MapIcon);

        private void Host_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensions.Contains(e.Extension.ToLowerInvariant())) {
                PluginManager.IDE.DockControl(OpenEditor(e.Path), DockState.Document);
                e.Handled = true;
            }
        }

        private void _newMapMenuItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor(), DockState.Document);
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
    }
}
