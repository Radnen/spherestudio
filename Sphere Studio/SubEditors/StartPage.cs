using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using Sphere.Core.Settings;
using WeifenLuo.WinFormsUI.Docking;

namespace SphereStudio.SubEditors
{
    public partial class StartPage : UserControl
    {
        private readonly ProjectSettings _proj = new ProjectSettings();
        private ListViewItem _currentItem;

        private readonly DockPanel _startDock = new DockPanel();
        private readonly DockContent _gameContent = new DockContent();
        private readonly DockContent _infoContent = new DockContent();
        private readonly IDEForm _mainEditor;

        private readonly ImageList _imageicons = new ImageList();

        public StartPage(IDEForm mainEditor)
        {
            InitializeComponent();
            InitializeDocking();

            _mainEditor = mainEditor;

            _imageicons.ImageSize = new Size(32, 32);
            _imageicons.ColorDepth = ColorDepth.Depth32Bit;
            _imageicons.Images.Add(Properties.Resources.SphereEditor);
            GameFolders.LargeImageList = _imageicons;

            InitializeView();
        }

        private void InitializeDocking()
        {
            Controls.Remove(MainSplitter);
            _startDock.DocumentStyle = DocumentStyle.DockingWindow;
            _startDock.Dock = DockStyle.Fill;
            Controls.Add(_startDock);

            GamesPanel.Dock = InfoPanel.Dock = DockStyle.Fill;
            _gameContent.Controls.Add(GamesPanel);
            _gameContent.DockAreas = DockAreas.DockTop | DockAreas.DockBottom | DockAreas.Document;
            _gameContent.AllowEndUserDocking = false;
            _gameContent.DockHandler.CloseButtonVisible = false;
            _gameContent.Text = @"Local Projects";
            _infoContent.Controls.Add(InfoPanel);
            _infoContent.DockAreas = DockAreas.DockBottom | DockAreas.DockLeft | DockAreas.DockRight;
            _infoContent.Text = @"Game Information";

            _gameContent.Show(_startDock, DockState.Document);
            _infoContent.Show(_startDock, DockState.DockBottom);
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
            GameFolders.BeginUpdate();
            if (_imageicons.Images.Count == 0) return;
            Image holdOnToMe = _imageicons.Images[0]; // keep this sucker alive.
            _imageicons.Images.Clear();
            _imageicons.Images.Add(holdOnToMe);

            // Search through a list of supplied directories.
            string[] paths = Global.CurrentEditor.GetArray("games_path");
            foreach (string s in paths)
            {
                if (string.IsNullOrEmpty(s)) continue;
                if (!Directory.Exists(s)) continue;
                DirectoryInfo d = new DirectoryInfo(s);
                Populate(d);
                string path = d.FullName + "/game.sgm";

                // search this folder for game:
                if (!File.Exists(path)) continue;

                int img = CheckForIcon(d.FullName);
                ListViewItem item = new ListViewItem(d.Name, img) {Tag = path};
                GameFolders.Items.Add(item);
            }
            GameFolders.EndUpdate();
            GameFolders.Invalidate();
        }

        /// <summary>
        /// Searches the subfolders of /base_dir/ for games
        /// to add to the games panel.
        /// </summary>
        /// <param name="baseDir">Directory to start looking from.</param>
        private void Populate(DirectoryInfo baseDir)
        {
            DirectoryInfo[] dirs = baseDir.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                string path = d.FullName + "/game.sgm";
                if (!File.Exists(path)) { Populate(d); continue; }
                int img = CheckForIcon(d.FullName);
                ListViewItem item = new ListViewItem(d.Name, img) {Tag = path};
                GameFolders.Items.Add(item);
            }
        }

        private int CheckForIcon(string fullpath)
        {
            string[] files = Directory.GetFiles(fullpath);
            foreach (string s in files)
            {
                if (s.EndsWith(".png"))
                {
                    _imageicons.Images.Add(Image.FromFile(s));
                    return _imageicons.Images.Count - 1;
                }
                if (s.EndsWith(".ico"))
                {
                    _imageicons.Images.Add(new Icon(s));
                    return _imageicons.Images.Count - 1;
                }
            }
            return 0;
        }

