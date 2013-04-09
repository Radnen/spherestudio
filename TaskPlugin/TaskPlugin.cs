using System;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace TaskPlugin
{
    public class TaskPlugin : IPlugin
    {
        public string Name { get { return "Task List"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "A test task list."; } }
        public string Version { get { return "1.0"; } }

        public IPluginHost Host { get; set; }

        private TaskList _list;
        private DockContent _content;

        /* Load the Task List */
        void OnProjectLoad(object sender, EventArgs e)
        {
            _list.LoadList();
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
            _list.Plugin = this;
            _list.Dock = System.Windows.Forms.DockStyle.Fill;

            // Add it to a dock content like so, and style your dock content
            // however you want to!
            DockContent content = new DockContent();
            content.Text = "Task List";
            content.Controls.Add(_list);
            content.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop | DockAreas.Document;
            content.DockHandler.HideOnClose = true;
            content.Icon = System.Drawing.Icon.FromHandle(Properties.Resources.lightbulb.GetHicon());
            _content = content;

            // Add the widget to the main editor at the dock state:
            Host.DockControl(content, DockState.DockLeft);

            // Then you can add special event listeners, if you want.
            // A task list must be able to, well, load a task list, 
            // so in this case we can use these to our advantage.
            Host.OnOpenProject += new EventHandler(OnProjectLoad);
            Host.OnCloseProject += new EventHandler(OnProjectClose);

            // Now, we can add a menu item like so.
            // View.Task List will search the 'View' menu item and try to find 'Task List'
            // Once it does find it, it'll add the necessary elements.
            // You can even do paths such as 'View.Subitem.Subitem.Subitem.My Item'
            // And it'll generate the neccessary stubs.
            Host.AddMenuItem("View.Task List", Properties.Resources.lightbulb, new EventHandler(ItemClick));
            
            // Here I ake sure the list is loaded when the plugin has been activated.
            _list.LoadList();
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
            Host.RemoveMenuItem("View.Task List", new EventHandler(ItemClick));

            // And we can optionally null things out just to be safe:
            _list = null;
            _content = null;
        }
    }
}
