using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere_Editor.Settings;
using Microsoft.VisualBasic.FileIO;
using System.Diagnostics;

namespace Sphere_Editor.SubEditors
{
    public partial class ProjectTree : UserControl
    {
        ToolTip tip = new ToolTip();
        public EditorForm EditorForm { get; set; }

        private ImageList _iconlist = new ImageList();

        public ProjectTree()
        {
            InitializeComponent();
            tip.ToolTipTitle = "Image";
            tip.ToolTipIcon = ToolTipIcon.Info;
            tip.UseFading = true;

            _iconlist.ColorDepth = ColorDepth.Depth32Bit;
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.SphereEditor);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.folder);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.folder_closed);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.page_white_edit);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.palette);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.script_edit);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.map);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.sound);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.style);
            _iconlist.Images.Add(Sphere_Editor.Properties.Resources.question_mark);

            ProjectTreeView.ImageList = _iconlist;
        }

        public string ProjectName
        {
            get { return ProjectNameLabel.Text; }
            set { ProjectNameLabel.Text = value; }
        }

        private void ImportFileItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Font Files (.rfn)|*.rfn|Image Files (.png, .gif, .jpg, .bmp)|*.png;*.gif;*.jpg;*.bmp|" +
                                    "Map Files (.rts, .rmp)|*.rmp;*.rts|Script Files (.js)|*.js|Sound Files (.wav, .mp3, .ogg, .mod, .it, .s3m, xm)|" +
                                    "*.wav;*.mp3;*.ogg;*.it;*.mod;*.xm;*.s3m|Spriteset Files (.rss)|*.rss|" +
                                    "Windowstyle Files (.rws)|*.rws|All Files|*.*";
            dialog.InitialDirectory = Global.CurrentProject.RootPath;
            TreeNode node = ProjectTreeView.SelectedNode;
            string pathtop = node.FullPath.Substring(node.FullPath.IndexOf('\\'));
            string path = Global.CurrentProject.RootPath + pathtop;
            string fullname = node.FullPath.ToLower();
            string name = fullname.Substring(fullname.IndexOf('\\')+1);

            name = Path.GetDirectoryName(node.FullPath.ToLower());

            if (name.Contains("\\")) name = name.Substring(0, name.IndexOf('\\'));
            int type = 8; // file type

            if (name == "fonts") type = 1;
            else if (name == "images") type = 2;
            else if (name == "maps") type = 3;
            else if (name == "scripts") type = 4;
            else if (name == "sounds") type = 5;
            else if (name == "spritesets") type = 6;
            else if (name == "windowstyles") type = 7;

            dialog.FilterIndex = type;
            dialog.Multiselect = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string newpath;
                TreeNode new_node;
                for(int i = 0; i < dialog.FileNames.Length; ++i)
                {
                    newpath = path + "\\" + dialog.SafeFileNames[i];
                    if (System.IO.File.Exists(newpath))
                    {
                        if (MessageBox.Show("File: " + dialog.FileNames[i] + " seems to exist.\nOverwrite destination?",
                            "Overwrite", MessageBoxButtons.YesNo, MessageBoxIcon.Warning,
                            MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                        {
                            System.IO.File.Copy(dialog.FileNames[i], newpath, true);
                        }
                    }
                    else
                    {
                        System.IO.File.Copy(dialog.FileNames[i], newpath, true);
                        new_node = new TreeNode(dialog.SafeFileNames[i]);
                        UpdateImage(new_node);
                    }
                }
            }

            dialog.Dispose();
            UpdateTree();
        }

        private void ProjectTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ProjectTreeView.SelectedNode = e.Node;

                OpenFileItem.Visible = DeleteFileItem.Visible = RenameFileItem.Visible = CopyPathItem.Visible = false;
                GameSettingsItem.Visible = EngineSettingsItem.Visible = false;
                NewFileItem.Visible = ImportFileItem.Visible = AddSubfolderItem.Visible = DeleteFolderItem.Visible = false;
                ExecuteScriptItem.Visible = false;

                // If the node is the name of the project: 
                if (Global.CurrentProject.RootPath.Contains(e.Node.Text))
                    GameSettingsItem.Visible = EngineSettingsItem.Visible = true;
                // If the node is a file object:
                else if (e.Node.Text.Contains("."))
                {
                    OpenFileItem.Visible = DeleteFileItem.Visible = RenameFileItem.Visible = CopyPathItem.Visible = true;
                    string s = e.Node.Text;
                    if (Global.IsScript(ref s)) ExecuteScriptItem.Visible = true;
                }
                // If the node is a folder object:
                else
                    NewFileItem.Visible = ImportFileItem.Visible = AddSubfolderItem.Visible = DeleteFolderItem.Visible = true;

                ProjectFileContextMenu.Show(ProjectTreeView, e.Location);
            }
        }

        private void RenameFileItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ProjectTreeView.SelectedNode;
            if (node.Text.Contains("."))
            {
                string text = ProjectTreeView.SelectedNode.Text;
                ProjectTreeView.SelectedNode.BeginEdit();
            }
        }

        private void DeleteFileItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ProjectTreeView.SelectedNode;
            string pathtop = node.FullPath.Substring(node.FullPath.IndexOf('\\'));
            string Path = Global.CurrentProject.RootPath + pathtop;

            if (System.IO.File.Exists(Path))
            {
                try
                {
                    FileSystem.DeleteFile(Path, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                }
                catch (OperationCanceledException)
                {
                    return;
                }
                UpdateTree();
            }
        }

        private void ProjectTreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex > 0) e.Node.ImageIndex = 1;
        }

        private void ProjectTreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            if (e.Node.ImageIndex > 0) e.Node.ImageIndex = 2;
        }

        /// <summary>
        /// Updates the contents of the tree.
        /// </summary>
        public void UpdateTree()
        {
            if (Global.CurrentProject.RootPath.Length == 0) return;

            Stopwatch watch = new Stopwatch();
            watch.Start();

            ProjectTreeView.Nodes.Clear();
            ProjectTreeView.Nodes.Add(new TreeNode(Global.CurrentProject.Name));
            DirectoryInfo BaseDir = new DirectoryInfo(SystemWatcher.Path);
            PopulateDirectoryNode(ProjectTreeView.Nodes[0], BaseDir);

            if (!ProjectTreeView.Nodes[0].IsExpanded) ProjectTreeView.Nodes[0].Toggle();

            watch.Stop();
            Console.WriteLine(Global.CurrentProject.Name + ": " + watch.Elapsed.TotalMilliseconds);
        }

        // RECURSIVE:
        private void PopulateDirectoryNode(TreeNode baseNode, DirectoryInfo dir)
        {
            DirectoryInfo[] dirs = dir.GetDirectories();
            FileInfo[] files = dir.GetFiles();
            TreeNode subNode;

            foreach (DirectoryInfo d in dirs)
            {
                subNode = new TreeNode(d.Name, 2, 1);
                baseNode.Nodes.Add(subNode);
                PopulateDirectoryNode(subNode, d);
            }

            for (int i = 0; i < files.Length; ++i)
            {
                subNode = new TreeNode(files[i].Name, 9, 9);
                UpdateImage(subNode);
                baseNode.Nodes.Add(subNode);
            }
        }

        private static void UpdateImage(TreeNode node)
        {
            string s = node.Text;
            if (Global.IsScript(ref s))
                node.SelectedImageIndex = node.ImageIndex = 5;
            else if (Global.IsFont(ref s))
                node.SelectedImageIndex = node.ImageIndex = 8;
            else if (Global.IsImage(ref s) || Global.IsSpriteset(ref s)
                || Global.IsWindowStyle(ref s))
                node.SelectedImageIndex = node.ImageIndex = 4;
            else if (Global.IsMap(ref s) || Global.IsTileset(ref s))
                node.SelectedImageIndex = node.ImageIndex = 6;
            else if (Global.IsSound(ref s))
                node.SelectedImageIndex = node.ImageIndex = 7;
            else if (Global.IsText(ref s))
                node.SelectedImageIndex = node.ImageIndex = 3;
            else node.SelectedImageIndex = node.ImageIndex = 9;
        }

        private void AddFolderItem_Click(object sender, EventArgs e)
        {
            using (Sphere_Editor.Forms.StringInputForm form = new Sphere_Editor.Forms.StringInputForm())
            {
                form.Input = "Untitled Folder";
                if (form.ShowDialog() == DialogResult.OK)
                {
                    string toppath = ProjectTreeView.SelectedNode.FullPath;
                    toppath = toppath.Substring(toppath.IndexOf('\\'));
                    string path = Global.CurrentProject.RootPath + toppath + "\\" + form.Input;
                    if (!Directory.Exists(path))
                    {
                        Directory.CreateDirectory(path);
                        ProjectTreeView.SelectedNode.Nodes.Add(new TreeNode(form.Input, 2, 1));
                    }
                }
            }
        }

        private void ProjectTreeView_AfterLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Label == null) { e.CancelEdit = true; return; }
            if (!e.Label.Contains(".") || e.Label.IndexOf('.') == 0) { e.CancelEdit = true; return; }
            
            string pathtop = e.Node.FullPath.Substring(e.Node.FullPath.IndexOf('\\'));
            string path = Global.CurrentProject.RootPath + pathtop;
            string newtop = pathtop.Substring(0, pathtop.LastIndexOf('\\'));
            string newpath = Global.CurrentProject.RootPath + newtop + "\\" + e.Label;

            if (File.Exists(newpath))
            {
                if (newpath.ToLower().Equals(path.ToLower()))
                {
                    File.Move(path, newpath + 2);
                    File.Move(newpath + 2, newpath);
                    e.Node.Name = e.Label;
                }
                else if (MessageBox.Show("Overwrite existing file?\n" + newpath, "File Replacement",
                         MessageBoxButtons.OKCancel, MessageBoxIcon.Warning,
                         MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    File.Delete(newpath);
                    File.Move(path, newpath);
                    e.Node.Remove();
                    e.Node.Name = e.Label;
                }
                else e.CancelEdit = true;
            }
            else
            {
                File.Move(path, newpath);
                e.Node.Name = e.Label;
            }
        }

        private void CopyPathItem_Click(object sender, EventArgs e)
        {
            ProjectTreeView.PathSeparator = "/";
            string text = ProjectTreeView.SelectedNode.FullPath;
            text = text.Substring(text.IndexOf('/')+1);
            text = text.Substring(text.IndexOf('/')+1);
            Clipboard.Clear();
            Clipboard.SetText("\"" + text + "\"", TextDataFormat.Text);
            ProjectTreeView.PathSeparator = "\\";
        }

        private void ProjectTreeView_BeforeLabelEdit(object sender, NodeLabelEditEventArgs e)
        {
            if (e.Node.ImageIndex < 3) { e.CancelEdit = true; return; }
        }

        private void GameSettingsItem_Click(object sender, EventArgs e)
        {
            using (GameSettings ViewSettings = new GameSettings(Global.CurrentProject))
            {
                if (ViewSettings.ShowDialog() == DialogResult.OK)
                {
                    Global.CurrentProject.SetData(ViewSettings);
                    Global.CurrentProject.SaveSettings();
                }
            }
        }

        private void EngineSettingsItem_Click(object sender, EventArgs e)
        {
            EditorForm.OpenEditorSettings(null, EventArgs.Empty);
        }

        private void NewFileItem_Click(object sender, EventArgs e)
        {
            if (EditorForm == null) return;
            TreeNode node = ProjectTreeView.SelectedNode;
            string fullname = node.FullPath.ToLower();
            string name = fullname.Substring(fullname.IndexOf('\\') + 1);
            if (name.Contains("\\")) name = name.Substring(0, name.IndexOf('\\'));

            if (name == "images") EditorForm.NewImage(null, EventArgs.Empty);
            else if (name == "maps") EditorForm.NewMap(null, EventArgs.Empty);
            else if (name == "fonts") EditorForm.NewFont(null, EventArgs.Empty);
            else if (name == "spritesets") EditorForm.NewSpriteset(null, EventArgs.Empty);
            else if (name == "windowstyles") EditorForm.NewWindowStyle(null, EventArgs.Empty);
            else EditorForm.NewScript(null, EventArgs.Empty);
        }

        // Assumption: The user knows the script has a game() function or the
        // script has required another script that includes a game() function.
        // Should we check if said script has a game function in it?
        private void ExecuteScriptItem_Click(object sender, EventArgs e)
        {
            // Write to file the current script:
            String old_script = Global.CurrentProject.Script;
            Global.CurrentProject.Script = ProjectTreeView.SelectedNode.Text;
            Global.CurrentProject.SaveSettings();
            // And then execute the engine:
            System.Diagnostics.Process.Start(Global.CurrentEditor.SpherePath, "-game \"" +
                Global.CurrentProject.RootPath + "\"");
            Global.CurrentProject.Script = old_script;
        }

        private void SystemWatcher_Changed(object sender, FileSystemEventArgs e)
        {
            UpdateTree();
        }

        private void DeleteFolderItem_Click(object sender, EventArgs e)
        {
            TreeNode node = ProjectTreeView.SelectedNode;
            string pathtop = node.FullPath.Substring(node.FullPath.IndexOf('\\'));
            string Path = Global.CurrentProject.RootPath + pathtop;

            if (MessageBox.Show("Are you sure you want to delete:\n" + Path,
                "Confirm File Deletion", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button3) == DialogResult.Yes)
            {
                if (Directory.Exists(Path))
                {
                    FileSystem.DeleteDirectory(Path, UIOption.AllDialogs, RecycleOption.SendToRecycleBin);
                    node.Remove();
                }
            }

        }

        public void Close()
        {
            ProjectTreeView.Nodes.Clear();
            SystemWatcher.EnableRaisingEvents = false;
        }

        public void Open()
        {
            if (!string.IsNullOrEmpty(Global.CurrentProject.RootPath))
                SystemWatcher.Path = Global.CurrentProject.RootPath;

            SystemWatcher.EnableRaisingEvents = true;
        }

        private void OpenItem(TreeNode node)
        {
            if (EditorForm == null) return;
            string pathtop = node.FullPath;
            
            int idx = pathtop.IndexOf('\\');
            if (idx < 0) return; // we're at root.

            pathtop = pathtop.Substring(idx);
            string path = Global.CurrentProject.RootPath + pathtop;

            string s = node.Text;

            if (EditorForm.ContainsDocument(Path.GetFileName(path)))
            {
                EditorForm.SelectDocument(Path.GetFileName(path));
                return;
            }

            if (Global.IsImage(ref s)) EditorForm.OpenImage(path);
            else if (Global.IsMap(ref s)) EditorForm.OpenMap(path);
            else if (Global.IsSound(ref s)) EditorForm.OpenSound(path);
            else if (Global.IsFont(ref s)) EditorForm.OpenFont(path);
            else if (Global.IsSpriteset(ref s)) EditorForm.OpenSpriteset(path);
            else if (Global.IsWindowStyle(ref s)) EditorForm.OpenWindowStyle(path);
            else if (s.Contains(".")) EditorForm.OpenScript(path);
        }
        
        private void OpenFileItem_Click(object sender, EventArgs e)
        {
            OpenItem(ProjectTreeView.SelectedNode);
        }
        
        private void ProjectTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            OpenItem(e.Node);
        }
    }
}
