using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Sphere.Plugins.Interfaces;

namespace SphereStudio.Plugins
{
    internal partial class TaskList : UserControl, IDockPanel
    {
        private readonly ImageList _imagelist = new ImageList();

        private readonly Color _loColor = Color.FromArgb(150, 250, 150);
        private readonly Color _medColor = Color.FromArgb(250, 250, 150);
        private readonly Color _hiColor = Color.FromArgb(250, 150, 150);
        private readonly Color _noColor = Color.FromArgb(255, 255, 255);

        // the location to search for a task list:
        private string RootPath { get; set; }

        public TaskList()
        {
            InitializeComponent();
            _imagelist.ColorDepth = ColorDepth.Depth32Bit;
            _imagelist.Images.Add("not", Properties.Resources.lightbulb);
            _imagelist.Images.Add("done", Properties.Resources.lightbulb_off);
            ObjectTaskList.SmallImageList = _imagelist;

            olvColumn1.ImageGetter = delegate(object rowObject)
            {
                Task t = (Task)rowObject;
                return t.Finished ? "done" : "not";
            };

            string[] names = Enum.GetNames(typeof(TaskType));
            foreach (string s in names)
            {
                EventHandler eh = SetType_Click;
                SetTypeItem.DropDownItems.Add(s, Properties.Resources.lightbulb, eh);
            }

            names = Enum.GetNames(typeof(TaskPriority));
            foreach (string s in names)
            {
                EventHandler eh = SetPriorityItem_Click;
                SetPriorityItem.DropDownItems.Add(s, Properties.Resources.resultset_none, eh);
            }
        }

        public Control Control { get { return this; } }

        public DockHint DockHint { get { return DockHint.Left; } }

        public bool ShowInViewMenu { get { return true; } }

        public Bitmap DockIcon { get { return Properties.Resources.lightbulb; } }

        private void AddTaskItem_Click(object sender, EventArgs e)
        {
            ObjectTaskList.AddObject(new Task("New Task"));
        }

        private void RemoveTaskItem_Click(object sender, EventArgs e)
        {
            if (ObjectTaskList.SelectedObject != null)
                ObjectTaskList.RemoveObject(ObjectTaskList.SelectedObject);
        }

        private void RemoveCompletedItem_Click(object sender, EventArgs e)
        {
            List<Task> removed = ObjectTaskList.Objects.Cast<Task>().Where(task => task.Finished).ToList();
            ObjectTaskList.RemoveObjects(removed);
        }

        /// <summary>
        /// Attempts to delete the tasklist file if there is nothing left.
        /// </summary>
        /// <returns>True if the file was clean, false if there is stuff to save.</returns>
        private bool Clean()
        {
            if (string.IsNullOrEmpty(RootPath)) return true;
            if (ObjectTaskList.GetItemCount() > 0) return false;
            if (File.Exists(RootPath + "\\tasks.list"))
                File.Delete(RootPath + "\\tasks.list");
            return true;
        }

        /// <summary>
        /// Clears the list out
        /// </summary>
        public void Clear()
        {
            ObjectTaskList.ClearObjects();
        }

        /// <summary>
        /// Tasks are saved as follows:
        /// int32: # of tasks
        /// for each task:
        ///   bool: checked switch;
        ///   string: name of task;
        ///   int32: ID;
        ///   int32: type;
        /// </summary>
        public void SaveList()
        {
            // clean the file
            if (Clean()) return;

            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(RootPath + "\\tasks.list")))
            {
                writer.Write(ObjectTaskList.GetItemCount());
                foreach (Task task in ObjectTaskList.Objects)
                {
                    writer.Write(task.Finished);
                    writer.Write(task.Name);
                    writer.Write((int)task.Priority);
                    writer.Write((int)task.Type);
                }
                writer.Flush();
            }
        }

        public void LoadList(string path)
        {
            RootPath = path;
            ObjectTaskList.ClearObjects();
            if (!File.Exists(path + "\\tasks.list")) return;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(RootPath + "\\tasks.list")))
            {
                List<Task> tasks = new List<Task>();
                int amt = reader.ReadInt32();
                while (amt-- > 0)
                {
                    Task t = new Task
                        {
                            Finished = reader.ReadBoolean(),
                            Name = reader.ReadString(),
                            Priority = (TaskPriority) reader.ReadInt32(),
                            Type = (TaskType) reader.ReadInt32()
                        };
                    tasks.Add(t);
                }
                ObjectTaskList.SetObjects(tasks);
            }
        }

        private void ClearAllItem_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void priorityUpButton_Click(object sender, EventArgs e)
        {
            foreach (Task task in ObjectTaskList.SelectedObjects)
                task.IncreasePriority();
            ObjectTaskList.RefreshSelectedObjects();
        }

        private void priorityDownButton_Click(object sender, EventArgs e)
        {
            foreach (Task task in ObjectTaskList.SelectedObjects)
                task.DecreasePriority();
            ObjectTaskList.RefreshSelectedObjects();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            foreach (Task task in ObjectTaskList.SelectedObjects)
                ObjectTaskList.RemoveObject(task);
        }

        private void SetType_Click(object sender, EventArgs e)
        {
            foreach (Task task in ObjectTaskList.SelectedObjects)
            {
                int index = SetTypeItem.DropDownItems.IndexOf((ToolStripItem)sender);
                task.Type = (TaskType)index;
                ObjectTaskList.RefreshObject(task);
            }
        }

        private void SetPriorityItem_Click(object sender, EventArgs e)
        {
            foreach (Task task in ObjectTaskList.SelectedObjects)
            {
                int index = SetPriorityItem.DropDownItems.IndexOf((ToolStripItem)sender);
                task.Priority = (TaskPriority)index;
                ObjectTaskList.RefreshObject(task);
            }
        }

        private void ObjectTaskList_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            Task task = (Task)e.Model;
            switch (task.Priority)
            {
                case TaskPriority.Hi: e.Item.BackColor = _hiColor; break;
                case TaskPriority.Lo: e.Item.BackColor = _loColor; break;
                case TaskPriority.Med: e.Item.BackColor = _medColor; break;
                case TaskPriority.None: e.Item.BackColor = _noColor; break;
            }
        }

        private void ObjectTaskList_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            Task task = e.Model as Task;
            if (e.ColumnIndex != olvColumn1.Index || task == null) return;

            FontStyle style = task.Finished ? FontStyle.Strikeout : FontStyle.Regular;
            e.SubItem.Font = new Font(e.SubItem.Font, style);
        }
    }
}
