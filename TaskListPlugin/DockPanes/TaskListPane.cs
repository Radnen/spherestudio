using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using SphereStudio.Base;

namespace SphereStudio.Plugins.UI
{
    internal partial class TaskListPane : UserControl, IDockPane, IStyleAware
    {
        private readonly ImageList _imagelist = new ImageList();

        private readonly Color _loColor = Color.FromArgb(150, 250, 150);
        private readonly Color _medColor = Color.FromArgb(250, 250, 150);
        private readonly Color _hiColor = Color.FromArgb(250, 150, 150);
        private readonly Color _noColor = Color.FromArgb(255, 255, 255);

        private string tasksFilePath;

        public TaskListPane()
        {
            InitializeComponent();
            _imagelist.ColorDepth = ColorDepth.Depth32Bit;
            _imagelist.Images.Add("not", Properties.Resources.lightbulb);
            _imagelist.Images.Add("done", Properties.Resources.lightbulb_off);
            listView.SmallImageList = _imagelist;

            olvColumn1.ImageGetter = delegate (object rowObject)
            {
                TaskEntry t = (TaskEntry)rowObject;
                return t.IsFinished ? "done" : "not";
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

            StyleManager.AutoStyle(this);
        }

        public bool ShowInViewMenu => true;
        public Control Control => this;
        public DockHint DockHint => DockHint.Left;
        public Bitmap DockIcon => Properties.Resources.lightbulb;

        public void ApplyStyle(UIStyle style)
        {
            listView.AlternateRowBackColor = style.LabelColor;
            listView.SelectedBackColor = style.LabelColor;
            listView.SelectedForeColor = style.TextColor;
            listView.UseAlternatingBackColors = true;
            style.AsUIElement(toolbar);
            style.AsTextView(listView);
        }

        private void AddTaskItem_Click(object sender, EventArgs e)
        {
            listView.AddObject(new TaskEntry("New Task"));
        }

        private void RemoveTaskItem_Click(object sender, EventArgs e)
        {
            if (listView.SelectedObject != null)
                listView.RemoveObject(listView.SelectedObject);
        }

        private void RemoveCompletedItem_Click(object sender, EventArgs e)
        {
            List<TaskEntry> removed = listView.Objects.Cast<TaskEntry>().Where(task => task.IsFinished).ToList();
            listView.RemoveObjects(removed);
        }

        /// <summary>
        /// Attempts to delete the tasklist file if there is nothing left.
        /// </summary>
        /// <returns>True if the file was clean, false if there is stuff to save.</returns>
        private bool Clean()
        {
            if (string.IsNullOrEmpty(tasksFilePath))
                return true;
            if (listView.GetItemCount() > 0)
                return false;
            if (File.Exists(tasksFilePath))
                File.Delete(tasksFilePath);
            return true;
        }

        /// <summary>
        /// Clears the list out
        /// </summary>
        public void Clear() => listView.ClearObjects();

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
            if (Clean())
                return;

            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(tasksFilePath)))
            {
                writer.Write(listView.GetItemCount());
                foreach (TaskEntry task in listView.Objects)
                {
                    writer.Write(task.IsFinished);
                    writer.Write(task.Name);
                    writer.Write((int)task.Priority);
                    writer.Write((int)task.Type);
                }
                writer.Flush();
            }
        }

        public void LoadList(string projectRoot)
        {
            tasksFilePath = Path.Combine(projectRoot, "sphereStudio.tasks");
            listView.ClearObjects();
            if (!File.Exists(tasksFilePath))
                return;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(tasksFilePath)))
            {
                List<TaskEntry> tasks = new List<TaskEntry>();
                int amt = reader.ReadInt32();
                while (amt-- > 0)
                {
                    TaskEntry t = new TaskEntry()
                    {
                        IsFinished = reader.ReadBoolean(),
                        Name = reader.ReadString(),
                        Priority = (TaskPriority)reader.ReadInt32(),
                        Type = (TaskType)reader.ReadInt32()
                    };
                    tasks.Add(t);
                }
                listView.SetObjects(tasks);
            }
        }

        private void ClearAllItem_Click(object sender, EventArgs e) => Clear();

        private void priorityUpButton_Click(object sender, EventArgs e)
        {
            foreach (TaskEntry task in listView.SelectedObjects)
                task.IncreasePriority();

            listView.RefreshSelectedObjects();
        }

        private void priorityDownButton_Click(object sender, EventArgs e)
        {
            foreach (TaskEntry task in listView.SelectedObjects)
                task.DecreasePriority();

            listView.RefreshSelectedObjects();
        }

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            foreach (TaskEntry task in listView.SelectedObjects)
                listView.RemoveObject(task);
        }

        private void SetType_Click(object sender, EventArgs e)
        {
            foreach (TaskEntry task in listView.SelectedObjects)
            {
                int index = SetTypeItem.DropDownItems.IndexOf((ToolStripItem)sender);
                task.Type = (TaskType)index;
                listView.RefreshObject(task);
            }
        }

        private void SetPriorityItem_Click(object sender, EventArgs e)
        {
            foreach (TaskEntry task in listView.SelectedObjects)
            {
                int index = SetPriorityItem.DropDownItems.IndexOf((ToolStripItem)sender);
                task.Priority = (TaskPriority)index;
                listView.RefreshObject(task);
            }
        }

        private void ObjectTaskList_FormatRow(object sender, BrightIdeasSoftware.FormatRowEventArgs e)
        {
            TaskEntry task = (TaskEntry)e.Model;
            switch (task.Priority)
            {
                case TaskPriority.High: e.Item.BackColor = _hiColor; break;
                case TaskPriority.Low: e.Item.BackColor = _loColor; break;
                case TaskPriority.Medium: e.Item.BackColor = _medColor; break;
                case TaskPriority.None: e.Item.BackColor = _noColor; break;
            }
        }

        private void ObjectTaskList_FormatCell(object sender, BrightIdeasSoftware.FormatCellEventArgs e)
        {
            TaskEntry task = e.Model as TaskEntry;
            if (e.ColumnIndex != olvColumn1.Index || task == null) return;

            FontStyle style = task.IsFinished ? FontStyle.Strikeout : FontStyle.Regular;
            e.SubItem.Font = new Font(e.SubItem.Font, style);
        }
    }
}
