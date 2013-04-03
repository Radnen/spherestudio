using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Sphere_Editor.Settings;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class StartPage : UserControl
    {
        private ProjectSettings proj = new ProjectSettings();
        private ListViewItem current_item = null;

        private DockPanel StartDock = new DockPanel();
        private DockContent GameContent = new DockContent();
        private DockContent InfoContent = new DockContent();
        private EditorForm _mainEditor;

        private ImageList _imageicons = new ImageList();

        public StartPage(EditorForm mainEditor)
        {
            InitializeComponent();
            InitializeDocking();

            if (Global.CurrentEditor.UseDockForm) this.Controls.Remove(MainSplitter);
            _mainEditor = mainEditor;

            _imageicons.ImageSize = new System.Drawing.Size(32, 32);
            _imageicons.ColorDepth = ColorDepth.Depth32Bit;
            _imageicons.Images.Add(Sphere_Editor.Properties.Resources.SphereEditor);
            GameFolders.LargeImageList = _imageicons;

            InitializeView();
        }

        private void InitializeDocking()
        {
            if (!Global.CurrentEditor.UseDockForm) return;
            StartDock.DocumentStyle = DocumentStyle.DockingWindow;
            StartDock.Dock = DockStyle.Fill;
            Controls.Add(StartDock);

            GamesPanel.Dock = InfoPanel.Dock = DockStyle.Fill;
            GameContent.Controls.Add(GamesPanel);
            GameContent.DockAreas = DockAreas.DockTop | DockAreas.DockBottom | DockAreas.Document;
            GameContent.AllowEndUserDocking = false;
            GameContent.DockHandler.CloseButtonVisible = false;
            GameContent.Text = "Local Projects";
            InfoContent.Controls.Add(InfoPanel);
            InfoContent.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight;
            InfoContent.Text = "Game Information";

            GameContent.Show(StartDock, DockState.Document);
            InfoContent.Show(StartDock, DockState.DockBottom);
        }

        private void InitializeView()
        {
            View v = Global.CurrentEditor.StartView;
            GameFolders.View = v;
            TilesItem.Checked = false;
            switch (v)
            {
                case View.Tile: TilesItem.Checked = true; break;
                case View.List: ListItem.Checked = true; break;
                case View.SmallIcon: SmallIconItem.Checked = true; break;
                case View.LargeIcon: LargeIconItem.Checked = true; break;
            }
        }

        public ToolStripLabel HelpLabel { get; set; }

        /// <summary>
        /// Adds sphere games to the games panel for start-up use.
        /// </summary>
        public void PopulateGameList()
        {
            GameFolders.Items.Clear();
            if (_imageicons.Images.Count == 0) return;
            Image hold_on_to_me = _imageicons.Images[0]; // keep this sucker alive.
            _imageicons.Images.Clear();
            _imageicons.Images.Add(hold_on_to_me);

            // Search through a list of supplied directories.
            string[] paths = Global.CurrentEditor.GetGamePaths();
            foreach (string s in paths)
            {
                DirectoryInfo d = new DirectoryInfo(s);
                Populate(d);
                string path = d.FullName + "/game.sgm";

                // search this folder for game:
                if (File.Exists(path))
                {
                    int img = CheckForIcon(d.FullName + "/icon.png");
                    ListViewItem item = new ListViewItem(d.Name, img);
                    item.Tag = path;
                    GameFolders.Items.Add(item);
                }
            }
        }

        /// <summary>
        /// Searches the subfolders of /base_dir/ for games
        /// to add to the games panel.
        /// </summary>
        /// <param name="base_dir">Directory to start looking from.</param>
        private void Populate(DirectoryInfo base_dir)
        {
            DirectoryInfo[] dirs = base_dir.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                string path = d.FullName + "/game.sgm";
                if (!File.Exists(path)) { Populate(d); continue; }
                int img = CheckForIcon(d.FullName + "/icon.png");
                ListViewItem item = new ListViewItem(d.Name, img);
                item.Tag = path;
                GameFolders.Items.Add(item);
            }
        }

        private int CheckForIcon(string fullpath)
        {
            if (File.Exists(fullpath))
            {
                _imageicons.Images.Add(Image.FromFile(fullpath));
                return _imageicons.Images.Count-1;
            }
            return 0;
        }

        private void GameFolders_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            current_item = GameFolders.GetItemAt(e.X, e.Y);
            if (current_item == null) return;
            _mainEditor.OpenProject((string)current_item.Tag);
        }

        private void GameFolders_MouseClick(object sender, MouseEventArgs e)
        {
            current_item = GameFolders.GetItemAt(e.X, e.Y);
            if (current_item == null) return;
            proj.LoadSettings((string)current_item.Tag);
            SetProjData();
        }

        public void SetProjData()
        {
            NameLabel.Text = "Name: " + proj.Name;
            AuthorLabel.Text = "Author: " + proj.Author;
            SizeLabel.Text = "Resolution: " + proj.Width.ToString() + "x" + proj.Height.ToString();
            DescTextLabel.Text = proj.Description;
        }

        private void PlayMenuItem_Click(object sender, EventArgs e)
        {
            if (Global.CurrentEditor.SpherePath != "")
            {
                System.Diagnostics.Process.Start(Global.CurrentEditor.SpherePath, "-game \"" + proj.RootPath + "\"");
            }
            else
            {
                if (MessageBox.Show("Invalid Sphere Engine Path! Find Path?", "Invalid Path",
                    MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    EditorForm MainForm = ((EditorForm)Parent.Parent.Parent);
                    MainForm.OpenEditorSettings(null, EventArgs.Empty);
                }
            }
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            if (current_item == null) return;
            _mainEditor.OpenProject((string)current_item.Tag);
        }

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            current_item.BeginEdit();
        }

        private void GameFolders_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (e.Label == null || e.Label == "") e.CancelEdit = true;
            else
            {
                ListViewItem item = GameFolders.Items[e.Item];
                string path = Path.GetDirectoryName(GameFolders.Items[e.Item].Tag as string);

                if (File.Exists(path + e.Label)) e.CancelEdit = true;
                else
                {
                    Directory.Move(path + item.Text, path + e.Label);
                    if (path + item.Text == Global.CurrentProject.RootPath)
                    {
                        Global.CurrentProject.RootPath = path + e.Label;
                        _mainEditor.RefreshProject(null, EventArgs.Empty);
                    }
                }
            }
        }

        private void SetIconItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                string sel_path = Path.GetDirectoryName((string)current_item.Tag);
                diag.Filter = "image files (.png)|*.png";
                diag.InitialDirectory = sel_path;

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    if (diag.FileName == sel_path + "\\icon.png") return;
                    if (File.Exists(sel_path + "\\icon.png")) File.Delete(sel_path + "\\icon.png");
                    File.Copy(diag.FileName, sel_path + "\\icon.png");

                    if (current_item.ImageIndex == 0)
                    {
                        _imageicons.Images.Add(Image.FromFile(sel_path + "\\icon.png"));
                        current_item.ImageIndex = _imageicons.Images.Count - 1;
                    }
                    else
                    {
                        _imageicons.Images.RemoveAt(current_item.ImageIndex);
                        _imageicons.Images.Add(Image.FromFile(sel_path + "\\icon.png"));
                        current_item.ImageIndex = _imageicons.Images.Count - 1;
                    }
                    PopulateGameList();
                }
            }
        }

        private void TilesItem_Click(object sender, EventArgs e)
        {
            ListItem.Checked = SmallIconItem.Checked = LargeIconItem.Checked = false;
            Global.CurrentEditor.StartView = GameFolders.View = View.Tile;
        }

        private void ListItem_Click(object sender, EventArgs e)
        {
            TilesItem.Checked = SmallIconItem.Checked = LargeIconItem.Checked = false;
            Global.CurrentEditor.StartView = GameFolders.View = View.List;
        }

        private void SmallIconItem_Click(object sender, EventArgs e)
        {
            TilesItem.Checked = ListItem.Checked = LargeIconItem.Checked = false;
            Global.CurrentEditor.StartView = GameFolders.View = View.SmallIcon;
        }

        private void LargeIconItem_Click(object sender, EventArgs e)
        {
            TilesItem.Checked = ListItem.Checked = SmallIconItem.Checked = false;
            Global.CurrentEditor.StartView = GameFolders.View = View.LargeIcon;
        }

        private void ItemContextStrip_Opening(object sender, CancelEventArgs e)
        {
            Point p = GameFolders.PointToClient(Cursor.Position);
            current_item = GameFolders.GetItemAt(p.X, p.Y);
            PlayGameItem.Visible = LoadMenuItem.Visible =
                RenameProjectItem.Visible = SetIconItem.Visible =
                    OpenFolderItem.Visible = (current_item != null);
        }

        private void OpenFolderItem_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName((string)current_item.Tag);
            Process p = Process.Start("explorer.exe", string.Format("/select,\"{0}\\game.sgm\"", path));
            p.Dispose();
        }

        private void RefreshItem_Click(object sender, EventArgs e)
        {
            PopulateGameList();
        }

        #region tip texts
        private void ClearTip(object sender, EventArgs e)
        {
            HelpLabel.Text = "";
        }

        private void GameFolders_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "Right-click to view context menu.";
        }

        private void SetIconItem_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "Sets a project icon mainly for the editors use.";
        }

        private void InfoPanel_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = "These are the games properties stored in their \"game.sgm\" file.";
        }
        #endregion
    }
}
