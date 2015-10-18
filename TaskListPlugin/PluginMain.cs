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

        public void Initialize(ISettings conf)
        {
            // Create a new instance of your custom widget, like so:
            _list = new TaskList { Dock = DockStyle.Fill };

            // Register the task list as a plugin. Since TaskList implements
            // IDockPane, this also automatically adds an entry for it to the View menu.
            PluginManager.Register(this, _list, "Task List");

            // You can add special event listeners, if you want. A task list must
            // be able to, well, load a task list, so in this case we can use these
            // to our advantage.
            PluginManager.Core.LoadProject += on_LoadProject;
            PluginManager.Core.UnloadProject += on_UnloadProject;

            // Here we make sure the list is loaded when the plugin has been activated.
            if (PluginManager.Core.Project != null)
                _list.LoadList(PluginManager.Core.Project.RootPath);
        }

        public void ShutDown()
        {
            // Unregister all plugins registered by this module. We could unregister
            // them individually if we had more than one, but this is the most convenient
            // for most plugins to do on shutdown.
            PluginManager.UnregisterAll(this);
            
            // This is for a clean removal, we don't want the editor referencing
            // a destroyed component.
            PluginManager.Core.LoadProject -= on_LoadProject;
            PluginManager.Core.UnloadProject -= on_UnloadProject;

            // And we can optionally null things out just to be safe:
            _list.Dispose(); _list = null;
        }
        
        private void on_LoadProject(object sender, EventArgs e)
        {
            // User loaded a different project in the IDE, load its task list.
            _list.LoadList(PluginManager.Core.Project.RootPath);
        }

        private void on_UnloadProject(object sender, EventArgs e)
        {
            // User closed the current project, so clear the list. Make sure
            // it's saved first!
            _list.SaveList();
            _list.Clear();
        }
    }
}
