namespace SphereStudio.Ide.BuiltIns
{
    partial class FileListPane
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
            this.fileTree = new System.Windows.Forms.TreeView();
            this.ProjectFileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSubfolderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFolderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyPathItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFolderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemWatcher = new SphereStudio.Utility.DeferredFileSystemWatcher();
            this.header = new System.Windows.Forms.Label();
            this.ProjectFileContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // fileTree
            // 
            this.fileTree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fileTree.HotTracking = true;
            this.fileTree.ItemHeight = 19;
            this.fileTree.LabelEdit = true;
            this.fileTree.Location = new System.Drawing.Point(0, 23);
            this.fileTree.Margin = new System.Windows.Forms.Padding(2);
            this.fileTree.Name = "fileTree";
            this.fileTree.Size = new System.Drawing.Size(191, 365);
            this.fileTree.TabIndex = 3;
            this.fileTree.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ProjectTreeView_BeforeLabelEdit);
            this.fileTree.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ProjectTreeView_AfterLabelEdit);
            this.fileTree.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTreeView_AfterCollapse);
            this.fileTree.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTreeView_AfterExpand);
            this.fileTree.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTreeView_NodeMouseClick);
            this.fileTree.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTreeView_NodeMouseDoubleClick);
            this.fileTree.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectTreeView_KeyDown);
            this.fileTree.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProjectTreeView_KeyPress);
            // 
            // ProjectFileContextMenu
            // 
            this.ProjectFileContextMenu.BackColor = System.Drawing.Color.Lavender;
            this.ProjectFileContextMenu.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectFileContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewFileItem,
            this.ImportFileItem,
            this.AddSubfolderItem,
            this.OpenFileItem,
            this.DeleteFileItem,
            this.DeleteFolderItem,
            this.RenameFileItem,
            this.CopyPathItem,
            this.OpenFolderItem,
            this.GameSettingsItem});
            this.ProjectFileContextMenu.Name = "ProjectFileContextMenu";
            this.ProjectFileContextMenu.Size = new System.Drawing.Size(189, 246);
            this.ProjectFileContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ProjectFileContextMenu_Opening);
            // 
            // NewFileItem
            // 
            this.NewFileItem.Image = global::SphereStudio.Ide.Properties.Resources.page_white_edit;
            this.NewFileItem.Name = "NewFileItem";
            this.NewFileItem.Size = new System.Drawing.Size(188, 22);
            this.NewFileItem.Text = "&New";
            // 
            // ImportFileItem
            // 
            this.ImportFileItem.Image = global::SphereStudio.Ide.Properties.Resources.paste_plain;
            this.ImportFileItem.Name = "ImportFileItem";
            this.ImportFileItem.Size = new System.Drawing.Size(188, 22);
            this.ImportFileItem.Text = "&Import File(s)...";
            this.ImportFileItem.Click += new System.EventHandler(this.ImportFileItem_Click);
            // 
            // AddSubfolderItem
            // 
            this.AddSubfolderItem.Image = global::SphereStudio.Ide.Properties.Resources.folder_closed;
            this.AddSubfolderItem.Name = "AddSubfolderItem";
            this.AddSubfolderItem.Size = new System.Drawing.Size(188, 22);
            this.AddSubfolderItem.Text = "&Add Subfolder...";
            this.AddSubfolderItem.Click += new System.EventHandler(this.AddFolderItem_Click);
            // 
            // OpenFileItem
            // 
            this.OpenFileItem.Image = global::SphereStudio.Ide.Properties.Resources.folder;
            this.OpenFileItem.Name = "OpenFileItem";
            this.OpenFileItem.Size = new System.Drawing.Size(188, 22);
            this.OpenFileItem.Text = "&Open File";
            this.OpenFileItem.Click += new System.EventHandler(this.OpenFileItem_Click);
            // 
            // DeleteFileItem
            // 
            this.DeleteFileItem.Image = global::SphereStudio.Ide.Properties.Resources.cross;
            this.DeleteFileItem.Name = "DeleteFileItem";
            this.DeleteFileItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteFileItem.Size = new System.Drawing.Size(188, 22);
            this.DeleteFileItem.Text = "&Delete File";
            this.DeleteFileItem.Click += new System.EventHandler(this.DeleteFileItem_Click);
            // 
            // DeleteFolderItem
            // 
            this.DeleteFolderItem.Image = global::SphereStudio.Ide.Properties.Resources.cross;
            this.DeleteFolderItem.Name = "DeleteFolderItem";
            this.DeleteFolderItem.Size = new System.Drawing.Size(188, 22);
            this.DeleteFolderItem.Text = "De&lete Folder";
            this.DeleteFolderItem.Click += new System.EventHandler(this.DeleteFolderItem_Click);
            // 
            // RenameFileItem
            // 
            this.RenameFileItem.Image = global::SphereStudio.Ide.Properties.Resources.pencil;
            this.RenameFileItem.Name = "RenameFileItem";
            this.RenameFileItem.Size = new System.Drawing.Size(188, 22);
            this.RenameFileItem.Text = "&Rename File";
            this.RenameFileItem.Click += new System.EventHandler(this.RenameFileItem_Click);
            // 
            // CopyPathItem
            // 
            this.CopyPathItem.Image = global::SphereStudio.Ide.Properties.Resources.page_copy;
            this.CopyPathItem.Name = "CopyPathItem";
            this.CopyPathItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyPathItem.Size = new System.Drawing.Size(188, 22);
            this.CopyPathItem.Text = "&Copy Path";
            this.CopyPathItem.Click += new System.EventHandler(this.CopyPathItem_Click);
            // 
            // OpenFolderItem
            // 
            this.OpenFolderItem.Image = global::SphereStudio.Ide.Properties.Resources.open;
            this.OpenFolderItem.Name = "OpenFolderItem";
            this.OpenFolderItem.Size = new System.Drawing.Size(188, 22);
            this.OpenFolderItem.Text = "Open in Explorer";
            this.OpenFolderItem.Click += new System.EventHandler(this.OpenFolderItem_Click);
            // 
            // GameSettingsItem
            // 
            this.GameSettingsItem.Image = global::SphereStudio.Ide.Properties.Resources.SphereEditor;
            this.GameSettingsItem.Name = "GameSettingsItem";
            this.GameSettingsItem.Size = new System.Drawing.Size(188, 22);
            this.GameSettingsItem.Text = "Project P&roperties...";
            this.GameSettingsItem.Click += new System.EventHandler(this.GameSettingsItem_Click);
            // 
            // SystemWatcher
            // 
            this.SystemWatcher.Delay = 1000D;
            this.SystemWatcher.EnableRaisingEvents = true;
            this.SystemWatcher.IncludeSubdirectories = true;
            this.SystemWatcher.SynchronizingObject = this;
            this.SystemWatcher.Created += new SphereStudio.Utility.BatchEventHandler<System.IO.FileSystemEventArgs>(this.SystemWatcher_Created);
            this.SystemWatcher.Deleted += new SphereStudio.Utility.BatchEventHandler<System.IO.FileSystemEventArgs>(this.SystemWatcher_Deleted);
            this.SystemWatcher.Renamed += new SphereStudio.Utility.BatchEventHandler<System.IO.RenamedEventArgs>(this.SystemWatcher_Renamed);
            // 
            // header
            // 
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(191, 23);
            this.header.TabIndex = 4;
            this.header.Text = "explore files in this project";
            this.header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // FileListPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.fileTree);
            this.Controls.Add(this.header);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FileListPane";
            this.Size = new System.Drawing.Size(191, 388);
            this.ProjectFileContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SystemWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView fileTree;
        private System.Windows.Forms.ContextMenuStrip ProjectFileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem NewFileItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFileItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteFileItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileItem;
        private System.Windows.Forms.ToolStripMenuItem RenameFileItem;
        private System.Windows.Forms.ToolStripMenuItem GameSettingsItem;
        private System.Windows.Forms.ToolStripMenuItem AddSubfolderItem;
        private System.Windows.Forms.ToolStripMenuItem CopyPathItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteFolderItem;
        private SphereStudio.Utility.DeferredFileSystemWatcher SystemWatcher;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderItem;
        private System.Windows.Forms.Label header;
    }
}
