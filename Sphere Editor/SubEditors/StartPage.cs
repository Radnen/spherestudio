using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Sphere_Editor.Settings;
using WeifenLuo.WinFormsUI.Docking;

namespace Sphere_Editor.SubEditors
{
    public partial class StartPage : UserControl
    {
        private ProjectSettings proj = new ProjectSettings();
        private ListViewItem current_item = null;
        private string sel_path = null;

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
        /// Adds sphere games to the list for start-up use.
        /// </summary>
        public void PopulateGameList()
        {
            GameFolders.Items.Clear();
            if (_imageicons.Images.Count == 0) return;
            Image hold_on_to_me = _imageicons.Images[0]; // keep this sucker alive.
            _imageicons.Images.Clear();
            _imageicons.Images.Add(hold_on_to_me);
            if (!Directory.Exists(Global.CurrentEditor.GamesPath)) return;

            DirectoryInfo games_dir = new DirectoryInfo(Global.CurrentEditor.GamesPath);
            Populate(games_dir);
        }

        private void Populate(DirectoryInfo base_dir)
        {
            DirectoryInfo[] dirs = base_dir.GetDirectories();
            foreach (DirectoryInfo d in dirs)
            {
                string filepath = d.FullName + "/game.sgm";
                if (!File.Exists(filepath)) { Populate(d); continue; }

                int img = CheckForIcon(d.FullName + "/icon.png");
                ListViewItem item = new ListViewItem(d.Name, img);
                item.Tag = filepath;
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

            DirectoryInfo dinfo = new DirectoryInfo(Global.CurrentEditor.GamesPath);
            _mainEditor.OpenProject((string)current_item.Tag);
        }

        private void GameFolders_MouseClick(object sender, MouseEventArgs e)
        {
            current_item = GameFolders.GetItemAt(e.X, e.Y);
            if (current_item != null)
            {
                DirectoryInfo dinfo = new DirectoryInfo(Global.CurrentEditor.GamesPath);
                proj.LoadData((string)current_item.Tag);
                SetProjData();
            }
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
                System.Diagnostics.Process.Start(Global.CurrentEditor.SpherePath, "-game \"" + proj.Path + "\"");
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
            sel_path = Global.CurrentEditor.GamesPath + "\\" + current_item.Text;
            _mainEditor.OpenProject(sel_path + "\\game.sgm");
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
                string path = Global.CurrentEditor.GamesPath + "\\";

                if (File.Exists(path + e.Label)) e.CancelEdit = true;
                else
                {
                    Directory.Move(path + item.Text, path + e.Label);
                    if (path + item.Text == Global.CurrentProject.Path)
                    {
                        Global.CurrentProject.Path = path + e.Label;
                        _mainEditor.RefreshProject(null, EventArgs.Empty);
                    }
                }
            }
        }

        private void SetIconItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog diag = new OpenFileDialog();
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
            PlayGameItem.Visible = LoadMenuItem.Visible = RenameProjectItem.Visible = SetIconItem.Visible = (current_item != null);
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
