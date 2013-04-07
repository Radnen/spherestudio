using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Sphere_Editor.Utility;

namespace Sphere_Editor.SubEditors
{
    public partial class TaskList : UserControl
    {
        private ImageList _imagelist = new ImageList();

        private enum View { Expanded = 0, Compacted = 1 };

        private Color _loColor = Color.FromArgb(150, 250, 150);
        private Color _medColor = Color.FromArgb(250, 250, 150);
        private Color _hiColor = Color.FromArgb(250, 150, 150);
        private Color _noColor = Color.FromArgb(255, 255, 255);

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
                if (t.Finished) return "done";
                else return "not";
            };

            string[] names = Enum.GetNames(typeof(TaskType));
            foreach (string s in names)
            {
                EventHandler eh = new EventHandler(SetType_Click);
                SetTypeItem.DropDownItems.Add(s, Properties.Resources.lightbulb, eh);
            }

            names = Enum.GetNames(typeof(TaskPriority));
            foreach (string s in names)
            {
                EventHandler eh = new EventHandler(SetPriorityItem_Click);
                SetPriorityItem.DropDownItems.Add(s, Properties.Resources.resultset_none, eh);
            }
        }

        private void AddTaskItem_Click(object sender, EventArgs e)
        {
            ObjectTaskList.AddObject(new Task("New Task"));
            TaskLabel.Text = string.Format("Tasks ({0})", ObjectTaskList.GetItemCount());
        }

        private void RemoveTaskItem_Click(object sender, EventArgs e)
        {
            if (ObjectTaskList.SelectedObject != null)
                ObjectTaskList.RemoveObject(ObjectTaskList.SelectedObject);
            TaskLabel.Text = string.Format("Tasks ({0})", ObjectTaskList.GetItemCount());
        }

        private void EditTaskItem_Click(object sender, EventArgs e)
        {
            if (ObjectTaskList.SelectedObject != null)
                ObjectTaskList.SelectedItem.BeginEdit();
        }

        private void RemoveCompletedItem_Click(object sender, EventArgs e)
        {
            foreach (Task task in ObjectTaskList.Objects)
            {
                if (task.Finished) ObjectTaskList.RemoveObject(task);
            }
            TaskLabel.Text = string.Format("Tasks ({0})", ObjectTaskList.GetItemCount());
        }

        /// <summary>
        /// Attempts to delete the tasklist file if there is nothing left.
        /// </summary>
        /// <returns>True if the file was clean, false if there is stuff to save.</returns>
        private bool Clean()
        {
            if (Global.CurrentProject == null) return true;
            if (ObjectTaskList.GetItemCount() > 0) return false;
            if (File.Exists(Global.CurrentProject.RootPath + "\\tasks.list"))
                File.Delete(Global.CurrentProject.RootPath + "\\tasks.list");
            return true;
        }

        /// <summary>
        /// Clears the list out
        /// </summary>
        public void Clear()
        {
            ObjectTaskList.ClearObjects();
            TaskLabel.Text = "Tasks (0)";
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

            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Global.CurrentProject.RootPath + "\\tasks.list")))
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

        public void LoadList()
        {
            ObjectTaskList.ClearObjects();
            if (!File.Exists(Global.CurrentProject.RootPath + "\\tasks.list")) return;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Global.CurrentProject.RootPath + "\\tasks.list")))
            {
                List<Task> tasks = new List<Task>();
                int amt = reader.ReadInt32();
                while (amt-- > 0)
                {
                    Task t = new Task();
                    t.Finished = reader.ReadBoolean();
                    t.Name = reader.ReadString();
                    t.Priority = (TaskPriority)reader.ReadInt32();
                    t.Type = (TaskType)reader.ReadInt32();
                    tasks.Add(t);
                }
                ObjectTaskList.SetObjects(tasks);
                TaskLabel.Text = string.Format("Tasks ({0})", tasks.Count);
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
            TaskLabel.Text = string.Format("Tasks ({0})", ObjectTaskList.GetItemCount());
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
            Task task = (Task)e.Model;
            if (e.ColumnIndex == olvColumn1.Index)
            {
                FontStyle style = task.Finished ? FontStyle.Strikeout : FontStyle.Regular;
                e.SubItem.Font = new Font(e.SubItem.Font, style);
            }
        }
    }
}
