using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace TaskPlugin
{
    public class TaskPlugin : IPlugin
    {
        public string Name { get { return "Task List"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "An ObjectListView task list."; } }
        public string Version { get { return "1.1"; } }

        public IPluginHost Host { get; set; }
        public Icon Icon { get; private set; }

        private TaskList _list;
        private DockContent _content;
        private ToolStripMenuItem _item;

        public TaskPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.lightbulb.GetHicon());
        }

        /* Load the Task List */
        void OnProjectLoad(object sender, EventArgs e)
        {
            _list.LoadList(Host.CurrentGame.RootPath);
        }

        /* Close and empty the task List */
        void OnProjectClose(object sender, EventArgs e)
        {
            _list.SaveList();
            _list.Clear();
        }

        void ItemClick(object sender, EventArgs e)
        {
            if (_content.IsHidden) _content.Show();
            else _content.Hide();
        }

        public void Initialize()
        {
            // Create a new instance of your custom widget, like so:
            _list = new TaskList();
            _list.Dock = System.Windows.Forms.DockStyle.Fill;

            // Add it to a dock content like so, and style your dock content
            // however you want to!
            DockContent content = new DockContent();
            content.Text = "Task List";
            content.Controls.Add(_list);
            content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            content.DockHandler.HideOnClose = true;
            content.Icon = Icon;
            _content = content;

            // Add the widget to the main editor at the dock state:
            Host.DockControl(content, DockState.DockLeft);

            // Then you can add special event listeners, if you want.
            // A task list must be able to, well, load a task list, 
            // so in this case we can use these to our advantage.
            Host.OnOpenProject += new EventHandler(OnProjectLoad);
            Host.OnCloseProject += new EventHandler(OnProjectClose);

            // Now, we can add a menu item like so.
            // 'View' will search the 'View' menu item.
            // Once it does find it, it'll add the necessary elements.
            // You can even do paths such as 'View.Subitem.Subitem.Subitem'
            // And it'll generate the neccessary stubs before adding the item.
            _item = new ToolStripMenuItem("Task List", Properties.Resources.lightbulb);
            _item.Click += new EventHandler(ItemClick);
            Host.AddMenuItem("View", _item);
            
            // Here I ake sure the list is loaded when the plugin has been activated.
            _list.LoadList(Host.CurrentGame.RootPath);
        }

        public void Destroy()
        {
            // Now we need to remove anything we add to the editor
            Host.RemoveControl("Task List");

            // This is for a clean removal, we don't want the editor referencing
            // a destroyed component.
            Host.OnOpenProject -= new EventHandler(OnProjectLoad);
            Host.OnCloseProject -= new EventHandler(OnProjectClose);

            // And furthermore that menu item must be deleted as well!
            _item.Click -= new EventHandler(ItemClick);
            Host.RemoveMenuItem(_item);

            // And we can optionally null things out just to be safe:
            _list.Dispose(); _list = null;
            _content.Dispose(); _content = null;
            _item.Dispose(); _item = null;
        }
    }
}
