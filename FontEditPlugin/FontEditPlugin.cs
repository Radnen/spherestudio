using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sphere.Plugins;
using System.IO;

using Sphere.Core.Editor;

namespace SphereStudio.Plugins
{
    public class FontEditPlugin : IEditorPlugin
    {
        public string Name { get { return "Font Importer"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Convert TTF fonts to .rfn for use with Sphere."; } }
        public string Version { get { return "1.2.0"; } }

        public Icon Icon { get; private set; }

        private const string _openFileFilters = "*.rfn";
        private readonly string[] _extensions = new[] { "rfn" };

        public FontEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.style.GetHicon());
        }

        public void Initialize(ISettings conf)
        {
            PluginManager.RegisterExtensions(this, _extensions);
            PluginManager.IDE.RegisterNewHandler("Font", this);
            PluginManager.IDE.RegisterOpenFileType("Sphere Fonts", _openFileFilters);
        }

        public void Destroy()
        {
            PluginManager.IDE.UnregisterNewHandler(this);
            PluginManager.IDE.UnregisterOpenFileType(_openFileFilters);
            PluginManager.UnregisterExtensions(_extensions);
        }

        public IDocumentView CreateEditView() { return null; }

        public IDocumentView NewDocument()
        {
            return null;
        }
        
        public IDocumentView OpenDocument(string filename)
        {
            // TODO: update FontEditPlugin for IDocumentView
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

        void FontItem_Click(object sender, EventArgs e)
        {
            PluginManager.IDE.DockControl(OpenEditor());
        }

        public DockDescription OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            FontEditor editor = new FontEditor() { Dock = DockStyle.Fill };

            // And creates + styles a dock panel:
            DockDescription description = new DockDescription();
            description.TabText =  @"Font Importer";
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
