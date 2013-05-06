namespace Sphere_Editor.SubEditors
{
    partial class ProjectTree
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
            this.ExecuteScriptItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GameSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EngineSettingsItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.FontItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemWatcher = new System.IO.FileSystemWatcher();
            this.ProjectNameLabel = new Sphere.Core.Editor.EditorLabel();
            this.autoRefreshTimer = new System.Windows.Forms.Timer(this.components);
            this.ProjectFileContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SystemWatcher)).BeginInit();
            this.SuspendLayout();
            // 
            // ProjectTreeView
            // 
            this.ProjectTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ProjectTreeView.LabelEdit = true;
            this.ProjectTreeView.Location = new System.Drawing.Point(0, 23);
            this.ProjectTreeView.Name = "ProjectTreeView";
            this.ProjectTreeView.Size = new System.Drawing.Size(191, 364);
            this.ProjectTreeView.TabIndex = 3;
            this.ProjectTreeView.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ProjectTreeView_BeforeLabelEdit);
            this.ProjectTreeView.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.ProjectTreeView_AfterLabelEdit);
            this.ProjectTreeView.AfterCollapse += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTreeView_AfterCollapse);
            this.ProjectTreeView.AfterExpand += new System.Windows.Forms.TreeViewEventHandler(this.ProjectTreeView_AfterExpand);
            this.ProjectTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTreeView_NodeMouseClick);
            this.ProjectTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.ProjectTreeView_NodeMouseDoubleClick);
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
            this.ExecuteScriptItem,
            this.GameSettingsItem,
            this.EngineSettingsItem,
            this.toolStripSeparator1,
            this.FontItem});
            this.ProjectFileContextMenu.Name = "ProjectFileContextMenu";
            this.ProjectFileContextMenu.Size = new System.Drawing.Size(185, 274);
            // 
            // NewFileItem
            // 
            this.NewFileItem.Image = global::Sphere_Editor.Properties.Resources.page_white_edit;
            this.NewFileItem.Name = "NewFileItem";
            this.NewFileItem.Size = new System.Drawing.Size(184, 22);
            this.NewFileItem.Text = "&New File";
            this.NewFileItem.Click += new System.EventHandler(this.NewFileItem_Click);
            // 
            // ImportFileItem
            // 
            this.ImportFileItem.Image = global::Sphere_Editor.Properties.Resources.paste_plain;
            this.ImportFileItem.Name = "ImportFileItem";
            this.ImportFileItem.Size = new System.Drawing.Size(184, 22);
            this.ImportFileItem.Text = "&Import File(s)...";
            this.ImportFileItem.Click += new System.EventHandler(this.ImportFileItem_Click);
            // 
            // AddSubfolderItem
            // 
            this.AddSubfolderItem.Image = global::Sphere_Editor.Properties.Resources.folder_closed;
            this.AddSubfolderItem.Name = "AddSubfolderItem";
            this.AddSubfolderItem.Size = new System.Drawing.Size(184, 22);
            this.AddSubfolderItem.Text = "&Add Subfolder...";
            this.AddSubfolderItem.Click += new System.EventHandler(this.AddFolderItem_Click);
            // 
            // OpenFileItem
            // 
            this.OpenFileItem.Image = global::Sphere_Editor.Properties.Resources.folder;
            this.OpenFileItem.Name = "OpenFileItem";
            this.OpenFileItem.Size = new System.Drawing.Size(184, 22);
            this.OpenFileItem.Text = "&Open File";
            this.OpenFileItem.Click += new System.EventHandler(this.OpenFileItem_Click);
            // 
            // DeleteFileItem
            // 
            this.DeleteFileItem.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.DeleteFileItem.Name = "DeleteFileItem";
            this.DeleteFileItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.DeleteFileItem.Size = new System.Drawing.Size(184, 22);
            this.DeleteFileItem.Text = "&Delete File";
            this.DeleteFileItem.Click += new System.EventHandler(this.DeleteFileItem_Click);
            // 
            // DeleteFolderItem
            // 
            this.DeleteFolderItem.Image = global::Sphere_Editor.Properties.Resources.cross;
            this.DeleteFolderItem.Name = "DeleteFolderItem";
            this.DeleteFolderItem.Size = new System.Drawing.Size(184, 22);
            this.DeleteFolderItem.Text = "De&lete Folder";
            this.DeleteFolderItem.Click += new System.EventHandler(this.DeleteFolderItem_Click);
            // 
            // RenameFileItem
            // 
            this.RenameFileItem.Image = global::Sphere_Editor.Properties.Resources.pencil;
            this.RenameFileItem.Name = "RenameFileItem";
            this.RenameFileItem.Size = new System.Drawing.Size(184, 22);
            this.RenameFileItem.Text = "&Rename File";
            this.RenameFileItem.Click += new System.EventHandler(this.RenameFileItem_Click);
            // 
            // CopyPathItem
            // 
            this.CopyPathItem.Image = global::Sphere_Editor.Properties.Resources.page_copy;
            this.CopyPathItem.Name = "CopyPathItem";
            this.CopyPathItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.CopyPathItem.Size = new System.Drawing.Size(184, 22);
            this.CopyPathItem.Text = "&Copy Path";
            this.CopyPathItem.Click += new System.EventHandler(this.CopyPathItem_Click);
            // 
            // ExecuteScriptItem
            // 
            this.ExecuteScriptItem.Image = global::Sphere_Editor.Properties.Resources.lightning;
            this.ExecuteScriptItem.Name = "ExecuteScriptItem";
            this.ExecuteScriptItem.Size = new System.Drawing.Size(184, 22);
            this.ExecuteScriptItem.Text = "&Execute Script";
            this.ExecuteScriptItem.Click += new System.EventHandler(this.ExecuteScriptItem_Click);
            // 
            // GameSettingsItem
            // 
            this.GameSettingsItem.Image = global::Sphere_Editor.Properties.Resources.SphereEditor;
            this.GameSettingsItem.Name = "GameSettingsItem";
            this.GameSettingsItem.Size = new System.Drawing.Size(184, 22);
            this.GameSettingsItem.Text = "Edit &Game Settings";
            this.GameSettingsItem.Click += new System.EventHandler(this.GameSettingsItem_Click);
            // 
            // EngineSettingsItem
            // 
            this.EngineSettingsItem.Image = global::Sphere_Editor.Properties.Resources.application_view_list;
            this.EngineSettingsItem.Name = "EngineSettingsItem";
            this.EngineSettingsItem.Size = new System.Drawing.Size(184, 22);
            this.EngineSettingsItem.Text = "Edit &Editor Settings";
            this.EngineSettingsItem.Click += new System.EventHandler(this.EngineSettingsItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
            // 
            // FontItem
            // 
            this.FontItem.Image = global::Sphere_Editor.Properties.Resources.style;
            this.FontItem.Name = "FontItem";
            this.FontItem.Size = new System.Drawing.Size(184, 22);
            this.FontItem.Text = "Change Font";
            this.FontItem.Click += new System.EventHandler(this.FontItem_Click);
            // 
            // SystemWatcher
            // 
            this.SystemWatcher.EnableRaisingEvents = true;
            this.SystemWatcher.IncludeSubdirectories = true;
            this.SystemWatcher.SynchronizingObject = this;
            this.SystemWatcher.Created += new System.IO.FileSystemEventHandler(this.SystemWatcher_EventRaised);
            this.SystemWatcher.Deleted += new System.IO.FileSystemEventHandler(this.SystemWatcher_EventRaised);
            this.SystemWatcher.Renamed += new System.IO.RenamedEventHandler(this.SystemWatcher_EventRaised);
            // 
            // ProjectNameLabel
            // 
            this.ProjectNameLabel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProjectNameLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ProjectNameLabel.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ProjectNameLabel.Location = new System.Drawing.Point(0, 0);
            this.ProjectNameLabel.Name = "ProjectNameLabel";
            this.ProjectNameLabel.Size = new System.Drawing.Size(191, 23);
            this.ProjectNameLabel.TabIndex = 4;
            this.ProjectNameLabel.Text = "Project Name";
            this.ProjectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // refreshTimer
            // 
            this.autoRefreshTimer.Interval = 1000;
            this.autoRefreshTimer.Tick += new System.EventHandler(this.refreshTimer_Tick);
            // 
            // ProjectTree
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ProjectTreeView);
            this.Controls.Add(this.ProjectNameLabel);
            this.Name = "ProjectTree";
            this.Size = new System.Drawing.Size(191, 387);
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
        private System.Windows.Forms.ToolStripMenuItem ExecuteScriptItem;
        private System.IO.FileSystemWatcher SystemWatcher;
        private Sphere.Core.Editor.EditorLabel ProjectNameLabel;
        private System.Windows.Forms.ToolStripMenuItem DeleteFolderItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem FontItem;
        private System.Windows.Forms.Timer autoRefreshTimer;
    }
}
