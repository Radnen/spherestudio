namespace SphereStudio.Views
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
            this.GameFolders = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.InfoPanel = new System.Windows.Forms.Panel();
            this.InfoSplitter = new System.Windows.Forms.SplitContainer();
            this.GamePanel = new System.Windows.Forms.Panel();
            this.NameLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.SizeLabel = new System.Windows.Forms.Label();
            this.DescTextLabel = new System.Windows.Forms.Label();
            this.GamesPanel = new System.Windows.Forms.Panel();
            this.MainSplitter = new System.Windows.Forms.SplitContainer();
            this.GameProjectLabel = new Sphere.Core.Editor.EditorLabel();
            this.InfoLabel = new Sphere.Core.Editor.EditorLabel();
            this.DescLabel = new Sphere.Core.Editor.EditorLabel();
            this.ItemContextStrip.SuspendLayout();
            this.InfoPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InfoSplitter)).BeginInit();
            this.InfoSplitter.Panel1.SuspendLayout();
            this.InfoSplitter.Panel2.SuspendLayout();
            this.InfoSplitter.SuspendLayout();
            this.GamePanel.SuspendLayout();
            this.GamesPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitter)).BeginInit();
            this.MainSplitter.Panel1.SuspendLayout();
            this.MainSplitter.Panel2.SuspendLayout();
            this.MainSplitter.SuspendLayout();
            this.SuspendLayout();
            // 
            // GameFolders
            // 
            this.GameFolders.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GameFolders.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GameFolders.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.GameFolders.ContextMenuStrip = this.ItemContextStrip;
            this.GameFolders.FullRowSelect = true;
            this.GameFolders.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.GameFolders.LabelEdit = true;
            this.GameFolders.Location = new System.Drawing.Point(3, 27);
            this.GameFolders.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GameFolders.MultiSelect = false;
            this.GameFolders.Name = "GameFolders";
            this.GameFolders.ShowItemToolTips = true;
            this.GameFolders.Size = new System.Drawing.Size(418, 155);
            this.GameFolders.TabIndex = 0;
            this.GameFolders.TileSize = new System.Drawing.Size(256, 48);
            this.GameFolders.UseCompatibleStateImageBehavior = false;
            this.GameFolders.View = System.Windows.Forms.View.Tile;
            this.GameFolders.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.GameFolders_AfterLabelEdit);
            this.GameFolders.ItemActivate += new System.EventHandler(this.GameFolders_ItemActivate);
            this.GameFolders.MouseClick += new System.Windows.Forms.MouseEventHandler(this.GameFolders_MouseClick);
            this.GameFolders.MouseEnter += new System.EventHandler(this.GameFolders_MouseEnter);
            this.GameFolders.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 300;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Author";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Path";
            this.columnHeader3.Width = 700;
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
            this.ItemContextStrip.Size = new System.Drawing.Size(194, 164);
            this.ItemContextStrip.Opening += new System.ComponentModel.CancelEventHandler(this.ItemContextStrip_Opening);
            // 
            // PlayGameItem
            // 
            this.PlayGameItem.Image = global::SphereStudio.Properties.Resources.lightning;
            this.PlayGameItem.Name = "PlayGameItem";
            this.PlayGameItem.Size = new System.Drawing.Size(193, 22);
            this.PlayGameItem.Text = "&Play Game";
            this.PlayGameItem.Click += new System.EventHandler(this.PlayMenuItem_Click);
            // 
            // LoadMenuItem
            // 
            this.LoadMenuItem.Image = global::SphereStudio.Properties.Resources.script_edit;
            this.LoadMenuItem.Name = "LoadMenuItem";
            this.LoadMenuItem.Size = new System.Drawing.Size(193, 22);
            this.LoadMenuItem.Text = "&Load Project";
            this.LoadMenuItem.Click += new System.EventHandler(this.LoadMenuItem_Click);
            // 
            // RenameProjectItem
            // 
            this.RenameProjectItem.Image = global::SphereStudio.Properties.Resources.application_view_list;
            this.RenameProjectItem.Name = "RenameProjectItem";
            this.RenameProjectItem.Size = new System.Drawing.Size(193, 22);
            this.RenameProjectItem.Text = "&Rename Project Folder";
            this.RenameProjectItem.Click += new System.EventHandler(this.RenameMenuItem_Click);
            // 
            // OpenFolderItem
            // 
            this.OpenFolderItem.Image = global::SphereStudio.Properties.Resources.folder;
            this.OpenFolderItem.Name = "OpenFolderItem";
            this.OpenFolderItem.Size = new System.Drawing.Size(193, 22);
            this.OpenFolderItem.Text = "Open Game Location";
            this.OpenFolderItem.Click += new System.EventHandler(this.OpenFolderItem_Click);
            // 
            // SetIconItem
            // 
            this.SetIconItem.Image = global::SphereStudio.Properties.Resources.palette;
            this.SetIconItem.Name = "SetIconItem";
            this.SetIconItem.Size = new System.Drawing.Size(193, 22);
            this.SetIconItem.Text = "&Set Icon...";
            this.SetIconItem.Click += new System.EventHandler(this.SetIconItem_Click);
            this.SetIconItem.MouseEnter += new System.EventHandler(this.SetIconItem_MouseEnter);
            this.SetIconItem.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(190, 6);
            // 
            // RefreshItem
            // 
            this.RefreshItem.Image = global::SphereStudio.Properties.Resources.arrow_refresh;
            this.RefreshItem.Name = "RefreshItem";
            this.RefreshItem.Size = new System.Drawing.Size(193, 22);
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
            this.ViewItem.Size = new System.Drawing.Size(193, 22);
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
            // InfoPanel
            // 
            this.InfoPanel.Controls.Add(this.InfoSplitter);
            this.InfoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoPanel.Location = new System.Drawing.Point(0, 0);
            this.InfoPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InfoPanel.Name = "InfoPanel";
            this.InfoPanel.Size = new System.Drawing.Size(424, 134);
            this.InfoPanel.TabIndex = 9;
            this.InfoPanel.MouseEnter += new System.EventHandler(this.InfoPanel_MouseEnter);
            this.InfoPanel.MouseLeave += new System.EventHandler(this.ClearTip);
            // 
            // InfoSplitter
            // 
            this.InfoSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InfoSplitter.Location = new System.Drawing.Point(0, 0);
            this.InfoSplitter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.InfoSplitter.Name = "InfoSplitter";
            // 
            // InfoSplitter.Panel1
            // 
            this.InfoSplitter.Panel1.Controls.Add(this.GamePanel);
            this.InfoSplitter.Panel1.Controls.Add(this.InfoLabel);
            // 
            // InfoSplitter.Panel2
            // 
            this.InfoSplitter.Panel2.Controls.Add(this.DescTextLabel);
            this.InfoSplitter.Panel2.Controls.Add(this.DescLabel);
            this.InfoSplitter.Size = new System.Drawing.Size(424, 134);
            this.InfoSplitter.SplitterDistance = 101;
            this.InfoSplitter.TabIndex = 14;
            // 
            // GamePanel
            // 
            this.GamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GamePanel.BackColor = System.Drawing.SystemColors.Control;
            this.GamePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.GamePanel.Controls.Add(this.NameLabel);
            this.GamePanel.Controls.Add(this.AuthorLabel);
            this.GamePanel.Controls.Add(this.SizeLabel);
            this.GamePanel.Location = new System.Drawing.Point(3, 27);
            this.GamePanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GamePanel.Name = "GamePanel";
            this.GamePanel.Size = new System.Drawing.Size(95, 103);
            this.GamePanel.TabIndex = 12;
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Location = new System.Drawing.Point(3, 6);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(41, 13);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name: ";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.BackColor = System.Drawing.Color.Transparent;
            this.AuthorLabel.Location = new System.Drawing.Point(3, 31);
            this.AuthorLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(41, 13);
            this.AuthorLabel.TabIndex = 1;
            this.AuthorLabel.Text = "Author:";
            // 
            // SizeLabel
            // 
            this.SizeLabel.AutoSize = true;
            this.SizeLabel.BackColor = System.Drawing.Color.Transparent;
            this.SizeLabel.Location = new System.Drawing.Point(3, 56);
            this.SizeLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.SizeLabel.Name = "SizeLabel";
            this.SizeLabel.Size = new System.Drawing.Size(63, 13);
            this.SizeLabel.TabIndex = 2;
            this.SizeLabel.Text = "Resolution: ";
            // 
            // DescTextLabel
            // 
            this.DescTextLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DescTextLabel.BackColor = System.Drawing.SystemColors.Control;
            this.DescTextLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescTextLabel.Location = new System.Drawing.Point(5, 27);
            this.DescTextLabel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.DescTextLabel.Name = "DescTextLabel";
            this.DescTextLabel.Padding = new System.Windows.Forms.Padding(2);
            this.DescTextLabel.Size = new System.Drawing.Size(311, 103);
            this.DescTextLabel.TabIndex = 4;
            // 
            // GamesPanel
            // 
            this.GamesPanel.Controls.Add(this.GameFolders);
            this.GamesPanel.Controls.Add(this.GameProjectLabel);
            this.GamesPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GamesPanel.Location = new System.Drawing.Point(0, 0);
            this.GamesPanel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GamesPanel.Name = "GamesPanel";
            this.GamesPanel.Size = new System.Drawing.Size(424, 186);
            this.GamesPanel.TabIndex = 3;
            // 
            // MainSplitter
            // 
            this.MainSplitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitter.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.MainSplitter.Location = new System.Drawing.Point(0, 0);
            this.MainSplitter.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MainSplitter.Name = "MainSplitter";
            this.MainSplitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainSplitter.Panel1
            // 
            this.MainSplitter.Panel1.Controls.Add(this.GamesPanel);
            // 
            // MainSplitter.Panel2
            // 
            this.MainSplitter.Panel2.Controls.Add(this.InfoPanel);
            this.MainSplitter.Size = new System.Drawing.Size(424, 324);
            this.MainSplitter.SplitterDistance = 186;
            this.MainSplitter.TabIndex = 10;
            // 
            // GameProjectLabel
            // 
            this.GameProjectLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.GameProjectLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.GameProjectLabel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.GameProjectLabel.ForeColor = System.Drawing.Color.White;
            this.GameProjectLabel.Location = new System.Drawing.Point(0, 0);
            this.GameProjectLabel.Name = "GameProjectLabel";
            this.GameProjectLabel.Size = new System.Drawing.Size(424, 23);
            this.GameProjectLabel.TabIndex = 1;
            this.GameProjectLabel.Text = "Game Projects";
            this.GameProjectLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // InfoLabel
            // 
            this.InfoLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.InfoLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.InfoLabel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.InfoLabel.ForeColor = System.Drawing.Color.White;
            this.InfoLabel.Location = new System.Drawing.Point(0, 0);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(101, 23);
            this.InfoLabel.TabIndex = 11;
            this.InfoLabel.Text = "Game Info";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // DescLabel
            // 
            this.DescLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.DescLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.DescLabel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.DescLabel.ForeColor = System.Drawing.Color.White;
            this.DescLabel.Location = new System.Drawing.Point(0, 0);
            this.DescLabel.Name = "DescLabel";
            this.DescLabel.Size = new System.Drawing.Size(319, 23);
            this.DescLabel.TabIndex = 11;
            this.DescLabel.Text = "Description";
            this.DescLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // StartPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.MainSplitter);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StartPage";
            this.Size = new System.Drawing.Size(424, 324);
            this.ItemContextStrip.ResumeLayout(false);
            this.InfoPanel.ResumeLayout(false);
            this.InfoSplitter.Panel1.ResumeLayout(false);
            this.InfoSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InfoSplitter)).EndInit();
            this.InfoSplitter.ResumeLayout(false);
            this.GamePanel.ResumeLayout(false);
            this.GamePanel.PerformLayout();
            this.GamesPanel.ResumeLayout(false);
            this.MainSplitter.Panel1.ResumeLayout(false);
            this.MainSplitter.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitter)).EndInit();
            this.MainSplitter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView GameFolders;
        private System.Windows.Forms.Label SizeLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.ContextMenuStrip ItemContextStrip;
        private System.Windows.Forms.ToolStripMenuItem PlayGameItem;
        private System.Windows.Forms.ToolStripMenuItem LoadMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RenameProjectItem;
        private System.Windows.Forms.Panel GamesPanel;
        private System.Windows.Forms.Panel InfoPanel;
        private System.Windows.Forms.Label DescTextLabel;
        private Sphere.Core.Editor.EditorLabel GameProjectLabel;
        private System.Windows.Forms.ToolStripMenuItem SetIconItem;
        private System.Windows.Forms.ToolStripMenuItem ViewItem;
        private System.Windows.Forms.ToolStripMenuItem ListItem;
        private System.Windows.Forms.ToolStripMenuItem SmallIconItem;
        private System.Windows.Forms.ToolStripMenuItem LargeIconItem;
        private System.Windows.Forms.ToolStripMenuItem TilesItem;
        private Sphere.Core.Editor.EditorLabel DescLabel;
        private Sphere.Core.Editor.EditorLabel InfoLabel;
        private System.Windows.Forms.SplitContainer MainSplitter;
        private System.Windows.Forms.Panel GamePanel;
        private System.Windows.Forms.SplitContainer InfoSplitter;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem RefreshItem;
        private System.Windows.Forms.ToolStripMenuItem DetailsItem;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;






    }
}
