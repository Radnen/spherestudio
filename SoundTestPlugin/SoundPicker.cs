using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Sphere.Core;
using Sphere.Core.Editor;
using Sphere.Core.Settings;
using Sphere.Plugins;

using IrrKlang;

namespace SoundTestPlugin
{
    public partial class SoundPicker : UserControl
    {
        private readonly string[] _fileTypes = new string[] 
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

        private IPlugin _plugin;
        private static DeferredFileSystemWatcher _fileWatcher;
        private ImageList playIcons = new ImageList();
        private ISoundEngine _soundEngine = new ISoundEngine();
        private ISound _music;
        private string _musicName;

        delegate void SafeRefresh();
        SafeRefresh MySafeRefresh;

        private void fileWatcher_EventRaised(object sender, IEnumerable<EventArgs> eList)
        {
            Invoke(MySafeRefresh);
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
            ListViewItem chosenItem = trackList.SelectedItems[0];
        }
        
        private void trackList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem chosenItem = trackList.SelectedItems[0];
            string filePath = (string)chosenItem.Tag;
            PlayFile(filePath);
        }

        public SoundPicker(IPlugin plugin)
        {
            InitializeComponent();

            playIcons.ColorDepth = ColorDepth.Depth32Bit;
            playIcons.Images.Add("play", Properties.Resources.play_tool);
            playIcons.Images.Add("pause", Properties.Resources.pause_tool);
            playIcons.Images.Add("stop", Properties.Resources.stop_tool);

            _plugin = plugin;
            _fileWatcher = new DeferredFileSystemWatcher();
            _fileWatcher.Delay = 1000;
            _fileWatcher.Created += fileWatcher_EventRaised;
            _fileWatcher.Deleted += fileWatcher_EventRaised;
            _fileWatcher.Changed += fileWatcher_EventRaised;
            _fileWatcher.IncludeSubdirectories = true;
            _fileWatcher.EnableRaisingEvents = false;
            WatchProject(_plugin.Host.CurrentGame);
            StopMusic();
            MySafeRefresh = new SafeRefresh(Refresh);
        }

        /// <summary>
        /// Used by fgilesystem watcher to attempt to automatically
        /// add new additions to the sound list.
        /// </summary>
        /// <param name="game"></param>
        public void WatchProject(ProjectSettings game)
        {
            if (game != null)
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
            _music.Paused = true;
            pauseTool.CheckState = CheckState.Checked;
            playTool.Image = playIcons.Images["pause"];
            playTool.Text = "PAUSE";
        }

        /// <summary>
        /// Plays the song located at the path's location.
        /// </summary>
        /// <param name="path">The path to load from.</param>
        public void PlayFile(string path)
        {
            bool isMusic = Path.GetExtension(path) != ".wav";
            ISound sound = _soundEngine.Play2D(path, isMusic);
            if (isMusic)
            {
                StopMusic();
                _musicName = Path.GetFileNameWithoutExtension(path);
                _music = sound;
                trackNameLabel.Text = "Now Playing: " + _musicName;
                playTool.Text = "PLAY";
                playTool.Image = playIcons.Images["play"];
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
            _music.Paused = !this._music.Paused;
            pauseTool.CheckState = _music.Paused ? CheckState.Checked : CheckState.Unchecked;
            playTool.Image = _music.Paused ? playIcons.Images["pause"] : playIcons.Images["play"];
            playTool.Text = _music.Paused ? "PAUSE" : "PLAY";
        }

        /// <summary>
        /// Overrides the refresh method to re-add the items
        /// found in your music and sound paths.
        /// </summary>
        public override void Refresh()
        {
            base.Refresh();
            if (_plugin.Host.CurrentGame == null) { Reset(); return; }

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
            string gamePath = _plugin.Host.CurrentGame.RootPath;

            trackList.BeginUpdate();
            foreach (string filterInfo in _fileTypes)
            {
                string[] parsedFilter = filterInfo.Split(':');
                string searchFilter = parsedFilter[0];
                string groupName = parsedFilter[1];
                
                trackList.Groups.Add(groupName, groupName);

                DirectoryInfo dirInfo = new DirectoryInfo(gamePath);
                FileInfo[] fileInfos = dirInfo.GetFiles(searchFilter, SearchOption.AllDirectories);

                foreach (FileInfo fileInfo in fileInfos)
                {
                    string path = Path.GetFullPath(fileInfo.FullName);
                    ListViewItem listItem = trackList.Items.Add(Path.GetFileNameWithoutExtension(fileInfo.Name));
                    listItem.Tag = (object)fileInfo.FullName;
                    listItem.Group = trackList.Groups[groupName];
                    listItem.SubItems.Add(path.Replace(gamePath + "\\", ""));
                }
            }
            trackList.EndUpdate();
        }

        /// <summary>
        /// Resets the IrrKlang Sound Engine.
        /// </summary>
        public void Reset()
        {
            StopMusic();
            _soundEngine.StopAllSounds();
            trackList.Items.Clear();
            trackList.Groups.Clear();
        }

        /// <summary>
        /// Stops any currently playing music
        /// </summary>
        public void StopMusic()
        {
            if (_music != null)
            {
                _music.Stop();
                _music.Dispose();
                _music = null;
            }

            trackNameLabel.Text = "-";
            playTool.Image = playIcons.Images["stop"];
            playTool.Text = "STOP";
            pauseTool.CheckState = CheckState.Unchecked;
            pauseTool.Enabled = false;
            stopTool.Enabled = false;
        }
    }
}
