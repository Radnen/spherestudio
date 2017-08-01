using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Microsoft.VisualBasic.FileIO;

using SphereStudio.Ide.Forms;
using SphereStudio.Ide.Properties;
using SphereStudio.Base;
using SphereStudio.UI;

namespace SphereStudio.Ide.BuiltIns
{
    [ToolboxItem(false)]
    partial class ProjectDockPane : UserControl, IDockPane, IStyleable
    {
        private readonly IdeWindow _hostForm;
        private readonly ImageList _iconlist = new ImageList();
        private readonly ToolTip _tip = new ToolTip();

        public ProjectDockPane(IdeWindow hostForm)
        {
            InitializeComponent();
            Styler.AutoStyle(this);

            _hostForm = hostForm;

            // TODO: Fix this ugly hack! (ProjectTree New submenu)
            NewFileItem.DropDown = _hostForm.menuNew.DropDown;
            NewFileItem.DropDownOpening += _hostForm.menuNew_DropDownOpening;
            NewFileItem.DropDownClosed += _hostForm.menuNew_DropDownClosed;

            _tip.ToolTipTitle = "Image";
            _tip.ToolTipIcon = ToolTipIcon.Info;
            _tip.UseFading = true;

            ProjectTreeView.ImageList = _iconlist;
            _iconlist.ColorDepth = ColorDepth.Depth32Bit;
        }

        public bool ShowInViewMenu => true;
        public Control Control => this;
        public DockHint DockHint => DockHint.Left;
        public Bitmap DockIcon => Resources.SphereEditor;

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        public string ProjectName
        {
            get { return ProjectNameLabel.Text; }
            set { ProjectNameLabel.Text = value; }
        }

        private void ImportFileItem_Click(object sender, EventArgs e)
        {
            string path = ResolvePath(ProjectTreeView.SelectedNode);
            string[] filesToAdd = _hostForm.GetFilesToOpen(true);
            
            if (filesToAdd == null || filesToAdd.Length == 0) return;

            foreach (string filePath in filesToAdd)
            {
                string newpath = path + "\\" + Path.GetFileName(filePath);
                var copy = true;

                if (File.Exists(newpath))
                {
                    var text = string.Format(@"File: {0} seems to exist. Overwrite destination?", newpath);
                    copy = MessageBox.Show(text, @"Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
                }

                if (copy) File.Copy(filePath, newpath, true);
            }
        }

        private void ProjectTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;
            ProjectTreeView.SelectedNode = e.Node;

            OpenFileItem.Visible = DeleteFileItem.Visible = false;
            RenameFileItem.Visible = CopyPathItem.Visible = false;
            GameSettingsItem.Visible = EngineSettingsItem.Visible = false;
            NewFileItem.Visible = ImportFileItem.Visible = false;
            AddSubfolderItem.Visible = DeleteFolderItem.Visible = false;

            string tag = e.Node.Tag as string;
            switch (tag)
            {
                case "project-node":
                    GameSettingsItem.Visible = EngineSettingsItem.Visible = true;
                    AddSubfolderItem.Visible = true;
                    break;
                case "file-node":
                    OpenFileItem.Visible = DeleteFileItem.Visible = true;
                    RenameFileItem.Visible = CopyPathItem.Visible = true;
                    string s = e.Node.Text;
                    break;
                case "directory-node":
                    NewFileItem.Visible = ImportFileItem.Visible = true;
                    AddSubfolderItem.Visible = DeleteFolderItem.Visible = true;
                    break;
            }

            ProjectFileContextMenu.Show(ProjectTreeView, e.Location);
        }

        private void RenameFileItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ProjectTreeView.SelectedNode;
            if (node.Tag.Equals("file-node")) node.BeginEdit();
        }

        private void DeleteFileItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ProjectTreeView.SelectedNode;
            string pathtop = node.FullPath.Substring(node.FullPath.IndexOf('\\'));
            string path = Core.Project.RootPath + pathtop;

