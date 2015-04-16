using System;
using System.Drawing;
using System.Windows.Forms;
using Sphere.Plugins;

namespace SphereStudio.Plugins
{
    public class TaskListPlugin : IPlugin
    {
        public string Name { get { return "Task List"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "Keep track of game development tasks."; } }
        public string Version { get { return "1.2.0"; } }
        public Icon Icon { get; private set; }

        private DockDescription _desc;
        private TaskList _list;
        private ToolStripMenuItem _item;

        public TaskListPlugin()
        {
            Icon = Icon.FromHandle(Properties.Resources.lightbulb.GetHicon());
        }

        /* Load the Task List */
        void IDE_LoadProject(object sender, EventArgs e)
        {
            _list.LoadList(PluginManager.IDE.CurrentGame.RootPath);
        }

        /* Close and empty the task List */
        void IDE_UnloadProject(object sender, EventArgs e)
        {
            _list.SaveList();
            _list.Clear();
        }

        void ItemClick(object sender, EventArgs e)
        {
            _desc.Toggle();
        }

        public void Initialize()
        {
            // Create a new instance of your custom widget, like so:
            _list = new TaskList { Dock = DockStyle.Fill };

            // Add it to a dock content like so, and style your dock content
            // however you want to!
            DockDescription description = new DockDescription();
            description.TabText = @"Task List";
            description.Control = _list;
            description.DockAreas = DockDescAreas.Document | DockDescAreas.Sides;
            description.DockState = DockDescStyle.Side;
            description.HideOnClose = true;
            description.Icon = Icon;
            _desc = description;

            // Add the widget to the main editor at the dock state:
            PluginManager.IDE.DockControl(description);

            // Then you can add special event listeners, if you want.
            // A task list must be able to, well, load a task list, 
            // so in this case we can use these to our advantage.
            PluginManager.IDE.LoadProject += IDE_LoadProject;
            PluginManager.IDE.UnloadProject += IDE_UnloadProject;

            // Now, we can add a menu item like so.
            // 'View' will search the 'View' menu item.
            // Once it does find it, it'll add the necessary elements.
            // You can even do paths such as 'View.Subitem.Subitem.Subitem'
            // And it'll generate the neccessary stubs before adding the item.
            _item = new ToolStripMenuItem("Task List", Properties.Resources.lightbulb);
            _item.Click += ItemClick;
            PluginManager.IDE.AddMenuItem("View", _item);

            // Here I ake sure the list is loaded when the plugin has been activated.
            if (PluginManager.IDE.CurrentGame != null) _list.LoadList(PluginManager.IDE.CurrentGame.RootPath);
        }

        public void Destroy()
        {
            // Now we need to remove anything we add to the editor
            PluginManager.IDE.RemoveControl("Task List");

            // This is for a clean removal, we don't want the editor referencing
            // a destroyed component.
            PluginManager.IDE.LoadProject -= IDE_LoadProject;
            PluginManager.IDE.UnloadProject -= IDE_UnloadProject;

            // And furthermore that menu item must be deleted as well!
            _item.Click -= ItemClick;
            PluginManager.IDE.RemoveMenuItem(_item);

            // And we can optionally null things out just to be safe:
            _list.Dispose(); _list = null;
            _item.Dispose(); _item = null;
        }
    }
}
