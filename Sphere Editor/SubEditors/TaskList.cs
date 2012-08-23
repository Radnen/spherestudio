using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Sphere_Editor.SubEditors
{
    public partial class TaskList : UserControl
    {
        private ImageList _imagelist = new ImageList();

        public TaskList()
        {
            InitializeComponent();
            _imagelist.ColorDepth = ColorDepth.Depth32Bit;
            _imagelist.Images.Add(Sphere_Editor.Properties.Resources.lightbulb);
            _imagelist.Images.Add(Sphere_Editor.Properties.Resources.lightbulb_off);
            TaskListView.SmallImageList = _imagelist;
        }

        public void AddTask()
        {
            ListViewItem item = new ListViewItem("New Task", 1);
            TaskListView.Items.Add(item);
            item.BeginEdit();
        }

        private void AddTaskItem_Click(object sender, EventArgs e)
        {
            AddTask();
            TaskLabel.Text = "Tasks (" + TaskListView.Items.Count + ")";
        }

        private void TaskListView_Resize(object sender, EventArgs e)
        {
            TaskListView.Columns[0].Width = TaskListView.Width;
        }

        private void TaskListView_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            if (e.Item.ImageIndex == 1)
            {
                e.Item.Font = new Font(e.Item.Font, FontStyle.Regular);
                e.Item.ImageIndex = 0;
            }
            else if (e.Item.ImageIndex == 0)
            {
                e.Item.Font = new Font(e.Item.Font, FontStyle.Strikeout);
                e.Item.ImageIndex = 1;
            }
        }

        private void RemoveTaskItem_Click(object sender, EventArgs e)
        {
            if (TaskListView.SelectedItems.Count > 0) TaskListView.SelectedItems[0].Remove();
            TaskLabel.Text = "Tasks (" + TaskListView.Items.Count + ")";
        }

        private void EditTaskItem_Click(object sender, EventArgs e)
        {
            if (TaskListView.Items.Count > 0) TaskListView.SelectedItems[0].BeginEdit();
        }

        private void RemoveCompletedItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < TaskListView.Items.Count; ++i)
            {
                if (TaskListView.Items[i].Checked)
                {
                    TaskListView.Items[i].Remove();
                    i--;
                }
            }
            TaskLabel.Text = "Tasks (" + TaskListView.Items.Count + ")";
        }

        private void TaskListMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            bool available = TaskListView.SelectedItems.Count > 0;
            RemoveTaskItem.Enabled = EditTaskItem.Enabled = available;
            RemoveCompletedItem.Enabled = TaskListView.Items.Count > 0;
        }

        /// <summary>
        /// Tasks are saved as follows:
        /// word: # of tasks
        /// for each task:
        ///   byte: checked switch;
        ///   word: # of letters in text;
        ///   text: the name of the task;
        /// </summary>
        public void SaveList()
        {
            // This had deleted the task list, but it would bug out unexpectedly
            // And delete the list even though it had valid contents inside!!!
            if (TaskListView.Items.Count == 0) return;

            using (BinaryWriter writer = new BinaryWriter(File.OpenWrite(Global.CurrentProject.Path + "\\tasks.list")))
            {
                writer.Write((short)TaskListView.Items.Count);
                foreach (ListViewItem li in TaskListView.Items)
                {
                    writer.Write(li.Checked);
                    writer.Write((short)li.Text.Length);
                    writer.Write(li.Text.ToCharArray());
                }
                writer.Flush();
            }

            TaskListView.Items.Clear();
            TaskLabel.Text = "Tasks (0)";
        }

        public void LoadList()
        {
            if (!File.Exists(Global.CurrentProject.Path + "\\tasks.list")) return;
            using (BinaryReader reader = new BinaryReader(File.OpenRead(Global.CurrentProject.Path + "\\tasks.list")))
            {
                short amt = reader.ReadInt16(), str;
                while (amt-- > 0)
                {
                    ListViewItem item = new ListViewItem("", 2);
                    item.Checked = reader.ReadBoolean();
                    if (item.Checked)
                    {
                        item.ImageIndex = 1;
                        item.Font = new Font(item.Font, FontStyle.Strikeout);
                    }
                    str = reader.ReadInt16();
                    item.Text = new string(reader.ReadChars(str));
                    TaskListView.Items.Add(item);
                }
            }
            TaskLabel.Text = "Tasks (" + TaskListView.Items.Count + ")";
        }

        private void ClearAllItem_Click(object sender, EventArgs e)
        {
            TaskListView.Items.Clear();
            TaskLabel.Text = "Tasks (0)";
        }
    }
}