            if (!File.Exists(path)) return;
            try
            {
                FileSystem.DeleteFile(path, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
            catch (OperationCanceledException) { return; }
        }

        /// <summary>
        ///     Pauses the filesystem watcher from modifying this control.
        /// </summary>
        public void Pause()
        {
            if (string.IsNullOrEmpty(SystemWatcher.Path)) return;
            SystemWatcher.EnableRaisingEvents = false;
        }

        /// <summary>
        /// Resumes the filesystem watcher, enabling it to modify this control.
        /// </summary>
        public void Resume()
        {
            if (string.IsNullOrEmpty(SystemWatcher.Path)) return;
            SystemWatcher.EnableRaisingEvents = true;
        }

        private void ProjectTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == 1)
            {
                e.Node.ImageIndex = 2;
                e.Node.SelectedImageIndex = 2;
            }
        }

        private void ProjectTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex == 2)
            {
                e.Node.ImageIndex = 1;
                e.Node.SelectedImageIndex = 1;
            }
        }

        /// <summary>
        ///     Extends the Refresh method to update the contents of the tree.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();

            if (Core.Project == null || string.IsNullOrEmpty(Core.Project.RootPath))
                return;

            // update the icons
            _iconlist.Images.Clear();
            _iconlist.Images.Add(Resources.SphereEditor);
            _iconlist.Images.Add(Resources.folder_closed);
            _iconlist.Images.Add(Resources.folder);
            _iconlist.Images.Add(Resources.new_item);
            string[] pluginNames = PluginManager.GetNames<IFileOpener>();
            foreach (string name in pluginNames)
            {
                var plugin = PluginManager.Get<IFileOpener>(name);
                _iconlist.Images.Add(name, plugin.FileIcon ?? Resources.new_item);
            }

            Cursor.Current = Cursors.WaitCursor;

            // Save currently selected item and folder expansion states
            string selectedNodePath = ProjectTreeView.SelectedNode != null
                                          ? ProjectTreeView.SelectedNode.FullPath
                                          : null;
            var isExpandedTable = new Dictionary<string, bool>();
            var nodesToCheck = new Queue<TreeNode>();
            if (ProjectTreeView.TopNode != null)
            {
                nodesToCheck.Enqueue(ProjectTreeView.TopNode);
                while (nodesToCheck.Count > 0)
                {
                    TreeNode node = nodesToCheck.Dequeue();
                    isExpandedTable.Add(node.FullPath, node.IsExpanded);
                    foreach (TreeNode subnode in node.Nodes)
                    {
                        // emulate a recursive search of the tree view:
                        nodesToCheck.Enqueue(subnode);
                    }
                }
            }

            // Repopulate the tree
            ProjectTreeView.BeginUpdate();
            ProjectTreeView.Nodes.Clear();
            var projectNode = new TreeNode(Core.Project.Name) { Tag = "project-node" };
            ProjectTreeView.Nodes.Add(projectNode);
            var baseDir = new DirectoryInfo(SystemWatcher.Path);
            PopulateDirectoryNode(ProjectTreeView.Nodes[0], baseDir);

            // Re-expand folders and try to select previously-selected item
            if (ProjectTreeView.TopNode != null)
            {
                nodesToCheck.Clear();
                nodesToCheck.Enqueue(ProjectTreeView.TopNode);
                while (nodesToCheck.Count > 0)
                {
                    TreeNode node = nodesToCheck.Dequeue();
                    bool isExpanded;
                    isExpandedTable.TryGetValue(node.FullPath, out isExpanded);
                    if (isExpanded) node.Expand();
                    if (node.FullPath == selectedNodePath) ProjectTreeView.SelectedNode = node;
                    foreach (TreeNode subnode in node.Nodes)
                    {
                        // emulate a recursive search of the tree view:
                        nodesToCheck.Enqueue(subnode);
                    }
                }
            }

            if (ProjectTreeView.SelectedNode == null) ProjectTreeView.SelectedNode = ProjectTreeView.TopNode;
            if (!ProjectTreeView.Nodes[0].IsExpanded) ProjectTreeView.Nodes[0].Expand();
            Cursor.Current = Cursors.Default;
            ProjectTreeView.EndUpdate();
        }

        // RECURSIVE:
        private static void PopulateDirectoryNode(TreeNode baseNode, DirectoryInfo dir)
        {
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            TreeNode subNode;

            foreach (DirectoryInfo d in (from d in dirs orderby d.Name select d))
            {
                subNode = new TreeNode(d.Name, 1, 1) { Tag = "directory-node" };
                baseNode.Nodes.Add(subNode);
                PopulateDirectoryNode(subNode, d);
            }

            foreach (FileInfo f in (from f in files orderby f.Name select f))
            {
                subNode = new TreeNode(f.Name) { Tag = "file-node" };
                UpdateImage(subNode);
                baseNode.Nodes.Add(subNode);
            }
        }

        private static void UpdateImage(TreeNode node)
        {
            string pluginName = Core.GetFileOpenerName(node.Text);
            if (pluginName != null)
            {
                node.ImageKey = pluginName;
                node.SelectedImageKey = node.ImageKey;
            }
            else
            {
                node.ImageIndex = 3;
                node.SelectedImageIndex = node.ImageIndex;
            }
        }

        private void AddFolderItem_Click(object sender, EventArgs e)
        {
            using (var form = new StringInputForm("Create New Folder", "What do you want to name the new folder?"))
            {
                form.Input = "Untitled Folder";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string path = "";
                    if (ProjectTreeView.SelectedNode.Index == 0)
                    {
                        path = Path.Combine(Core.Project.RootPath, form.Input);
                    }
                    else
                    {
                        string toppath = ProjectTreeView.SelectedNode.FullPath;
                        toppath = toppath.Substring(toppath.IndexOf('\\'));
                        string rootpath = Core.Project.RootPath + toppath;
                        path = Path.Combine(rootpath, form.Input);
                    }

                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        TreeNode node = new TreeNode(form.Input, 2, 1) { Tag = "directory-node" };
                        ProjectTreeView.SelectedNode.Nodes.Add(node);
                    }
                    else
                    {
                        MessageBox.Show("Directory already exists!", "Directory Exists", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        /// <summary>
        /// Gets the full length real path of the tree node item.
        /// </summary>
        /// <param name="node">The node to resolve path from.</param>
        /// <returns>The full filepath the node corresponds to.</returns>
        private static string ResolvePath(TreeNode node)
        {
            var root = Core.Project.RootPath;
            var path = node.FullPath;
            var idx = path.IndexOf("\\");
            path = path.Substring(idx, path.Length - idx);
            return root + path;
        }

        private void ProjectTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null || e.Label == e.Node.Text) return;

            var oldpath = ResolvePath(e.Node);
            var oldroot = Path.GetDirectoryName(oldpath);
            var newpath = oldroot + "\\" + e.Label;

            var exists = File.Exists(newpath);
            var overwrite = false;

            if (exists)
            {
                overwrite = MessageBox.Show("Overwrite existing file?\n\n" + oldpath + "\n\nto:\n\n" + newpath, "File Replacement", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes;
                if (!overwrite)
                {
                    e.CancelEdit = true;
                    return;
                }
            }

            try
            {
                Pause();
                if (overwrite) File.Delete(newpath);
                File.Move(oldpath, newpath);
                Resume();
                
            }
            catch (Exception exc)
            {
                MessageBox.Show("Error in renaming file:\n" + exc.Message, "Rename Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CopyPathItem_Click(object sender, EventArgs e)
        {
            string text = ProjectTreeView.SelectedNode.FullPath.Replace('\\', '/');
            text = text.Substring(text.IndexOf('/') + 1);
            text = text.Substring(text.IndexOf('/') + 1);
            Clipboard.Clear();
            Clipboard.SetText(string.Format("\"{0}\"", text), TextDataFormat.Text);
        }

        private void ProjectTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if ((string)e.Node.Tag != "file-node")
            {
                e.CancelEdit = true;
            }
        }

        private void GameSettingsItem_Click(object sender, EventArgs e)
        {
            using (var settings = new ProjectPropsForm(Core.Project))
            {
                settings.ShowDialog();
            }
        }

        private void EngineSettingsItem_Click(object sender, EventArgs e)
        {
            _hostForm.OpenEditorSettings();
        }

        private void DeleteFolderItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ProjectTreeView.SelectedNode;
            string pathtop = node.FullPath.Substring(node.FullPath.IndexOf('\\'));
            string path = Core.Project.RootPath + pathtop;

            if (!Directory.Exists(path)) return;
            try
            {
                FileSystem.DeleteDirectory(path, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
            }
            catch (OperationCanceledException) { return; }
        }

        public void Close()
        {
            ProjectTreeView.Nodes.Clear();
            SystemWatcher.EnableRaisingEvents = false;
        }

        public void Open()
        {
            if (!string.IsNullOrEmpty(Core.Project.RootPath))
                SystemWatcher.Path = Core.Project.RootPath;
            else return;

            SystemWatcher.EnableRaisingEvents = true;
        }

        private void OpenItem(TreeNode node)
        {
            if (_hostForm == null || node == null) return;
            string pathtop = node.FullPath;

            int idx = pathtop.IndexOf('\\');
            if (idx < 0) return; // we're at root.

            pathtop = pathtop.Substring(idx);
            string path = Core.Project.RootPath + pathtop;

            // if the node is anything other than a file, don't do anything
            if ((string) node.Tag != "file-node") return;

            _hostForm.OpenFile(path);
        }

        private void OpenFileItem_Click(object sender, EventArgs e)
        {
            OpenItem(ProjectTreeView.SelectedNode);
        }

        private void ProjectTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OpenItem(ProjectTreeView.SelectedNode);
        }

        private void ProjectTreeView_KeyDown(object sender, KeyEventArgs e)
        {
            TreeNode node = ProjectTreeView.SelectedNode;
            if (node == null) return;
            switch (e.KeyCode)
            {
                case Keys.Return:
                    if (!node.Tag.Equals("file-node")) return;
                    OpenItem(ProjectTreeView.SelectedNode);
                    e.Handled = true;
                    break;
                case Keys.F2:
                    ProjectTreeView.SelectedNode.BeginEdit();
                    e.Handled = true;
                    break;
            }
        }
        
        private void ProjectTreeView_KeyPress(object sender, KeyPressEventArgs e)
        {
            // stops the beeping annoyance when user presses enter
            if (e.KeyChar == '\r') e.Handled = true;
        }

        private void SystemWatcher_Created(object sender, IEnumerable<FileSystemEventArgs> eAll)
        {
            Refresh();
        }
        
        private void SystemWatcher_Deleted(object sender, IEnumerable<FileSystemEventArgs> eAll)
        {
            Refresh();
        }

        private void SystemWatcher_Renamed(object sender, IEnumerable<FileSystemEventArgs> eAll)
        {
            Refresh();
        }

        public void ApplyStyle(UIStyle theme)
        {
            theme.AsTextView(ProjectTreeView);
        }

        private void OpenFolderItem_Click(object sender, EventArgs e)
        {
            if (ProjectTreeView.SelectedNode == null) return;
            string path = "";
            var node = ProjectTreeView.SelectedNode;

            if (node.Level == 0 && node.Index == 0)
                path = Core.Project.RootPath;
            else
                path = ResolvePath(node);

            Process.Start("explorer.exe", path);
        }

        private void ProjectFileContextMenu_Opening(object sender, CancelEventArgs e)
        {
        }
    }
}