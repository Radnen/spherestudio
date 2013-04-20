using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere.Plugins;
using Sphere.Core;
using WeifenLuo.WinFormsUI.Docking;

namespace ScriptPlugin
{
    public class ScriptPlugin : IEditorPlugin
    {
        public string Name { get { return "Scintilla Script Editor"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "A Scintilla based script editor."; } }
        public string Version { get { return "0.1"; } }

        public IPluginHost Host { get; set; }
        public Icon Icon { get; private set; }

        private string[] _filetypes = { ".js" };

        public ScriptPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.script_edit.GetHicon());
        }

        public static List<String> functions = new List<string>();

        public static void LoadFunctions()
        {
            FileInfo file = new FileInfo(Application.StartupPath + "/docs/functions.txt");
            if (!file.Exists) return;

            using (StreamReader reader = file.OpenText())
            {
                while (!reader.EndOfStream)
                    functions.Add(reader.ReadLine());
            }
        }

        public DockContent OpenEditor(string filename)
        {
            // Creates a new editor instance:
            ScriptEditor editor = new ScriptEditor(Host);
            editor.Dock = DockStyle.Fill;

            // And creates + styles a dock panel:
            DockContent content = new DockContent();
            content.Text = "Script Editor";
            content.Controls.Add(editor);
            content.DockAreas = DockAreas.Document;
            content.Icon = Icon;

            if (!string.IsNullOrEmpty(filename)) editor.LoadFile(filename);

            return content;
        }

        public void Initialize()
        {
            LoadFunctions();
            Host.Register(_filetypes, "ScriptPlugin");
        }

        public void Destroy()
        {
            functions.Clear();
            Host.Unregister(_filetypes);
        }
    }
}
