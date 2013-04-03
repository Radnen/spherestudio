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
            this.TaskListMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.AddTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveCompletedItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearAllItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TaskListView = new System.Windows.Forms.ListView();
            this.nameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priorityHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.PriorityLabel = new System.Windows.Forms.ToolStripLabel();
            this.priorityUpButton = new System.Windows.Forms.ToolStripButton();
            this.priorityDownButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.DeleteItem = new System.Windows.Forms.ToolStripButton();
            this.AddItem = new System.Windows.Forms.ToolStripButton();
            this.TaskLabel = new Sphere_Editor.EditorLabel();
            this.TaskListMenuStrip.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.nameHeader,
            this.priorityHeader});
            this.TaskListView.ContextMenuStrip = this.TaskListMenuStrip;
            this.TaskListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TaskListView.FullRowSelect = true;
            this.TaskListView.GridLines = true;
            this.TaskListView.LabelEdit = true;
            this.TaskListView.Location = new System.Drawing.Point(0, 46);
            this.TaskListView.Name = "TaskListView";
            this.TaskListView.Size = new System.Drawing.Size(358, 278);
            this.TaskListView.TabIndex = 2;
            this.TaskListView.UseCompatibleStateImageBehavior = false;
            this.TaskListView.View = System.Windows.Forms.View.Details;
            this.TaskListView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.TaskListView_ColumnClick);
            this.TaskListView.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.TaskListView_ItemChecked);
            this.TaskListView.Resize += new System.EventHandler(this.TaskListView_Resize);
            // 
            // nameHeader
            // 
            this.nameHeader.Text = "Name";
            // 
            // priorityHeader
            // 
            this.priorityHeader.Text = "Priority";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PriorityLabel,
            this.priorityUpButton,
            this.priorityDownButton,
            this.toolStripSeparator1,
            this.DeleteItem,
            this.AddItem});
            this.toolStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolStrip1.Location = new System.Drawing.Point(0, 23);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(358, 23);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // PriorityLabel
            // 
            this.PriorityLabel.Name = "PriorityLabel";
            this.PriorityLabel.Size = new System.Drawing.Size(48, 15);
            this.PriorityLabel.Text = "Priority:";
            // 
            // priorityUpButton
            // 
            this.priorityUpButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.priorityUpButton.Image = global::Sphere_Editor.Properties.Resources.resultset_up;
            this.priorityUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.priorityUpButton.Name = "priorityUpButton";
            this.priorityUpButton.Size = new System.Drawing.Size(23, 20);
            this.priorityUpButton.Text = "Priority Up";
            this.priorityUpButton.Click += new System.EventHandler(this.priorityUpButton_Click);
            // 
            // priorityDownButton
            // 
            this.priorityDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.priorityDownButton.Image = global::Sphere_Editor.Properties.Resources.resultset_down;
            this.priorityDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.priorityDownButton.Name = "priorityDownButton";
            this.priorityDownButton.Size = new System.Drawing.Size(23, 20);
            this.priorityDownButton.Text = "Priority Down";
            this.priorityDownButton.Click += new System.EventHandler(this.priorityDownButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 23);
            // 
            // DeleteItem
            // 
            this.DeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteItem.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.DeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(23, 20);
            this.DeleteItem.Text = "Remove Task(s)";
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // AddItem
            // 
            this.AddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddItem.Image = global::Sphere_Editor.Properties.Resources.add;
            this.AddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(23, 20);
            this.AddItem.Text = "Add Task";
            this.AddItem.Click += new System.EventHandler(this.AddTaskItem_Click);
            // 
            // TaskLabel
            // 
            this.TaskLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TaskLabel.Font = new System.Drawing.Font("Verdana", 10.5F);
            this.TaskLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.TaskLabel.Location = new System.Drawing.Point(0, 0);
            this.TaskLabel.Name = "TaskLabel";
            this.TaskLabel.Size = new System.Drawing.Size(358, 23);
            this.TaskLabel.TabIndex = 0;
            this.TaskLabel.Text = "Tasks (0)";
            this.TaskLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TaskList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TaskListView);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TaskLabel);
            this.Name = "TaskList";
            this.Size = new System.Drawing.Size(358, 324);
            this.TaskListMenuStrip.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.ColumnHeader nameHeader;
        private System.Windows.Forms.ColumnHeader priorityHeader;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton priorityUpButton;
        private System.Windows.Forms.ToolStripButton priorityDownButton;
        private System.Windows.Forms.ToolStripLabel PriorityLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton DeleteItem;
        private System.Windows.Forms.ToolStripButton AddItem;
    }
}
