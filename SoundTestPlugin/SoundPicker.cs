using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Sphere.Plugins;

using IrrKlang;

namespace SoundTestPlugin
{
    public partial class SoundPicker : UserControl
    {
        private readonly string[] fileTypes = new string[] {
            "*.mp3/Music",
            "*.ogg/Music",
            "*.wav/Sounds"
        };

        private IPlugin plugin;
        private ISoundEngine soundEngine = new ISoundEngine();
        private ISound music;
        private string musicName;

        private void trackList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem chosenItem = this.trackList.SelectedItems[0];
            string filePath = (string)chosenItem.Tag;
            bool playLooped = chosenItem.Group.Name == "Music";
            if (chosenItem.Group.Name == "Music")
            {
                this.StopMusic();
            }
            ISound sound = this.soundEngine.Play2D(filePath, playLooped);
            if (chosenItem.Group.Name == "Music")
            {
                this.musicName = chosenItem.Text;
                this.music = sound;
                this.playPauseTool.Text = this.musicName;
                this.playPauseTool.CheckState = CheckState.Checked;
                this.playPauseTool.Enabled = true;
                this.stopTool.Enabled = true;
            }
        }

        private void playPauseTool_Click(object sender, EventArgs e)
        {
            this.PlayOrPauseMusic();
        }

        private void stopTool_Click(object sender, EventArgs e)
        {
            this.StopMusic();
        }

        public SoundPicker(IPlugin plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
        }

        public void PlayOrPauseMusic()
        {
            if (music != null)
            {
                music.Paused = !music.Paused;
                this.playPauseTool.CheckState = music.Paused ? CheckState.Unchecked : CheckState.Checked;
                this.playPauseTool.Text = music.Paused ? "&Paused" : this.musicName;
            }
        }

        public void StopMusic()
        {
            if (music != null)
            {
                music.Stop();
                music.Dispose();
                this.playPauseTool.CheckState = CheckState.Unchecked;
                this.playPauseTool.Enabled = false;
                this.playPauseTool.Text = "no music";
                this.stopTool.Enabled = false;
            }
        }
        
        public void Clear()
        {
            this.StopMusic();
            this.soundEngine.StopAllSounds();
            this.trackList.Items.Clear();
            this.trackList.Groups.Clear();
        }

        
        public void RePopulate(string gamePath)
        {
            this.trackList.BeginUpdate();
            string currentItemName = null;
            if (this.trackList.SelectedItems.Count > 0)
            {
                currentItemName = this.trackList.SelectedItems[0].Text;
            }
            this.trackList.Items.Clear();
            this.trackList.Groups.Clear();
            foreach (string filterInfo in this.fileTypes)
            {
                string[] parsedFilter = filterInfo.Split('/');
                string searchFilter = parsedFilter[0];
                string groupName = parsedFilter[1];
                this.trackList.Groups.Add(groupName, groupName);
                DirectoryInfo dirInfo = new DirectoryInfo(Path.Combine(gamePath, "sounds"));
                FileInfo[] allFilesInfo = dirInfo.GetFiles(searchFilter, SearchOption.AllDirectories);
                foreach (FileInfo fileInfo in allFilesInfo)
                {
                    string path = Path.GetFullPath(fileInfo.FullName);
                    ListViewItem listItem = this.trackList.Items.Add(Path.GetFileNameWithoutExtension(fileInfo.Name));
                    listItem.Tag = (object)fileInfo.FullName;
                    listItem.Group = this.trackList.Groups[groupName];
                    listItem.SubItems.Add(path.Replace(gamePath + "\\", ""));
                }
            }
            if (currentItemName != null)
            {

                ListViewItem itemToSelect = this.trackList.FindItemWithText(currentItemName);
                if (itemToSelect != null)
                {
                    itemToSelect.Selected = true;
                }
            }
            this.trackList.EndUpdate();
        }
    }
}
