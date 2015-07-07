using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Sphere.Plugins;
using System.IO;

namespace SphereStudio.Plugins
{
    public class FontEditPlugin : IPlugin
    {
        public string Name { get { return "Font Importer"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Convert TTF fonts to .rfn for use with Sphere."; } }
        public string Version { get { return "1.2.0"; } }

        public Icon Icon { get; private set; }

        private const string _openFileFilters = "*.rfn";
        private readonly string[] _extensions = new[] { ".rfn" };

        private readonly ToolStripMenuItem _newFontItem;

        public FontEditPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.style.GetHicon());

            _newFontItem = new ToolStripMenuItem("Font", Properties.Resources.style);
            _newFontItem.Click += FontItem_Click;
        }

        private void IDE_TryEditFile(object sender, EditFileEventArgs e)
        {
            if (e.Handled) return;
            if (_extensions.Contains(e.Extension.ToLowerInvariant()))
            {
                PluginManager.Core.DockControl(OpenEditor(e.Path));
                e.Handled = true;
            }
        }

        void FontItem_Click(object sender, EventArgs e)
        {
            PluginManager.Core.DockControl(OpenEditor());
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

        public void Initialize(ISettings conf)
        {
            PluginManager.Core.RegisterOpenFileType("Sphere Fonts", _openFileFilters);
            PluginManager.Core.TryEditFile += IDE_TryEditFile;
            PluginManager.Core.AddMenuItem("File.New", _newFontItem);
        }

        public void Destroy()
        {
            PluginManager.Core.UnregisterOpenFileType(_openFileFilters);
            PluginManager.Core.TryEditFile -= IDE_TryEditFile;
        }
    }
}
