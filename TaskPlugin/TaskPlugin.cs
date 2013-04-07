using System;
using System.Collections.Generic;
using System.Text;
using Sphere.Plugins;
using WeifenLuo.WinFormsUI.Docking;

namespace TaskPlugin
{
    public class TaskPlugin : IPlugin
    {
        public string Name { get { return "Task List"; } }
        public string Author { get { return "Radnen"; } }
        public string Description { get { return "A test task list."; } }
        public string Version { get { return "0.10"; } }

        public IPluginHost Host { get; set; }

        private TaskList _tasklist = new TaskList();

        public void OnProjectLoad()
        {
            /* Load the Task List */
        }

        public void OnProjectClose()
        {
            /* Close and empty the task List */
        }

        public object GetControl()
        {
            return _tasklist;
        }

        public void Initialize()
        {
            Host.DockControl(_tasklist, "Task List Plugin", DockAreas.DockBottom | DockAreas.Document | DockAreas.DockLeft | DockAreas.DockRight | DockAreas.DockTop, DockAlignment.Bottom);
        }

        public void Destroy()
        {
        }
    }
}
