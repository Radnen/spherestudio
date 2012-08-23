using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Sphere_Editor.SubEditors
{
    public partial class AudioPlayer : UserControl
    {
        private IrrKlang.ISoundEngine engine = new IrrKlang.ISoundEngine(IrrKlang.SoundOutputDriver.AutoDetect);
        private IrrKlang.ISound sound = null;
        private string filename = null;
        private string max = "(0:00)";

        public AudioPlayer(string song_filename)
        {
            filename = song_filename;
            sound = engine.Play2D(song_filename, false, true, IrrKlang.StreamMode.AutoDetect, true);
            if (sound == null) return;
            InitializeComponent();

            int maximum = (int)sound.PlayLength;
            //if (IsMod()) maximum /= 44100;
            AudioTracker.SetRange(-1, maximum);
            max = ConvertToTime(maximum);

            TimeLabel.Text = "(0:00)" + " / " + max;
            NameLabel.Text = "Song Name: " + System.IO.Path.GetFileName(filename);
        }

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            sound.Paused = !sound.Paused;
            if (!sound.Paused) PlayButton.Text = "Pause";
            else PlayButton.Text = "Play";
            AudioTracker.Enabled = !AudioTracker.Enabled;
            UpdateTimer.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            sound.Paused = true;
            sound.PlayPosition = 0;
            AudioTracker.Value = 0;
            PlayButton.Text = "Play";
            AudioTracker.Enabled = true;
            UpdateTimer.Stop();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            AudioTracker.Value = (int)sound.PlayPosition;
            TimeLabel.Text = ConvertToTime(AudioTracker.Value) + " / " + max;
            if (sound.Finished)
            {
                // Damn, so now the sound needs reactivating:
                sound.Dispose();
                sound = engine.Play2D(filename, false, true, IrrKlang.StreamMode.AutoDetect, true);
                PlayButton.Text = "Play";
                AudioTracker.Enabled = true;
                sound.Paused = true;
                sound.Volume = ((float)VolumeTracker.Value) / 100;
                sound.PlaybackSpeed = ((float)PitchTracker.Value) / 100;
                ((Timer)sender).Stop();
            }
        }

        private void AudioTracker_Scroll(object sender, EventArgs e)
        {
            sound.PlayPosition = (uint)AudioTracker.Value;
        }

        private void RepeatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            sound.Looped = !sound.Looped;
        }

        /// <summary>
        /// It takes a total time in milliseconds and converts it into
        /// a more coherent string of numbers IE: (minutes, seconds).
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private string ConvertToTime(int number)
        {
            int seconds = number / 1000;
            int minutes = seconds / 60;

            // And we'd have to adjust the newer values (integer rounding):
            seconds -= minutes * 60;

            return "(" + minutes + ":" + ((seconds < 10) ? "0" : "") + seconds + ")";
        }

        private bool IsMod()
        {
            if (this.filename.EndsWith(".mod")) return true;
            if (this.filename.EndsWith(".it")) return true;
            if (this.filename.EndsWith(".xm")) return true;
            if (this.filename.EndsWith(".s3m")) return true;
            return false;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            this.engine.StopAllSounds();
            this.engine.RemoveAllSoundSources();
            this.sound.Dispose();
            this.Parent.Controls.Remove(this);
        }

        private void VolumeTracker_MouseEnter(object sender, EventArgs e)
        {
            InfoLabel.Text = "Volume: " + VolumeTracker.Value + "%";
        }

        private void PitchTracker_MouseEnter(object sender, EventArgs e)
        {
            InfoLabel.Text = "Pitch: " + VolumeTracker.Value + "%";
        }

        private void VolumeTracker_ValueChanged(object sender, EventArgs e)
        {
            sound.Volume = ((float)VolumeTracker.Value) / 100;
            InfoLabel.Text = "Volume: " + VolumeTracker.Value + "%";
        }

        private void PitchTracker_ValueChanged(object sender, EventArgs e)
        {
            sound.PlaybackSpeed = ((float)PitchTracker.Value) / 100;
            InfoLabel.Text = "Pitch: " + PitchTracker.Value + "%";
        }
    }
}
