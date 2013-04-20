using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace ScriptPlugin
{
    public class ScriptPlugin : IPlugin
    {
        public string Name { get { return "Task List"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "A test task list."; } }
        public string Version { get { return "1.0"; } }

        public IPluginHost Host { get; set; }

        private ScriptEditor _editor;
        private DockContent _content;
        private ToolStripMenuItem _item;

        void ItemClick(object sender, EventArgs e)
        {
            if (_content.IsHidden) _content.Show();
            else _content.Hide();
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

        public void Initialize()
        {
            // Create a new instance of your custom widget, like so:
            _editor = new ScriptEditor();
            _editor.Host = Host;
            _editor.Dock = DockStyle.Fill;

            LoadFunctions();

            // Add it to a dock content like so, and style your dock content
            // however you want to!
            DockContent content = new DockContent();
            content.Text = "Task List";
            content.Controls.Add(_editor);
            content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            content.DockHandler.HideOnClose = true;
            //content.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.lightbulb.GetHicon());
            _content = content;

            // Now, we can add a menu item like so.
            // 'View' will search the 'View' menu item.
            // Once it does find it, it'll add the necessary elements.
            // You can even do paths such as 'View.Subitem.Subitem.Subitem'
            // And it'll generate the neccessary stubs before adding the item.
            //_item = new ToolStripMenuItem("Script");
            //_item.Click += new EventHandler(ItemClick);
            //Host.AddMenuItem("View", _item);
        }

        public void Destroy()
        {
            // Now we need to remove anything we add to the editor
            Host.RemoveControl("Task List");

            // And furthermore that menu item must be deleted as well!
            //_item.Click -= new EventHandler(ItemClick);
            //Host.RemoveMenuItem(_item);

            // And we can optionally null things out just to be safe:
            functions.Clear();
            _editor.Dispose(); _editor = null;
            _content.Dispose(); _content = null;
            _item.Dispose(); _item = null;
        }
    }
}
