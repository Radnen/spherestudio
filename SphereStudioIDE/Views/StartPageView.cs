using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using SphereStudio.Base;
using SphereStudio.Ide.Properties;

namespace SphereStudio.Ide.BuiltIns
{
    [ToolboxItem(false)]
    partial class StartPageView : DocumentView, IStyleAware
    {
        private Project project;
        private ListViewItem selectedItem;

        private readonly MainWindowForm _mainEditor;

        private readonly ImageList _listIcons = new ImageList();
        private readonly ImageList _listIconsSmall = new ImageList();

        public StartPageView(MainWindowForm mainEditor)
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);

            Icon = Icon.FromHandle(Resources.SphereEditor.GetHicon());

            _mainEditor = mainEditor;

            _listIcons.ImageSize = new Size(48, 48);
            _listIcons.ColorDepth = ColorDepth.Depth32Bit;
            _listIcons.Images.Add(Properties.Resources.SphereEditor);
            _listIconsSmall.ImageSize = new Size(16, 16);
            _listIconsSmall.ColorDepth = ColorDepth.Depth32Bit;
            _listIconsSmall.Images.Add(Properties.Resources.SphereEditor);
            projectListView.LargeImageList = _listIcons;
            projectListView.SmallImageList = _listIconsSmall;

            InitializeView();
        }

        public override bool CanSave { get { return false; } }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(this);
            style.AsHeading(header);

            style.AsTextView(projectListView);
        }

        private void InitializeView()
        {
            View v = Core.Settings.StartPageView;
            projectListView.View = v;
            TilesItem.Checked = false;
            switch (v)
            {
                case View.Details: DetailsItem.Checked = true; break;
                case View.Tile: TilesItem.Checked = true; break;
                case View.List: ListItem.Checked = true; break;
                case View.SmallIcon: SmallIconItem.Checked = true; break;
                case View.LargeIcon: LargeIconItem.Checked = true; break;
            }
        }

        public ToolStripLabel HelpLabel { get; set; }

        /// <summary>
        /// Adds Sphere games to the games panel for start-up use.
        /// </summary>
        public void RepopulateProjects()
        {
            projectListView.Items.Clear();
            projectListView.BeginUpdate();
            if (_listIcons.Images.Count == 0)
                return;
            var holdOnToMe = _listIcons.Images[0]; // keep this sucker alive.
            _listIcons.Images.Clear();
            _listIcons.Images.Add(holdOnToMe);

            // Search through a list of supplied directories.
            string projectsDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                "Sphere Projects");
            Directory.CreateDirectory(projectsDir);
            var paths = new List<string>(Core.Settings.ProjectPaths);
            paths.Insert(0, projectsDir);
            foreach (string path in paths)
            {
                if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
                    continue;
                var baseDir = new DirectoryInfo(path);
                var fileInfos = baseDir.GetFiles("*.ssproj", SearchOption.AllDirectories);
                var ssprojDirs = from fi in fileInfos
                                 select $@"{fi.DirectoryName}\";
                foreach (var fileInfo in fileInfos)
                {
                    var projectRoot = Path.GetDirectoryName(fileInfo.FullName);
                    var imageIndex = getImageIndex(projectRoot);
                    var proj = Project.Open(fileInfo.FullName);
                    var item = new ListViewItem(proj.Name, imageIndex) { Tag = fileInfo.FullName };
                    item.SubItems.Add(proj.Compiler);
                    item.SubItems.Add(proj.Author);
                    item.SubItems.Add(fileInfo.FullName);
                    projectListView.Items.Add(item);
                }
                var sgmFileInfos = from fi in baseDir.GetFiles("game.sgm", SearchOption.AllDirectories)
                                   where !ssprojDirs.Any(x => fi.FullName.StartsWith(x))
                                   select fi;
                foreach (var fileInfo in sgmFileInfos)
                {
                    var projectRoot = Path.GetDirectoryName(fileInfo.FullName);
                    var imageIndex = getImageIndex(projectRoot);
                    var proj = Project.Open(fileInfo.FullName);
                    var item = new ListViewItem(proj.Name, imageIndex) { Tag = fileInfo.FullName };
                    item.SubItems.Add("Sphere Classic");
                    item.SubItems.Add(proj.Author);
                    item.SubItems.Add(fileInfo.FullName);
                    projectListView.Items.Add(item);
                }
            }
            projectListView.EndUpdate();
            projectListView.Invalidate();
        }

        private void projectListView_MouseClick(object sender, MouseEventArgs e)
        {
            selectedItem = projectListView.GetItemAt(e.X, e.Y);
            if (selectedItem == null)
                return;
            project = Project.Open((string)selectedItem.Tag);
        }

        private async void PlayMenuItem_Click(object sender, EventArgs e)
        {
            await BuildEngine.Test(project);
        }

        private void LoadMenuItem_Click(object sender, EventArgs e)
        {
            if (selectedItem == null) return;
            _mainEditor.OpenProject((string)selectedItem.Tag);
        }

        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            selectedItem.BeginEdit();
        }

        private void projectListView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (string.IsNullOrEmpty(e.Label))
            {
                e.CancelEdit = true;
                return;
            }

            ListViewItem item = projectListView.Items[e.Item];
            string path = Path.GetDirectoryName(Path.GetDirectoryName(projectListView.Items[e.Item].Tag as string));

            if (System.IO.File.Exists($"{path}{e.Label}"))
                e.CancelEdit = true;
            else if (!RenameProject($@"{path}\{item.Text}", $@"{path}\{e.Label}"))
                e.CancelEdit = true;
        }

        private void projectListView_ItemActivate(object sender, EventArgs e)
        {
            selectedItem = projectListView.SelectedItems[0];
            if (selectedItem == null) return;
            _mainEditor.OpenProject((string)selectedItem.Tag);
        }

        private bool RenameProject(string oldname, string newname)
        {
            if (oldname == Core.Project.RootPath)
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
                string selPath = Path.GetDirectoryName((string)selectedItem.Tag);
                diag.Filter = @"image files (.png)|*.png";
                diag.InitialDirectory = selPath;

                if (diag.ShowDialog() == DialogResult.OK)
                {
                    if (diag.FileName == selPath + "\\icon.png") return;
                    if (System.IO.File.Exists(selPath + "\\icon.png")) System.IO.File.Delete(selPath + "\\icon.png");
                    System.IO.File.Copy(diag.FileName, selPath + "\\icon.png");

                    if (selectedItem.ImageIndex == 0)
                    {
                        _listIcons.Images.Add(Image.FromFile(selPath + "\\icon.png"));
                        selectedItem.ImageIndex = _listIcons.Images.Count - 1;
                    }
                    else
                    {
                        _listIcons.Images.RemoveAt(selectedItem.ImageIndex);
                        _listIcons.Images.Add(Image.FromFile(selPath + "\\icon.png"));
                        selectedItem.ImageIndex = _listIcons.Images.Count - 1;
                    }
                    RepopulateProjects();
                }
            }
        }

        private void TilesItem_Click(object sender, EventArgs e)
        {
            DetailsItem.Checked = ListItem.Checked = SmallIconItem.Checked = LargeIconItem.Checked = false;
            Core.Settings.StartPageView = projectListView.View = View.Tile;
        }

        private void ListItem_Click(object sender, EventArgs e)
        {
            DetailsItem.Checked = TilesItem.Checked = SmallIconItem.Checked = LargeIconItem.Checked = false;
            Core.Settings.StartPageView = projectListView.View = View.List;
        }

        private void SmallIconItem_Click(object sender, EventArgs e)
        {
            DetailsItem.Checked = TilesItem.Checked = ListItem.Checked = LargeIconItem.Checked = false;
            Core.Settings.StartPageView = projectListView.View = View.SmallIcon;
        }

        private void LargeIconItem_Click(object sender, EventArgs e)
        {
            DetailsItem.Checked = TilesItem.Checked = ListItem.Checked = SmallIconItem.Checked = false;
            Core.Settings.StartPageView = projectListView.View = View.LargeIcon;
        }

        private void DetailsItem_Click(object sender, EventArgs e)
        {
            ListItem.Checked = TilesItem.Checked = SmallIconItem.Checked = LargeIconItem.Checked = false;
            Core.Settings.StartPageView = projectListView.View = View.Details;
        }

        private void ItemContextStrip_Opening(object sender, CancelEventArgs e)
        {
            Point p = projectListView.PointToClient(Cursor.Position);
            selectedItem = projectListView.GetItemAt(p.X, p.Y);
            PlayGameItem.Visible = LoadMenuItem.Visible =
                RenameProjectItem.Visible = SetIconItem.Visible =
                OpenFolderItem.Visible = (selectedItem != null);
        }

        private void OpenFolderItem_Click(object sender, EventArgs e)
        {
            string path = Path.GetDirectoryName((string)selectedItem.Tag);
            Process p = Process.Start("explorer.exe", string.Format(@"/select,""{0}\game.sgm""", path));
            if (p != null) p.Dispose();
        }

        private void RefreshItem_Click(object sender, EventArgs e)
        {
            RepopulateProjects();
        }

        private int getImageIndex(string fullpath)
        {
            try
            {
                string[] files = Directory.GetFiles(fullpath);
                foreach (string s in files)
                {
                    if (s.ToUpperInvariant().EndsWith(".PNG"))
                    {
                        _listIcons.Images.Add(Image.FromFile(s));
                        _listIconsSmall.Images.Add(Image.FromFile(s));
                        return _listIcons.Images.Count - 1;
                    }
                    if (s.ToUpperInvariant().EndsWith(".ICO"))
                    {
                        _listIcons.Images.Add(new Icon(s));
                        _listIconsSmall.Images.Add(new Icon(s));
                        return _listIcons.Images.Count - 1;
                    }
                }
            }
            catch
            {
                return 0;
            }
            return 0;
        }
    }
}
