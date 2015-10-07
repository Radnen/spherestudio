using System;
using System.Drawing;
using System.Windows.Forms;

using Sphere.Plugins;
using Sphere.Plugins.Interfaces;

namespace SphereStudio.Plugins
{
    public class PluginMain : IPluginMain
    {
        public string Name { get { return "Task List"; } }
        public string Author { get { return "Spherical"; } }
        public string Description { get { return "Keep track of game development tasks."; } }
        public string Version { get { return "1.2.0"; } }

        private TaskList _list;
        private ToolStripMenuItem _item;

        public PluginMain() { }

        /* Load the Task List */
        void IDE_LoadProject(object sender, EventArgs e)
        {
            _list.LoadList(PluginManager.IDE.Project.RootPath);
        }

        /* Close and empty the task List */
        void IDE_UnloadProject(object sender, EventArgs e)
        {
            _list.SaveList();
            _list.Clear();
        }

        public void Initialize(ISettings conf)
        {
            // Create a new instance of your custom widget, like so:
            _list = new TaskList { Dock = DockStyle.Fill };

            // Register it as a dock panel.
            PluginManager.Register(this, _list, "Task List");
            PluginManager.IDE.Docking.Show(_list);

            // Then you can add special event listeners, if you want.
            // A task list must be able to, well, load a task list, 
            // so in this case we can use these to our advantage.
            PluginManager.IDE.LoadProject += IDE_LoadProject;
            PluginManager.IDE.UnloadProject += IDE_UnloadProject;

            // Here I ake sure the list is loaded when the plugin has been activated.
            if (PluginManager.IDE.Project != null) _list.LoadList(PluginManager.IDE.Project.RootPath);
        }

        public void ShutDown()
        {
            // This is for a clean removal, we don't want the editor referencing
            // a destroyed component.
            PluginManager.IDE.LoadProject -= IDE_LoadProject;
            PluginManager.IDE.UnloadProject -= IDE_UnloadProject;

            // And we can optionally null things out just to be safe:
            _list.Dispose(); _list = null;
            _item.Dispose(); _item = null;
        }
    }
}
