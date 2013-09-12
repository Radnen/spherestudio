using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;
using Sphere.Plugins;

namespace SphereStudio.Plugins
{
    public class WindowstyleEditPlugin : IPlugin
    {
        public string Name { get { return "Windowstyle Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default windowstyle editor"; } }
        public string Version { get { return "1.1.6.0"; } }
        public Icon Icon { get; set; }

        public WindowstyleEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.PaletteToolIcon.GetHicon());
        }

        public void Initialize()
        {
            // initialize the menu items
            _newWindowstyleMenuItem = new ToolStripMenuItem("Windowstyle", Properties.Resources.PaletteToolIcon, _newWindowstyleMenuItem_Click);

            // check everything in with the plugin manager
            PluginManager.IDE.TryEditFile += IDE_TryEditFile;
            PluginManager.IDE.AddMenuItem("File.New", _newWindowstyleMenuItem);
            PluginManager.IDE.RegisterOpenFileType("Sphere Windowstyles", _openFileFilters);
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem(_newWindowstyleMenuItem);
            PluginManager.IDE.TryEditFile -= IDE_TryEditFile;
        }
        
        private readonly List<string> _extensionList = new List<string>(new[] { ".rws" });
        private const string _openFileFilters = "*.rws";

        #region menu item declarations
        private ToolStripMenuItem _newWindowstyleMenuItem;
        #endregion

        private void IDE_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensionList.Contains(e.Extension.ToLowerInvariant()))
            {
                PluginManager.IDE.DockControl(OpenEditor(e.Path), DockState.Document);
                e.Handled = true;
            }
        }

        #region menu item click handlers
        private void _newWindowstyleMenuItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor(), DockState.Document);
        }
        #endregion
        
        private DockContent OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            WindowstyleEditor editor = new WindowstyleEditor() { Dock = DockStyle.Fill };

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
