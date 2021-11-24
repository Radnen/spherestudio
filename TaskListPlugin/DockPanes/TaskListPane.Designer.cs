namespace SphereStudio.Plugins.UI
{
    partial class TaskListPane
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
            this.Seperator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveTaskItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveCompletedItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClearAllItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Seperator2 = new System.Windows.Forms.ToolStripSeparator();
            this.SetTypeItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetPriorityItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbar = new System.Windows.Forms.ToolStrip();
            this.PriorityLabel = new System.Windows.Forms.ToolStripLabel();
            this.priorityUpButton = new System.Windows.Forms.ToolStripButton();
            this.priorityDownButton = new System.Windows.Forms.ToolStripButton();
            this.Seperator0 = new System.Windows.Forms.ToolStripSeparator();
            this.AddItem = new System.Windows.Forms.ToolStripButton();
            this.DeleteItem = new System.Windows.Forms.ToolStripButton();
            this.listView = new BrightIdeasSoftware.ObjectListView();
            this.olvColumn1 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn2 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.olvColumn3 = ((BrightIdeasSoftware.OLVColumn)(new BrightIdeasSoftware.OLVColumn()));
            this.TaskListMenuStrip.SuspendLayout();
            this.toolbar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).BeginInit();
            this.SuspendLayout();
            // 
            // TaskListMenuStrip
            // 
            this.TaskListMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddTaskItem,
            this.Seperator1,
            this.RemoveTaskItem,
            this.RemoveCompletedItem,
            this.ClearAllItem,
            this.Seperator2,
            this.SetTypeItem,
            this.SetPriorityItem});
            this.TaskListMenuStrip.Name = "TaskListMenuStrip";
            this.TaskListMenuStrip.Size = new System.Drawing.Size(180, 148);
            // 
            // AddTaskItem
            // 
            this.AddTaskItem.Image = global::SphereStudio.Plugins.Properties.Resources.lightbulb_add;
            this.AddTaskItem.Name = "AddTaskItem";
            this.AddTaskItem.Size = new System.Drawing.Size(179, 22);
            this.AddTaskItem.Text = "&Add Task";
            this.AddTaskItem.Click += new System.EventHandler(this.AddTaskItem_Click);
            // 
            // Seperator1
            // 
            this.Seperator1.Name = "Seperator1";
            this.Seperator1.Size = new System.Drawing.Size(176, 6);
            // 
            // RemoveTaskItem
            // 
            this.RemoveTaskItem.Image = global::SphereStudio.Plugins.Properties.Resources.lightbulb_delete;
            this.RemoveTaskItem.Name = "RemoveTaskItem";
            this.RemoveTaskItem.Size = new System.Drawing.Size(179, 22);
            this.RemoveTaskItem.Text = "&Remove Task";
            this.RemoveTaskItem.Click += new System.EventHandler(this.RemoveTaskItem_Click);
            // 
            // RemoveCompletedItem
            // 
            this.RemoveCompletedItem.Image = global::SphereStudio.Plugins.Properties.Resources.cross;
            this.RemoveCompletedItem.Name = "RemoveCompletedItem";
            this.RemoveCompletedItem.Size = new System.Drawing.Size(179, 22);
            this.RemoveCompletedItem.Text = "Remove &Completed";
            this.RemoveCompletedItem.Click += new System.EventHandler(this.RemoveCompletedItem_Click);
            // 
            // ClearAllItem
            // 
            this.ClearAllItem.Name = "ClearAllItem";
            this.ClearAllItem.Size = new System.Drawing.Size(179, 22);
            this.ClearAllItem.Text = "C&lear All";
            this.ClearAllItem.Click += new System.EventHandler(this.ClearAllItem_Click);
            // 
            // Seperator2
            // 
            this.Seperator2.Name = "Seperator2";
            this.Seperator2.Size = new System.Drawing.Size(176, 6);
            // 
            // SetTypeItem
            // 
            this.SetTypeItem.Image = global::SphereStudio.Plugins.Properties.Resources.information;
            this.SetTypeItem.Name = "SetTypeItem";
            this.SetTypeItem.Size = new System.Drawing.Size(179, 22);
            this.SetTypeItem.Text = "Set &Type";
            // 
            // SetPriorityItem
            // 
            this.SetPriorityItem.Image = global::SphereStudio.Plugins.Properties.Resources.resultset_none;
            this.SetPriorityItem.Name = "SetPriorityItem";
            this.SetPriorityItem.Size = new System.Drawing.Size(179, 22);
            this.SetPriorityItem.Text = "Set &Priority";
            // 
            // toolbar
            // 
            this.toolbar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PriorityLabel,
            this.priorityUpButton,
            this.priorityDownButton,
            this.Seperator0,
            this.AddItem,
            this.DeleteItem});
            this.toolbar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.toolbar.Location = new System.Drawing.Point(0, 0);
            this.toolbar.Name = "toolbar";
            this.toolbar.Size = new System.Drawing.Size(358, 23);
            this.toolbar.TabIndex = 3;
            this.toolbar.Text = "toolStrip1";
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
            this.priorityUpButton.Image = global::SphereStudio.Plugins.Properties.Resources.resultset_up;
            this.priorityUpButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.priorityUpButton.Name = "priorityUpButton";
            this.priorityUpButton.Size = new System.Drawing.Size(23, 20);
            this.priorityUpButton.Text = "Priority Up";
            this.priorityUpButton.Click += new System.EventHandler(this.priorityUpButton_Click);
            // 
            // priorityDownButton
            // 
            this.priorityDownButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.priorityDownButton.Image = global::SphereStudio.Plugins.Properties.Resources.resultset_down;
            this.priorityDownButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.priorityDownButton.Name = "priorityDownButton";
            this.priorityDownButton.Size = new System.Drawing.Size(23, 20);
            this.priorityDownButton.Text = "Priority Down";
            this.priorityDownButton.Click += new System.EventHandler(this.priorityDownButton_Click);
            // 
            // Seperator0
            // 
            this.Seperator0.Name = "Seperator0";
            this.Seperator0.Size = new System.Drawing.Size(6, 23);
            // 
            // AddItem
            // 
            this.AddItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddItem.Image = global::SphereStudio.Plugins.Properties.Resources.lightbulb_add;
            this.AddItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddItem.Name = "AddItem";
            this.AddItem.Size = new System.Drawing.Size(23, 20);
            this.AddItem.Text = "Add Task";
            this.AddItem.Click += new System.EventHandler(this.AddTaskItem_Click);
            // 
            // DeleteItem
            // 
            this.DeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.DeleteItem.Image = global::SphereStudio.Plugins.Properties.Resources.lightbulb_delete;
            this.DeleteItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteItem.Name = "DeleteItem";
            this.DeleteItem.Size = new System.Drawing.Size(23, 20);
            this.DeleteItem.Text = "Remove Task(s)";
            this.DeleteItem.Click += new System.EventHandler(this.DeleteItem_Click);
            // 
            // listView
            // 
            this.listView.AllColumns.Add(this.olvColumn1);
            this.listView.AllColumns.Add(this.olvColumn2);
            this.listView.AllColumns.Add(this.olvColumn3);
            this.listView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.listView.CellEditActivation = BrightIdeasSoftware.ObjectListView.CellEditActivateMode.DoubleClick;
            this.listView.CellEditUseWholeCell = false;
            this.listView.CheckBoxes = true;
            this.listView.CheckedAspectName = "Finished";
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.olvColumn1,
            this.olvColumn2,
            this.olvColumn3});
            this.listView.ContextMenuStrip = this.TaskListMenuStrip;
            this.listView.Cursor = System.Windows.Forms.Cursors.Default;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.EmptyListMsg = "no tasks";
            this.listView.FullRowSelect = true;
            this.listView.GroupWithItemCountFormat = "";
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 23);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(358, 301);
            this.listView.TabIndex = 4;
            this.listView.UseAlternatingBackColors = true;
            this.listView.UseCellFormatEvents = true;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.FormatCell += new System.EventHandler<BrightIdeasSoftware.FormatCellEventArgs>(this.ObjectTaskList_FormatCell);
            this.listView.FormatRow += new System.EventHandler<BrightIdeasSoftware.FormatRowEventArgs>(this.ObjectTaskList_FormatRow);
            // 
            // olvColumn1
            // 
            this.olvColumn1.AspectName = "Name";
            this.olvColumn1.Text = "Name";
            this.olvColumn1.UseInitialLetterForGroup = true;
            this.olvColumn1.Width = 200;
            // 
            // olvColumn2
            // 
            this.olvColumn2.AspectName = "Priority";
            this.olvColumn2.Text = "Priority";
            this.olvColumn2.Width = 50;
            // 
            // olvColumn3
            // 
            this.olvColumn3.AspectName = "Type";
            this.olvColumn3.Text = "Type";
            this.olvColumn3.Width = 100;
            // 
            // TaskListPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listView);
            this.Controls.Add(this.toolbar);
            this.Name = "TaskListPane";
            this.Size = new System.Drawing.Size(358, 324);
            this.TaskListMenuStrip.ResumeLayout(false);
            this.toolbar.ResumeLayout(false);
            this.toolbar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.listView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip TaskListMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem AddTaskItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveTaskItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveCompletedItem;
        private System.Windows.Forms.ToolStripMenuItem ClearAllItem;
        private System.Windows.Forms.ToolStrip toolbar;
        private System.Windows.Forms.ToolStripButton priorityUpButton;
        private System.Windows.Forms.ToolStripButton priorityDownButton;
        private System.Windows.Forms.ToolStripLabel PriorityLabel;
        private System.Windows.Forms.ToolStripSeparator Seperator0;
        private System.Windows.Forms.ToolStripButton DeleteItem;
        private System.Windows.Forms.ToolStripButton AddItem;
        private System.Windows.Forms.ToolStripSeparator Seperator1;
        private System.Windows.Forms.ToolStripSeparator Seperator2;
        private System.Windows.Forms.ToolStripMenuItem SetTypeItem;
        private System.Windows.Forms.ToolStripMenuItem SetPriorityItem;
        private BrightIdeasSoftware.ObjectListView listView;
        private BrightIdeasSoftware.OLVColumn olvColumn1;
        private BrightIdeasSoftware.OLVColumn olvColumn2;
        private BrightIdeasSoftware.OLVColumn olvColumn3;
    }
}
