﻿namespace SphereStudio.Ide.BuiltIns
{
    partial class ProjectTreePane
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
            this.ProjectTreeView = new System.Windows.Forms.TreeView();
            this.ProjectFileContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.NewFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ImportFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.AddSubfolderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteFolderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RenameFileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CopyPathItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EngineSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenFolderItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ProjectNameLabel = new SphereStudio.UI.DialogHeader();
            this.SystemWatcher = new SphereStudio.Utility.DeferredFileSystemWatcher();
            this.ProjectFileContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectTreeView
            // 
            this.ProjectTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ProjectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectTreeView.HotTracking = true;
            this.ProjectTreeView.ItemHeight = 19;
            this.ProjectTreeView.LabelEdit = true;
            this.ProjectTreeView.Location = new System.Drawing.Point(0, 24);
            this.ProjectTreeView.Margin = new System.Windows.Forms.Padding(2);
            this.ProjectTreeView.Name = "ProjectTreeView";
            this.ProjectTreeView.Size = new System.Drawing.Size(191, 364);
            this.ProjectTreeView.TabIndex = 3;
            this.ProjectTreeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ProjectTreeView_BeforeLabelEdit);
            this.ProjectTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ProjectTreeView_AfterLabelEdit);
            this.ProjectTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTreeView_AfterCollapse);
            this.ProjectTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTreeView_AfterExpand);
            this.ProjectTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTreeView_NodeMouseClick);
            this.ProjectTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTreeView_NodeMouseDoubleClick);
            this.ProjectTreeView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ProjectTreeView_KeyDown);
            this.ProjectTreeView.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ProjectTreeView_KeyPress);
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
            this.EngineSettingsItem,
            this.OpenFolderItem,
            this.GameSettingsItem});
            this.ProjectFileContextMenu.Name = "ProjectFileContextMenu";
            this.ProjectFileContextMenu.Size = new System.Drawing.Size(191, 246);
            this.ProjectFileContextMenu.Opening += new System.ComponentModel.CancelEventHandler(this.ProjectFileContextMenu_Opening);
            // 
            // NewFileItem
            // 
            this.NewFileItem.Image = global::SphereStudio.Ide.Properties.Resources.page_white_edit;
            this.NewFileItem.Name = "NewFileItem";
            this.NewFileItem.Size = new System.Drawing.Size(190, 22);
            this.NewFileItem.Text = "&New";
            // 
            // ImportFileItem
            // 
            this.ImportFileItem.Image = global::SphereStudio.Ide.Properties.Resources.paste_plain;
            this.ImportFileItem.Name = "ImportFileItem";
            this.ImportFileItem.Size = new System.Drawing.Size(190, 22);
            this.ImportFileItem.Text = "&Import File(s)...";
            this.ImportFileItem.Click += new System.EventHandler(this.ImportFileItem_Click);
            // 
            // AddSubfolderItem
            // 
            this.AddSubfolderItem.Image = global::SphereStudio.Ide.Properties.Resources.folder_closed;
            this.AddSubfolderItem.Name = "AddSubfolderItem";
            this.AddSubfolderItem.Size = new System.Drawing.Size(190, 22);
            this.AddSubfolderItem.Text = "&Add Subfolder...";
            this.AddSubfolderItem.Click += new System.EventHandler(this.AddFolderItem_Click);
            // 
            // OpenFileItem
            // 
            this.OpenFileItem.Image = global::SphereStudio.Ide.Properties.Resources.folder;
            this.OpenFileItem.Name = "OpenFileItem";
            this.OpenFileItem.Size = new System.Drawing.Size(190, 22);
            this.OpenFileItem.Text = "&Open File";
            this.OpenFileItem.Click += new System.EventHandler(this.OpenFileItem_Click);
            // 
            // DeleteFileItem
            // 
            this.DeleteFileItem.Image = global::SphereStudio.Ide.Properties.Resources.cross;
            this.DeleteFileItem.Name = "DeleteFileItem";
            this.DeleteFileItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteFileItem.Size = new System.Drawing.Size(190, 22);
            this.DeleteFileItem.Text = "&Delete File";
            this.DeleteFileItem.Click += new System.EventHandler(this.DeleteFileItem_Click);
            // 
            // DeleteFolderItem
            // 
            this.DeleteFolderItem.Image = global::SphereStudio.Ide.Properties.Resources.cross;
            this.DeleteFolderItem.Name = "DeleteFolderItem";
            this.DeleteFolderItem.Size = new System.Drawing.Size(190, 22);
            this.DeleteFolderItem.Text = "De&lete Folder";
            this.DeleteFolderItem.Click += new System.EventHandler(this.DeleteFolderItem_Click);
            // 
            // RenameFileItem
            // 
            this.RenameFileItem.Image = global::SphereStudio.Ide.Properties.Resources.pencil;
            this.RenameFileItem.Name = "RenameFileItem";
            this.RenameFileItem.Size = new System.Drawing.Size(190, 22);
            this.RenameFileItem.Text = "&Rename File";
            this.RenameFileItem.Click += new System.EventHandler(this.RenameFileItem_Click);
            // 
            // CopyPathItem
            // 
            this.CopyPathItem.Image = global::SphereStudio.Ide.Properties.Resources.page_copy;
            this.CopyPathItem.Name = "CopyPathItem";
            this.CopyPathItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyPathItem.Size = new System.Drawing.Size(190, 22);
            this.CopyPathItem.Text = "&Copy Path";
            this.CopyPathItem.Click += new System.EventHandler(this.CopyPathItem_Click);
            // 
            // EngineSettingsItem
            // 
            this.EngineSettingsItem.Image = global::SphereStudio.Ide.Properties.Resources.application_view_list;
            this.EngineSettingsItem.Name = "EngineSettingsItem";
            this.EngineSettingsItem.Size = new System.Drawing.Size(190, 22);
            this.EngineSettingsItem.Text = "Edit &Editor Settings";
            this.EngineSettingsItem.Click += new System.EventHandler(this.EngineSettingsItem_Click);
            // 
            // OpenFolderItem
            // 
            this.OpenFolderItem.Image = global::SphereStudio.Ide.Properties.Resources.open;
            this.OpenFolderItem.Name = "OpenFolderItem";
            this.OpenFolderItem.Size = new System.Drawing.Size(190, 22);
            this.OpenFolderItem.Text = "Open in Explorer";
            this.OpenFolderItem.Click += new System.EventHandler(this.OpenFolderItem_Click);
            // 
            // GameSettingsItem
            // 
            this.GameSettingsItem.Image = global::SphereStudio.Ide.Properties.Resources.SphereEditor;
            this.GameSettingsItem.Name = "GameSettingsItem";
            this.GameSettingsItem.Size = new System.Drawing.Size(190, 22);
            this.GameSettingsItem.Text = "Project P&roperties...";
            this.GameSettingsItem.Click += new System.EventHandler(this.GameSettingsItem_Click);
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ProjectNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProjectNameLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ProjectNameLabel.ForeColor = System.Drawing.Color.White;
            this.ProjectNameLabel.Location = new System.Drawing.Point(0, 0);
            this.ProjectNameLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(191, 24);
            this.ProjectNameLabel.TabIndex = 4;
            this.ProjectNameLabel.Text = "Project Name";
            this.ProjectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            // ProjectTreePane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProjectTreeView);
            this.Controls.Add(this.ProjectNameLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "ProjectTreePane";
            this.Size = new System.Drawing.Size(191, 388);
            this.ProjectFileContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SystemWatcher)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.TreeView ProjectTreeView;
        private System.Windows.Forms.ContextMenuStrip ProjectFileContextMenu;
        private System.Windows.Forms.ToolStripMenuItem NewFileItem;
        private System.Windows.Forms.ToolStripMenuItem ImportFileItem;
        private System.Windows.Forms.ToolStripMenuItem DeleteFileItem;
        private System.Windows.Forms.ToolStripMenuItem OpenFileItem;
        private System.Windows.Forms.ToolStripMenuItem RenameFileItem;
        private System.Windows.Forms.ToolStripMenuItem GameSettingsItem;
        private System.Windows.Forms.ToolStripMenuItem EngineSettingsItem;
        private System.Windows.Forms.ToolStripMenuItem AddSubfolderItem;
        private System.Windows.Forms.ToolStripMenuItem CopyPathItem;
        private SphereStudio.UI.DialogHeader ProjectNameLabel;
        private System.Windows.Forms.ToolStripMenuItem DeleteFolderItem;
        private SphereStudio.Utility.DeferredFileSystemWatcher SystemWatcher;
        private System.Windows.Forms.ToolStripMenuItem OpenFolderItem;
    }
}
