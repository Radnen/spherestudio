using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Sphere.Core.Editor;
using Sphere.Plugins;
using Sphere.Plugins.Interfaces;
using Sphere.Plugins.Views;

namespace SphereStudio.Plugins
{
    partial class SoundPicker : UserControl, IDockPane, IStyleable
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
            
            "*.wav:Sounds"
        };

        private readonly Color _labelColor = Color.FromArgb(0, 160, 255);
        private readonly Brush _trackBackColor;
        private readonly Brush _trackForeColor;
        private static DeferredFileSystemWatcher _fileWatcher;
        private readonly ImageList _playIcons = new ImageList();
        private readonly ImageList _listIcons = new ImageList();
        private IPlayer _music;
        private string _musicName;

        public SoundPicker(IPluginMain plugin)
        {
            InitializeComponent();

            _playIcons.ColorDepth = ColorDepth.Depth32Bit;
            _playIcons.Images.Add("play", Properties.Resources.play_tool);
            _playIcons.Images.Add("pause", Properties.Resources.pause_tool);
            _playIcons.Images.Add("stop", Properties.Resources.stop_tool);
            _listIcons.ColorDepth = ColorDepth.Depth32Bit;
            _listIcons.Images.Add(Properties.Resources.Icon);

            _fileWatcher = new DeferredFileSystemWatcher { SynchronizingObject = this, Delay = 1000 };
            _fileWatcher.Changed += fileWatcher_Changed;
            _fileWatcher.IncludeSubdirectories = true;
            _fileWatcher.EnableRaisingEvents = false;
            WatchProject(PluginManager.Core.Project);
            trackList.SmallImageList = _listIcons;
            _trackBackColor = new SolidBrush(Color.FromArgb(125, _labelColor));
            _trackForeColor = new SolidBrush(_labelColor);
        }

        public Control Control { get { return this; } }

        public DockHint DockHint { get { return DockHint.Left; } }

        public Bitmap DockIcon { get { return Properties.Resources.Icon; } }

        public bool ShowInViewMenu { get { return true; } }

        private void fileWatcher_Changed(object sender, IEnumerable<FileSystemEventArgs> eAll)
        {
            Refresh();
        }

        private void pauseTool_Click(object sender, EventArgs e)
        {
            PlayOrPauseMusic();
        }

        private void stopTool_Click(object sender, EventArgs e)
        {
            StopMusic();
        }

        private void trackList_Click(object sender, EventArgs e)
        {
        }
        
        private void trackList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem chosenItem = trackList.SelectedItems[0];
            string filePath = (string)chosenItem.Tag;
            PlayFile(filePath);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            UpdateStyle();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            UpdateStyle();
        }

        public void UpdateStyle()
        {
            StyleSettings.ApplyStyle(toolbar);
            StyleSettings.ApplySecondaryStyle(trackList);
        }

        /// <summary>
        /// Used by filesystem watcher to attempt to automatically
        /// add new additions to the sound list.
        /// </summary>
        /// <param name="game"></param>
        public void WatchProject(IProject game)
        {
            if (game != null && game.RootPath != null)
            {
                _fileWatcher.Path = game.RootPath;
                _fileWatcher.EnableRaisingEvents = true;
            }
            else
            {
                _fileWatcher.EnableRaisingEvents = false;
            }
            Refresh();
        }

        /// <summary>
        /// Forces pause on songs.
        /// </summary>
        public void ForcePause()
        {
            if (_music == null) return;
            _music.Pause();
            pauseTool.CheckState = CheckState.Checked;
            playTool.Image = _playIcons.Images["pause"];
            playTool.Text = @"Paused";
        }

        /// <summary>
        /// Plays the song or sound located at the path's location.
        /// </summary>
        /// <param name="path">The full path of the file to play.</param>
        public void PlayFile(string path)
        {
            bool isMusic = Path.GetExtension(path) != ".wav";
            IPlayer music;
            try
            {
                try { music = new IrrPlayer(path, isMusic); }
                catch (Exception) { music = new NAudioPlayer(path, isMusic); }
            }
            catch (Exception)
            {
                MessageBox.Show("Sound Test was unable to play the track you selected. The format may not be supported on your system.",
                    "Audio Playback Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            music.Play();
            if (isMusic)
            {
                StopMusic();
                _musicName = Path.GetFileNameWithoutExtension(path);
                _music = music;
                trackNameLabel.Text = @"Now Playing: " + _musicName;
                playTool.Text = @"Playing";
                playTool.Image = _playIcons.Images["play"];
                pauseTool.Enabled = true;
                pauseTool.CheckState = CheckState.Unchecked;
                stopTool.Enabled = true;
            }
        }

        /// <summary>
        /// Toggles between the playing and pausing of the current music file.
        /// </summary>
        public void PlayOrPauseMusic()
        {
            if (_music == null) return;
            _music.PlayOrPause();
            pauseTool.CheckState = _music.IsPaused ? CheckState.Checked : CheckState.Unchecked;
            playTool.Image = _music.IsPaused ? _playIcons.Images["pause"] : _playIcons.Images["play"];
            playTool.Text = _music.IsPaused ? "Paused" : "Playing";
        }

        /// <summary>
        /// Overrides the refresh method to re-add the music and sounds
        /// found in your project.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();
            if (PluginManager.Core.Project == null) { Reset(); return; }

            string currentItemName = null;
            
            if (trackList.SelectedItems.Count > 0)
                currentItemName = trackList.SelectedItems[0].Text;
            
            trackList.Items.Clear();
            trackList.Groups.Clear();

            UpdateTrackList();

            if (!string.IsNullOrEmpty(currentItemName))
            {
                ListViewItem itemToSelect = trackList.FindItemWithText(currentItemName);
                if (itemToSelect != null)
                    itemToSelect.Selected = true;
            }
        }

        /// <summary>
        /// Fills out the list with the music and sound files in your game path.
        /// </summary>
        private void UpdateTrackList()
        {
            string gamePath = PluginManager.Core.Project.RootPath;
            if (string.IsNullOrEmpty(gamePath)) return;

            trackList.BeginUpdate();
            foreach (string filterInfo in _fileTypes)
            {
                string[] parsedFilter = filterInfo.Split(':');
                string searchFilter = parsedFilter[0];
                string groupName = parsedFilter[1];
                
                trackList.Groups.Add(groupName, groupName);

                DirectoryInfo dirInfo = new DirectoryInfo(gamePath);
                FileInfo[] fileInfos = dirInfo.GetFiles(searchFilter, SearchOption.AllDirectories);

                foreach (FileInfo f in from f in fileInfos orderby f.Name select f)
                {
                    ListViewItem listItem = trackList.Items.Add(Path.GetFileNameWithoutExtension(f.FullName), 0);
                    listItem.Tag = (object)f.FullName;
                    listItem.Group = trackList.Groups[groupName];
                    listItem.SubItems.Add(f.FullName.Replace(gamePath + "\\", ""));
                }
            }
            trackList.EndUpdate();
        }

        /// <summary>
        /// Resets the sound engine and clears the playlist.
        /// </summary>
        public void Reset()
        {
            StopMusic();
            trackList.Items.Clear();
            trackList.Groups.Clear();
        }

        /// <summary>
        /// Stops any currently playing music
        /// </summary>
        public void StopMusic()
        {
            if (_music != null) _music.Dispose();

            trackNameLabel.Text = @"-";
            playTool.Image = _playIcons.Images["stop"];
            playTool.Text = @"Stopped";
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
            if (_music == null) return;
            double delta = (double)e.X / trackNameLabel.Width;
            _music.Position = (uint)(delta * _music.Length);
        }

        private void trackNameLabel_Paint(object sender, PaintEventArgs e)
        {
            if (_music == null) return;

            int width = trackNameLabel.Width;
            int height = trackNameLabel.Height;
            double delta = _music.Position / (double)_music.Length;

            e.Graphics.Clear(Color.Black);
            e.Graphics.FillRectangle(_trackBackColor, 0, 0, (int)(delta * width), height);
            e.Graphics.FillRectangle(_trackForeColor, (int)(delta * width), 0, 2, height);

            SizeF textsize = e.Graphics.MeasureString(trackNameLabel.Text, trackNameLabel.Font);
            int x = width / 2 - (int)textsize.Width / 2;
            int y = trackNameLabel.Height / 2 - (int)textsize.Height / 2;

            e.Graphics.DrawString(trackNameLabel.Text, trackNameLabel.Font, Brushes.Black, x + 1, y + 1);
            e.Graphics.DrawString(trackNameLabel.Text, trackNameLabel.Font, _trackForeColor, x, y);
        }
    }
}
