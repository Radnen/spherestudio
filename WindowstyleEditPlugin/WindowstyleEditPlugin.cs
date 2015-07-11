using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sphere.Plugins;
using System.IO;

using Sphere.Core.Editor;

namespace SphereStudio.Plugins
{
    public class WindowstyleEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Windowstyle Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Sphere Studio default windowstyle editor"; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; set; }

        private readonly string[] _extensions = new[] { "rws" };
        private const string _openFileFilters = "*.rws";

        public WindowstyleEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.PaletteToolIcon.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            // initialize the menu items
            _newWindowstyleMenuItem = new ToolStripMenuItem("Windowstyle", Properties.Resources.PaletteToolIcon, _newWindowstyleMenuItem_Click);

            // check everything in with the plugin manager
            PluginManager.RegisterExtensions(this, _extensions);
            PluginManager.IDE.RegisterOpenFileType("Sphere Windowstyles", _openFileFilters);
            PluginManager.IDE.AddMenuItem("File.New", _newWindowstyleMenuItem);
        }

        public void Destroy()
        {
            PluginManager.UnregisterExtensions(_extensions);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.IDE.RemoveMenuItem(_newWindowstyleMenuItem);
        }

        public IDocumentView CreateEditView() { return null; }

        public bool OpenDocument(string filename, out IDocumentView view)
        {
            view = null;
            return false;
        }

        #region menu item declarations
        private ToolStripMenuItem _newWindowstyleMenuItem;
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

        #region menu item click handlers
        private void _newWindowstyleMenuItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor());
        }
        #endregion
        
        private  DockDescription OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            WindowstyleEditor editor = new WindowstyleEditor() { Dock = DockStyle.Fill };

            // if no filename provided, initialize a new document
            if (string.IsNullOrEmpty(filename)) editor.CreateNew();

            // And creates + styles a dock panel:
            DockDescription description = new DockDescription();
            description.TabText = @"Untitled";
            description.Control = editor;
            description.Icon = Icon;

            if (!string.IsNullOrEmpty(filename))
            {
                editor.LoadFile(filename);
                description.TabText = Path.GetFileName(filename);
            }

            return description;
        }
   }
}
