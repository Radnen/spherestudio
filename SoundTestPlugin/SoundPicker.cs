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
        private readonly string[] fileTypes = new string[] 
        {
            "*.mp3:Music", "*.ogg:Music", "*.flac:Music", "*.mod:Music", "*.xm:Music", "*.it:Music", "*.s3d:Music",
            "*.wav:Sounds"
        };

        private IPlugin plugin;
        private ISoundEngine soundEngine = new ISoundEngine();
        private ISound music;
        private string musicName;

        private void pauseTool_Click(object sender, EventArgs e)
        {
            this.PlayOrPauseMusic();
        }

        private void stopTool_Click(object sender, EventArgs e)
        {
            this.StopMusic();
        }

        private void trackList_Click(object sender, EventArgs e)
        {
            ListViewItem chosenItem = this.trackList.SelectedItems[0];
        }
        
        private void trackList_DoubleClick(object sender, EventArgs e)
        {
            ListViewItem chosenItem = this.trackList.SelectedItems[0];
            string filePath = (string)chosenItem.Tag;
            bool playLooped = chosenItem.Group.Name == "Music";
            ISound sound = this.soundEngine.Play2D(filePath, playLooped);
            if (chosenItem.Group.Name == "Music")
            {
                this.StopMusic();
                this.musicName = chosenItem.Text;
                this.music = sound;
                this.trackNameTextBox.Text = "Now Playing: " + chosenItem.Text;
                this.playTool.Text = "PLAY";
                this.playTool.Image = this.playIcons.Images["play"];
                this.pauseTool.Enabled = true;
                this.pauseTool.CheckState = CheckState.Unchecked;
                this.stopTool.Enabled = true;
            }
        }

        public SoundPicker(IPlugin plugin)
        {
            InitializeComponent();
            this.plugin = plugin;
            this.StopMusic();
        }

        public void ForcePause()
        {
            if (this.music != null)
            {
                this.music.Paused = true;
                this.pauseTool.CheckState = CheckState.Checked;
                this.playTool.Image = this.playIcons.Images["pause"];
                this.playTool.Text = "PAUSE";
            }
        }

        public void PlayFile(string path)
        {
            //TODO: implement me!
        }

        public void PlayOrPauseMusic()
        {
            if (music != null)
            {
                this.music.Paused = !this.music.Paused;
                this.pauseTool.CheckState = this.music.Paused ? CheckState.Checked : CheckState.Unchecked;
                this.playTool.Image = this.music.Paused ? this.playIcons.Images["pause"] : this.playIcons.Images["play"];
                this.playTool.Text = this.music.Paused ? "PAUSE" : "PLAY";
            }
        }

        public override void Refresh()
        {
            base.Refresh();
            if (this.plugin.Host.CurrentGame != null)
            {
                string gamePath = this.plugin.Host.CurrentGame.RootPath;
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
                    string[] parsedFilter = filterInfo.Split(':');
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
            else
            {
                this.Reset();
            }
        }

        public void Reset()
        {
            this.StopMusic();
            this.soundEngine.StopAllSounds();
            this.trackList.Items.Clear();
            this.trackList.Groups.Clear();
        }

        public void StopMusic()
        {
            if (this.music != null)
            {
                this.music.Stop();
                this.music.Dispose();
                this.music = null;
            }
            this.trackNameTextBox.Text = "-";
            this.playTool.Image = this.playIcons.Images["stop"];
            this.playTool.Text = "STOP";
            this.pauseTool.CheckState = CheckState.Unchecked;
            this.pauseTool.Enabled = false;
            this.stopTool.Enabled = false;
        }
    }
}
