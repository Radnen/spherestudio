namespace Sphere_Editor.SubEditors
{
    partial class TaskList
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TaskLabel = new Sphere_Editor.EditorLabel();
            this.TaskListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveCompletedItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearAllItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskListView = new System.Windows.Forms.ListView();
            this.Task = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TaskListMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskLabel
            // 
            this.TaskLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TaskLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.TaskLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TaskLabel.Location = new System.Drawing.Point(0, 0);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(187, 23);
            this.TaskLabel.TabIndex = 0;
            this.TaskLabel.Text = "Tasks (0)";
            this.TaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TaskListMenuStrip
            // 
            this.TaskListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTaskItem,
            this.EditTaskItem,
            this.RemoveTaskItem,
            this.RemoveCompletedItem,
            this.ClearAllItem});
            this.TaskListMenuStrip.Name = "TaskListMenuStrip";
            this.TaskListMenuStrip.Size = new System.Drawing.Size(180, 114);
            this.TaskListMenuStrip.Opening += new System.ComponentModel.CancelEventHandler(this.TaskListMenuStrip_Opening);
            // 
            // AddTaskItem
            // 
            this.AddTaskItem.Name = "AddTaskItem";
            this.AddTaskItem.Size = new System.Drawing.Size(179, 22);
            this.AddTaskItem.Text = "Add Task";
            this.AddTaskItem.Click += new System.EventHandler(this.AddTaskItem_Click);
            // 
            // EditTaskItem
            // 
            this.EditTaskItem.Name = "EditTaskItem";
            this.EditTaskItem.Size = new System.Drawing.Size(179, 22);
            this.EditTaskItem.Text = "Edit Task";
            this.EditTaskItem.Click += new System.EventHandler(this.EditTaskItem_Click);
            // 
            // RemoveTaskItem
            // 
            this.RemoveTaskItem.Name = "RemoveTaskItem";
            this.RemoveTaskItem.Size = new System.Drawing.Size(179, 22);
            this.RemoveTaskItem.Text = "Remove Task";
            this.RemoveTaskItem.Click += new System.EventHandler(this.RemoveTaskItem_Click);
            // 
            // RemoveCompletedItem
            // 
            this.RemoveCompletedItem.Name = "RemoveCompletedItem";
            this.RemoveCompletedItem.Size = new System.Drawing.Size(179, 22);
            this.RemoveCompletedItem.Text = "Remove Completed";
            this.RemoveCompletedItem.Click += new System.EventHandler(this.RemoveCompletedItem_Click);
            // 
            // ClearAllItem
            // 
            this.ClearAllItem.Name = "ClearAllItem";
            this.ClearAllItem.Size = new System.Drawing.Size(179, 22);
            this.ClearAllItem.Text = "Clear All";
            this.ClearAllItem.Click += new System.EventHandler(this.ClearAllItem_Click);
            // 
            // TaskListView
            // 
            this.TaskListView.CheckBoxes = true;
            this.TaskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Task});
            this.TaskListView.ContextMenuStrip = this.TaskListMenuStrip;
            this.TaskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskListView.GridLines = true;
            this.TaskListView.LabelEdit = true;
            this.TaskListView.Location = new System.Drawing.Point(0, 23);
            this.TaskListView.Name = "TaskListView";
            this.TaskListView.Size = new System.Drawing.Size(187, 134);
            this.TaskListView.TabIndex = 2;
            this.TaskListView.UseCompatibleStateImageBehavior = false;
            this.TaskListView.View = System.Windows.Forms.View.List;
            this.TaskListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.TaskListView_ItemChecked);
            this.TaskListView.Resize += new System.EventHandler(this.TaskListView_Resize);
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TaskListView);
            this.Controls.Add(this.TaskLabel);
            this.Name = "TaskList";
            this.Size = new System.Drawing.Size(187, 157);
            this.TaskListMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private EditorLabel TaskLabel;
        private System.Windows.Forms.ContextMenuStrip TaskListMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddTaskItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveTaskItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveCompletedItem;
        private System.Windows.Forms.ToolStripMenuItem ClearAllItem;
        private System.Windows.Forms.ListView TaskListView;
        private System.Windows.Forms.ToolStripMenuItem EditTaskItem;
        private System.Windows.Forms.ColumnHeader Task;
    }
}
