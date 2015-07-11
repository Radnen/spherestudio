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
            PluginManager.RegisterExtensions(this, _extensions);
            PluginManager.IDE.RegisterNewHandler("Windowstyle", this);
            PluginManager.IDE.RegisterOpenFileType("Sphere Windowstyles", _openFileFilters);
        }

        public void Destroy()
        {
            PluginManager.UnregisterExtensions(_extensions);
            PluginManager.IDE.UnregisterNewHandler(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
        }

        public IDocumentView CreateEditView() { return null; }

        public IDocumentView NewDocument()
        {
            return null;
        }
        
        public IDocumentView OpenDocument(string filepath)
        {
            // TODO: update windowstyle plugin for IDocumentView
            return null;
        }

        private void IDE_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensions.Contains(e.Extension.ToLowerInvariant()))
            {
                PluginManager.IDE.DockControl(OpenEditor(e.Path));
                e.Handled = true;
            }
        }

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
