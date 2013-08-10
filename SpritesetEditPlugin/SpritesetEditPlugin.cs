using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Sphere.Plugins;

namespace SpritesetEditPlugin
{
    public class SpritesetEditPlugin : IPlugin
    {
        public string Name { get { return "Spriteset Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default spriteset editor"; } }
        public string Version { get { return "1.1.6.0"; } }
        public Icon Icon { get; set; }

        public SpritesetEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.PaletteToolIcon.GetHicon());
            _extensions.AddRange(new[] { ".rss" });
        }

        public void Initialize()
        {
            // initialize the menu items
            _newSpritesetMenuItem = new ToolStripMenuItem("Spriteset", Properties.Resources.PaletteToolIcon, _newSpritesetMenuItem_Click);
            _spritesetMenu = new ToolStripMenuItem("&Spriteset") { Visible = false };
            _resizeMenuItem = new ToolStripMenuItem("&Resize...", Properties.Resources.arrow_inout, _resizeMenuItem_Click);
            _rescaleMenuItem = new ToolStripMenuItem("Re&scale...", Properties.Resources.arrow_inout, _rescaleMenuItem_Click);
            _importMenuItem = new ToolStripMenuItem("&Import...", null, _importMenuItem_Click);
            _exportMenuItem = new ToolStripMenuItem("E&xport...", null, _exportMenuItem_Click);
            _spritesetMenu.DropDownItems.AddRange(new ToolStripItem[] {
                _resizeMenuItem,
                _rescaleMenuItem,
                new ToolStripSeparator(),
                _importMenuItem,
                _exportMenuItem
            });

            // check everything in with the plugin manager
            PluginManager.IDE.TryEditFile += OnTryEditFile;
            PluginManager.IDE.AddMenuItem("File.New", _newSpritesetMenuItem);
            PluginManager.IDE.AddMenuItem(_spritesetMenu, "View");
            PluginManager.IDE.RegisterOpenFileType("Sphere Spritesets", _openFileFilters);
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem(_spritesetMenu);
            PluginManager.IDE.RemoveMenuItem(_newSpritesetMenuItem);
            PluginManager.IDE.TryEditFile -= OnTryEditFile;
        }
        
        private readonly List<string> _extensions = new List<string>();
        private const string _openFileFilters = "*.rss";

        #region menu item declarations
        private ToolStripMenuItem _newSpritesetMenuItem;
        private ToolStripMenuItem _spritesetMenu;
        private ToolStripMenuItem _exportMenuItem;
        private ToolStripMenuItem _importMenuItem;
        private ToolStripMenuItem _rescaleMenuItem;
        private ToolStripMenuItem _resizeMenuItem;
        #endregion

        private void OnTryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensions.Contains(e.Extension.ToLowerInvariant()))
            {
                PluginManager.IDE.DockControl(OpenEditor(e.Path), DockState.Document);
                e.Handled = true;
            }
        }
        
        private void document_Activate(object sender, EventArgs e)
        {
        	_spritesetMenu.Visible = true;
        }

        private void document_Deactivate(object sender, EventArgs e)
        {
        	_spritesetMenu.Visible = false;
        }
        
        #region menu item click handlers
        private void _newSpritesetMenuItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor(), DockState.Document);
        }
        
        private void _exportMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: implement spriteset export!
            throw new NotImplementedException();
        }

        private void _importMenuItem_Click(object sender, EventArgs e)
        {
            // TODO: implement spriteset import!
            throw new NotImplementedException();
        }

        private void _rescaleMenuItem_Click(object sender, EventArgs e)
        {
            (PluginManager.IDE.CurrentDocument as SpritesetEditor).RescaleAll();
        }

        private void _resizeMenuItem_Click(object sender, EventArgs e)
        {
            (PluginManager.IDE.CurrentDocument as SpritesetEditor).ResizeAll();
        }
        #endregion
        
        private DockContent OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            SpritesetEditor editor = new SpritesetEditor() { Dock = DockStyle.Fill };
            editor.OnActivate += document_Activate;
            editor.OnDeactivate += document_Deactivate;

            // if no filename provided, initialize a new document
            if (string.IsNullOrEmpty(filename)) editor.CreateNew();

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
