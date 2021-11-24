using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using SphereStudio.Base;
using SphereStudio.Utility;

namespace SphereStudio.Plugins.UI
{
    partial class AudioPlayerPane : UserControl, IDockPane, IFileOpener, IStyleAware
    {
        private readonly string[] _fileTypes = new[] 
        {
            "*.mp3:Music",
            "*.ogg:Music",
            "*.flac:Music",
            "*.mod:Music",
            "*.xm:Music",
            "*.it:Music",
            "*.s3d:Music",
            "*.s3m:Music",

            "*.wav:Sounds"
        };

        private readonly Color _labelColor = Color.FromArgb(0, 160, 255);
        private readonly Brush _trackBackColor;
        private readonly Brush _trackForeColor;
        private static DeferredFileSystemWatcher fileWatcher;
        private readonly ImageList playIcons = new ImageList();
        private readonly ImageList listIcons = new ImageList();
        private string musicName;
        private IPlayer player;

        public AudioPlayerPane(IPluginMain plugin)
        {
            InitializeComponent();
            StyleManager.AutoStyle(this);

            FileExtensions = new[]
            {
                "mp3", "ogg", "flac",      // compressed audio formats
                "mod", "it", "s3d", "s3m", // tracker formats
                "wav"                      // uncompressed/PCM formats
            };

            playIcons.ColorDepth = ColorDepth.Depth32Bit;
            playIcons.Images.Add("play", Properties.Resources.play_tool);
            playIcons.Images.Add("pause", Properties.Resources.pause_tool);
            playIcons.Images.Add("stop", Properties.Resources.stop_tool);
            listIcons.ColorDepth = ColorDepth.Depth32Bit;
            listIcons.Images.Add(Properties.Resources.Icon);

            fileWatcher = new DeferredFileSystemWatcher { SynchronizingObject = this, Delay = 1000 };
            fileWatcher.Changed += fileWatcher_Changed;
            fileWatcher.IncludeSubdirectories = true;
            fileWatcher.EnableRaisingEvents = false;
            WatchProject(PluginManager.Core.Project);
            listView.SmallImageList = listIcons;
            _trackBackColor = new SolidBrush(Color.FromArgb(125, _labelColor));
            _trackForeColor = new SolidBrush(_labelColor);
        }

        public bool ShowInViewMenu => true;
        public Control Control => this;
        public DockHint DockHint => DockHint.Left;
        public Bitmap DockIcon => Properties.Resources.Icon;

        public string FileTypeName => "Audio File";
        public Bitmap FileIcon => Properties.Resources.Icon;
        public string[] FileExtensions { get; private set; }

        public void ApplyStyle(UIStyle style)
        {
            style.AsUIElement(toolbar);
            style.AsTextView(listView);
        }

        public void ForcePause()
        {
            if (player == null)
                return;
            player.Pause();
            pauseTool.CheckState = CheckState.Checked;
            playTool.Image = playIcons.Images["pause"];
            playTool.Text = "Paused";
        }

