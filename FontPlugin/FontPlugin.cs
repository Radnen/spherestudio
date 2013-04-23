using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace FontPlugin
{
    public class FontPlugin : IEditorPlugin
    {
        public string Name { get { return "Font Importer"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "A Sphere font importer."; } }
        public string Version { get { return "1.0"; } }

        public IPluginHost Host { get; set; }
        public Icon Icon { get; private set; }

        private ToolStripMenuItem NewFontItem, OpenFontItem;

        private string[] _filetypes = { ".rfn" };

        public FontPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.style.GetHicon());

            NewFontItem = new ToolStripMenuItem("Font", Properties.Resources.style);
            NewFontItem.Click += new EventHandler(FontItem_Click);

            OpenFontItem = new ToolStripMenuItem("Font", Properties.Resources.style);
            OpenFontItem.Click += new EventHandler(OpenFontItem_Click);
        }

        void OpenFontItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                diag.Filter = "Font Files|*.rfn";
                if (Host.CurrentGame != null)
                    diag.InitialDirectory = Host.CurrentGame.RootPath + "\\fonts";

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    Host.DockControl(OpenEditor(diag.FileName), DockState.Document);
                }
            }
        }

        void FontItem_Click(object sender, EventArgs e)
        {
            Host.DockControl(OpenEditor(), DockState.Document);
        }

        public DockContent OpenEditor(string filename = "")
        {
            // Creates a new editor instance:
            FontEditor editor = new FontEditor();
            editor.Host = Host;

            editor.Dock = DockStyle.Fill;

            // And creates + styles a dock panel:
            DockContent content = new DockContent();
            content.Text = "Font Importer";
            content.Controls.Add(editor);
            content.DockAreas = DockAreas.Document;
            content.Icon = Icon;

            if (!string.IsNullOrEmpty(filename)) editor.LoadFile(filename);

            return content;
        }

        public void Initialize()
        {
            Host.Register(_filetypes, "FontPlugin");
            Host.AddMenuItem("File.New", NewFontItem);
            Host.AddMenuItem("File.Open", OpenFontItem);
        }

        public void Destroy()
        {
            Host.Unregister(_filetypes);
        }
    }
}
