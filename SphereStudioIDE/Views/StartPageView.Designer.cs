namespace SphereStudio.Ide.BuiltIns
{
    partial class StartPageView
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
            this.ItemContextStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PlayGameItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LoadMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameProjectItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFolderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SetIconItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RefreshItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ViewItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TilesItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ListItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmallIconItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeIconItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DetailsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.header = new System.Windows.Forms.Label();
            this.projectListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemContextStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // ItemContextStrip
            // 
            this.ItemContextStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.PlayGameItem,
            this.LoadMenuItem,
            this.RenameProjectItem,
            this.OpenFolderItem,
            this.SetIconItem,
            this.toolStripSeparator1,
            this.RefreshItem,
            this.ViewItem});
            this.ItemContextStrip.Name = "ItemContextStrip";
            this.ItemContextStrip.Size = new System.Drawing.Size(215, 164);
            this.ItemContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ItemContextStrip_Opening);
            // 
            // PlayGameItem
            // 
            this.PlayGameItem.Image = global::SphereStudio.Ide.Properties.Resources.lightning;
            this.PlayGameItem.Name = "PlayGameItem";
            this.PlayGameItem.Size = new System.Drawing.Size(214, 22);
            this.PlayGameItem.Text = "&Play Game";
            this.PlayGameItem.Click += new System.EventHandler(this.PlayMenuItem_Click);
            // 
            // LoadMenuItem
            // 
            this.LoadMenuItem.Image = global::SphereStudio.Ide.Properties.Resources.script_edit;
            this.LoadMenuItem.Name = "LoadMenuItem";
            this.LoadMenuItem.Size = new System.Drawing.Size(214, 22);
            this.LoadMenuItem.Text = "&Open Project";
            this.LoadMenuItem.Click += new System.EventHandler(this.LoadMenuItem_Click);
            // 
            // RenameProjectItem
            // 
            this.RenameProjectItem.Image = global::SphereStudio.Ide.Properties.Resources.application_view_list;
            this.RenameProjectItem.Name = "RenameProjectItem";
            this.RenameProjectItem.Size = new System.Drawing.Size(214, 22);
            this.RenameProjectItem.Text = "&Rename Project";
            this.RenameProjectItem.Click += new System.EventHandler(this.RenameMenuItem_Click);
            // 
            // OpenFolderItem
            // 
            this.OpenFolderItem.Image = global::SphereStudio.Ide.Properties.Resources.folder;
            this.OpenFolderItem.Name = "OpenFolderItem";
            this.OpenFolderItem.Size = new System.Drawing.Size(214, 22);
            this.OpenFolderItem.Text = "Show in Windows Explorer";
            this.OpenFolderItem.Click += new System.EventHandler(this.OpenFolderItem_Click);
            // 
            // SetIconItem
            // 
            this.SetIconItem.Image = global::SphereStudio.Ide.Properties.Resources.palette;
            this.SetIconItem.Name = "SetIconItem";
            this.SetIconItem.Size = new System.Drawing.Size(214, 22);
            this.SetIconItem.Text = "&Set Icon...";
            this.SetIconItem.Click += new System.EventHandler(this.SetIconItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(211, 6);
            // 
            // RefreshItem
            // 
            this.RefreshItem.Image = global::SphereStudio.Ide.Properties.Resources.arrow_refresh;
            this.RefreshItem.Name = "RefreshItem";
            this.RefreshItem.Size = new System.Drawing.Size(214, 22);
            this.RefreshItem.Text = "Re&fresh";
            this.RefreshItem.Click += new System.EventHandler(this.RefreshItem_Click);
            // 
            // ViewItem
            // 
            this.ViewItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TilesItem,
            this.ListItem,
            this.SmallIconItem,
            this.LargeIconItem,
            this.DetailsItem});
            this.ViewItem.Name = "ViewItem";
            this.ViewItem.Size = new System.Drawing.Size(214, 22);
            this.ViewItem.Text = "&View";
            // 
            // TilesItem
            // 
            this.TilesItem.Checked = true;
            this.TilesItem.CheckOnClick = true;
            this.TilesItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.TilesItem.Name = "TilesItem";
            this.TilesItem.Size = new System.Drawing.Size(134, 22);
            this.TilesItem.Text = "&Tiles";
            this.TilesItem.Click += new System.EventHandler(this.TilesItem_Click);
            // 
            // ListItem
            // 
            this.ListItem.CheckOnClick = true;
            this.ListItem.Name = "ListItem";
            this.ListItem.Size = new System.Drawing.Size(134, 22);
            this.ListItem.Text = "&List";
            this.ListItem.Click += new System.EventHandler(this.ListItem_Click);
            // 
            // SmallIconItem
            // 
            this.SmallIconItem.CheckOnClick = true;
            this.SmallIconItem.Name = "SmallIconItem";
            this.SmallIconItem.Size = new System.Drawing.Size(134, 22);
            this.SmallIconItem.Text = "&Small Icons";
            this.SmallIconItem.Click += new System.EventHandler(this.SmallIconItem_Click);
            // 
            // LargeIconItem
            // 
            this.LargeIconItem.CheckOnClick = true;
            this.LargeIconItem.Name = "LargeIconItem";
            this.LargeIconItem.Size = new System.Drawing.Size(134, 22);
            this.LargeIconItem.Text = "&Large Icons";
            this.LargeIconItem.Click += new System.EventHandler(this.LargeIconItem_Click);
            // 
            // DetailsItem
            // 
            this.DetailsItem.CheckOnClick = true;
            this.DetailsItem.Name = "DetailsItem";
            this.DetailsItem.Size = new System.Drawing.Size(134, 22);
            this.DetailsItem.Text = "&Details";
            this.DetailsItem.Click += new System.EventHandler(this.DetailsItem_Click);
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(568, 23);
            this.header.TabIndex = 12;
            this.header.Text = "welcome to the Sphere Studio integrated development environment";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // projectListView
            // 
            this.projectListView.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.projectListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.projectListView.ContextMenuStrip = this.ItemContextStrip;
            this.projectListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectListView.FullRowSelect = true;
            this.projectListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.projectListView.HideSelection = false;
            this.projectListView.LabelEdit = true;
            this.projectListView.Location = new System.Drawing.Point(0, 23);
            this.projectListView.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.projectListView.MultiSelect = false;
            this.projectListView.Name = "projectListView";
            this.projectListView.ShowItemToolTips = true;
            this.projectListView.Size = new System.Drawing.Size(568, 371);
            this.projectListView.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.projectListView.TabIndex = 11;
            this.projectListView.TileSize = new System.Drawing.Size(256, 48);
            this.projectListView.UseCompatibleStateImageBehavior = false;
            this.projectListView.ItemActivate += new System.EventHandler(this.projectListView_ItemActivate);
            this.projectListView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.projectListView_MouseClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 125;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Path";
            this.columnHeader3.Width = 600;
            // 
            // StartPageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.projectListView);
            this.Controls.Add(this.header);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartPageView";
            this.Size = new System.Drawing.Size(568, 394);
            this.ItemContextStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ContextMenuStrip ItemContextStrip;
        private System.Windows.Forms.ToolStripMenuItem PlayGameItem;
        private System.Windows.Forms.ToolStripMenuItem LoadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameProjectItem;
        private System.Windows.Forms.ToolStripMenuItem SetIconItem;
        private System.Windows.Forms.ToolStripMenuItem ViewItem;
        private System.Windows.Forms.ToolStripMenuItem ListItem;
        private System.Windows.Forms.ToolStripMenuItem SmallIconItem;
        private System.Windows.Forms.ToolStripMenuItem LargeIconItem;
        private System.Windows.Forms.ToolStripMenuItem TilesItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem RefreshItem;
        private System.Windows.Forms.ToolStripMenuItem DetailsItem;
        private System.Windows.Forms.Label header;
        private System.Windows.Forms.ListView projectListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}