        public DocumentView Open(string fileName)
        {
            bool isMusic = Path.GetExtension(fileName) != ".wav";
            IPlayer newPlayer;
            try
            {
                newPlayer = new IrrPlayer(fileName, isMusic);
            }
            catch (Exception)
            {
                MessageBox.Show("Audio Player was unable to play the track you selected.",
                    "Audio Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            newPlayer.Play();
            if (isMusic)
            {
                stopPlayback();
                musicName = Path.GetFileNameWithoutExtension(fileName);
                player = newPlayer;
                trackNameLabel.Text = $"BGM: {musicName}";
                playTool.Text = "Playing";
                playTool.Image = playIcons.Images["play"];
                pauseTool.Enabled = true;
                pauseTool.CheckState = CheckState.Unchecked;
                stopTool.Enabled = true;
            }
            return null;
        }

        public void WatchProject(IProject game)
        {
            if (game != null && game.RootPath != null)
            {
                fileWatcher.Path = game.RootPath;
                fileWatcher.EnableRaisingEvents = true;
            }
            else
            {
                fileWatcher.EnableRaisingEvents = false;
            }
            Refresh();
        }

        private void fileWatcher_Changed(object sender, IEnumerable<FileSystemEventArgs> eAll)
        {
            Refresh();
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem chosenItem = listView.SelectedItems[0];
            string filePath = (string)chosenItem.Tag;
            Open(filePath);
        }

        private void pauseTool_Click(object sender, EventArgs e)
        {
            playOrPause();
        }

        private void stopTool_Click(object sender, EventArgs e)
        {
            stopPlayback();
        }
        
        /// <summary>
        /// Toggles between the playing and pausing of the current music file.
        /// </summary>
        public void playOrPause()
        {
            if (player == null) return;
            player.PlayOrPause();
            pauseTool.CheckState = player.IsPaused ? CheckState.Checked : CheckState.Unchecked;
            playTool.Image = player.IsPaused ? playIcons.Images["pause"] : playIcons.Images["play"];
            playTool.Text = player.IsPaused ? "Paused" : "Playing";
        }

        public override void Refresh()
        {
            base.Refresh();
            if (PluginManager.Core.Project == null) { reset(); return; }

            string currentItemName = null;
            
            if (listView.SelectedItems.Count > 0)
                currentItemName = listView.SelectedItems[0].Text;
            
            listView.Items.Clear();
            listView.Groups.Clear();

            updateTrackList();

            if (!string.IsNullOrEmpty(currentItemName))
            {
                ListViewItem itemToSelect = listView.FindItemWithText(currentItemName);
                if (itemToSelect != null)
                    itemToSelect.Selected = true;
            }
        }

        /// <summary>
        /// Fills out the list with the music and sound files in your game path.
        /// </summary>
        private void updateTrackList()
        {
            string gamePath = PluginManager.Core.Project.RootPath;
            if (string.IsNullOrEmpty(gamePath))
                return;

            // if the project is set to build out-of-source, avoid enumerating the build directory.
            string buildPath = Path.Combine(gamePath, PluginManager.Core.Project.BuildPath)
                .Replace('/', Path.DirectorySeparatorChar)
                .Replace('\\', Path.DirectorySeparatorChar);
            if (buildPath.EndsWith(Path.DirectorySeparatorChar.ToString()))
                buildPath = buildPath.Substring(0, buildPath.Length - 1);
            bool haveBuildDir = Path.GetFullPath(buildPath) != Path.GetFullPath(gamePath);

            listView.BeginUpdate();
            foreach (string filterInfo in _fileTypes)
            {
                string[] parsedFilter = filterInfo.Split(':');
                string searchFilter = parsedFilter[0];
                string groupName = parsedFilter[1];
                
                listView.Groups.Add(groupName, groupName);

                try {
                    DirectoryInfo dirInfo = new DirectoryInfo(gamePath);
                    FileInfo[] fileInfos = dirInfo.GetFiles(searchFilter, SearchOption.AllDirectories);
                    foreach (FileInfo fi in from x in fileInfos
                                            where !x.FullName.StartsWith(buildPath) || !haveBuildDir
                                            orderby x.Name
                                            select x) {
                        var relativePath = fi.FullName
                            .Replace($"{gamePath}{Path.DirectorySeparatorChar}", string.Empty)
                            .Replace(Path.DirectorySeparatorChar, '/');
                        ListViewItem listItem = listView.Items.Add(Path.GetFileNameWithoutExtension(fi.FullName), 0);
                        listItem.Tag = (object)fi.FullName;
                        listItem.Group = listView.Groups[groupName];
                        listItem.SubItems.Add(relativePath);
                    }
                }
                catch {
                    // just pretend like nothing happened... :o)
                }
            }
            listView.EndUpdate();
        }

        public void reset()
        {
            stopPlayback();
            listView.Items.Clear();
            listView.Groups.Clear();
        }

        public void stopPlayback()
        {
            if (player != null) player.Dispose();

            trackNameLabel.Text = "-";
            playTool.Image = playIcons.Images["stop"];
            playTool.Text = "Stopped";
            pauseTool.CheckState = CheckState.Unchecked;
            pauseTool.Enabled = false;
            stopTool.Enabled = false;
        }

        private void playTimer_Tick(object sender, EventArgs e)
        {
            trackNameLabel.Invalidate();
        }

        private void trackNameLabel_MouseClick(object sender, MouseEventArgs e)
        {
            if (player == null)
                return;
            var delta = (double)e.X / trackNameLabel.Width;
            player.Position = (uint)(delta * player.Length);
        }

        private void trackNameLabel_Paint(object sender, PaintEventArgs e)
        {
            if (player == null) return;

            var width = trackNameLabel.Width;
            var height = trackNameLabel.Height;
            var delta = player.Position / (double)player.Length;

            e.Graphics.Clear(Color.Black);
            e.Graphics.FillRectangle(_trackBackColor, 0, 0, (int)(delta * width), height);
            e.Graphics.FillRectangle(_trackForeColor, (int)(delta * width), 0, 2, height);

            var textSize = e.Graphics.MeasureString(trackNameLabel.Text, trackNameLabel.Font);
            int x = width / 2 - (int)textSize.Width / 2;
            int y = trackNameLabel.Height / 2 - (int)textSize.Height / 2;

            e.Graphics.DrawString(trackNameLabel.Text, trackNameLabel.Font, Brushes.Black, x + 1, y + 1);
            e.Graphics.DrawString(trackNameLabel.Text, trackNameLabel.Font, _trackForeColor, x, y);
        }
    }
}