        private void GameFolders_MouseClick(object sender, MouseEventArgs e)
        {
            _currentItem = GameFolders.GetItemAt(e.X, e.Y);
            if (_currentItem == null) return;
            _proj.LoadSettings((string)_currentItem.Tag);
            SetProjData();
        }

        public void SetProjData()
        {
            NameLabel.Text = @"Name: " + _proj.Name;
            AuthorLabel.Text = @"Author: " + _proj.Author;
            SizeLabel.Text = string.Format(@"Resolution: {0}x{1}", _proj.Width, _proj.Height);
            DescTextLabel.Text = _proj.Description;
        }

        private void PlayMenuItem_Click(object sender, EventArgs e)
        {
            if (!File.Exists(Global.CurrentEditor.SpherePath)) return;
            string args = string.Format("-game\"{0}\"", _proj.RootPath);
            Process.Start(Global.CurrentEditor.SpherePath, args);
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            if (_currentItem == null) return;
            _mainEditor.OpenProject((string)_currentItem.Tag);
        }

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            _currentItem.BeginEdit();
        }

        private void GameFolders_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            ListViewItem item = GameFolders.Items[e.Item];
            string path = Path.GetDirectoryName(Path.GetDirectoryName(GameFolders.Items[e.Item].Tag as string));

            if (File.Exists(path + e.Label)) e.CancelEdit = true;
            else if (!RenameProject(path + "\\" + item.Text, path + "\\" + e.Label))
            {
                e.CancelEdit = true;
            }
        }

        private bool RenameProject(string oldname, string newname)
        {
            if (oldname == Global.CurrentProject.RootPath)
            {
                MessageBox.Show(@"Can't change name of active project.", @"Name Change", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Directory.Move(oldname, newname);
            return true;
        }

        private void SetIconItem_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog diag = new OpenFileDialog())
            {
                string selPath = Path.GetDirectoryName((string)_currentItem.Tag);
                diag.Filter = @"image files (.png)|*.png";
                diag.InitialDirectory = selPath;

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    if (diag.FileName == selPath + "\\icon.png") return;
                    if (File.Exists(selPath + "\\icon.png")) File.Delete(selPath + "\\icon.png");
                    File.Copy(diag.FileName, selPath + "\\icon.png");

                    if (_currentItem.ImageIndex == 0)
                    {
                        _imageicons.Images.Add(Image.FromFile(selPath + "\\icon.png"));
                        _currentItem.ImageIndex = _imageicons.Images.Count - 1;
                    }
                    else
                    {
                        _imageicons.Images.RemoveAt(_currentItem.ImageIndex);
                        _imageicons.Images.Add(Image.FromFile(selPath + "\\icon.png"));
                        _currentItem.ImageIndex = _imageicons.Images.Count - 1;
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
            _currentItem = GameFolders.GetItemAt(p.X, p.Y);
            PlayGameItem.Visible = LoadMenuItem.Visible =
                RenameProjectItem.Visible = SetIconItem.Visible =
                    OpenFolderItem.Visible = (_currentItem != null);
            PlayGameItem.Visible = !string.IsNullOrEmpty(Global.CurrentEditor.SpherePath);
        }

        private void OpenFolderItem_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName((string)_currentItem.Tag);
            Process p = Process.Start("explorer.exe", string.Format("/select,\"{0}\\game.sgm\"", path));
            if (p != null) p.Dispose();
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
            HelpLabel.Text = @"Right-click to view context menu.";
        }

        private void SetIconItem_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"Sets a project icon mainly for the editors use.";
        }

        private void InfoPanel_MouseEnter(object sender, EventArgs e)
        {
            HelpLabel.Text = @"These are the games properties stored in their ""game.sgm"" file.";
        }
        #endregion

        private void GameFolders_ItemActivate(object sender, EventArgs e)
        {
            _currentItem = GameFolders.SelectedItems[0];
            if (_currentItem == null) return;
            _mainEditor.OpenProject((string)_currentItem.Tag);

            /*if (current_item != null && File.Exists((string)current_item.Tag))
            {
                GameFolders.Items.Remove(current_item);
                current_item = null;
            }*/
        }

    }
}
