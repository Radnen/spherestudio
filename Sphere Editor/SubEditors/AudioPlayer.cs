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
        private static IrrKlang.ISoundEngine _engine;
        private IrrKlang.ISound _sound = null;
        private string _filename = null;
        private string _max = "(0:00)";

        static AudioPlayer()
        {
           _engine = new IrrKlang.ISoundEngine(IrrKlang.SoundOutputDriver.AutoDetect);
        }

        public AudioPlayer(string song_filename)
        {
            _filename = song_filename;
            _sound = _engine.Play2D(song_filename, false, true, IrrKlang.StreamMode.AutoDetect, true);
            if (_sound == null) return;
            InitializeComponent();

            int maximum = (int)_sound.PlayLength;
            //if (IsMod()) maximum /= 44100;
            AudioTracker.SetRange(-1, maximum);
            _max = ConvertToTime(maximum);

            TimeLabel.Text = "(0:00)" + " / " + _max;
            NameLabel.Text = "Song Name: " + System.IO.Path.GetFileName(_filename);
        }

        private void PlayPauseButton_Click(object sender, EventArgs e)
        {
            _sound.Paused = !_sound.Paused;
            if (!_sound.Paused)
            {
                PlayButton.Text = "Pause";
                PlayButton.Image = Sphere_Editor.Properties.Resources.pause;
            }
            else
            {
                PlayButton.Text = "Play";
                PlayButton.Image = Sphere_Editor.Properties.Resources.play;
            }
            AudioTracker.Enabled = !AudioTracker.Enabled;
            UpdateTimer.Start();
        }

        private void StopButton_Click(object sender, EventArgs e)
        {
            _sound.Paused = true;
            _sound.PlayPosition = 0;
            AudioTracker.Value = 0;
            PlayButton.Text = "Play";
            PlayButton.Image = Sphere_Editor.Properties.Resources.play;
            AudioTracker.Enabled = true;
            UpdateTimer.Stop();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            AudioTracker.Value = (int)_sound.PlayPosition;
            TimeLabel.Text = ConvertToTime(AudioTracker.Value) + " / " + _max;
            if (_sound.Finished)
            {
                // Damn, so now the sound needs reactivating:
                _sound.Dispose();
                _sound = _engine.Play2D(_filename, false, true, IrrKlang.StreamMode.AutoDetect, true);
                PlayButton.Text = "Play";
                PlayButton.Image = Sphere_Editor.Properties.Resources.play;
                AudioTracker.Enabled = true;
                _sound.Paused = true;
                _sound.Volume = ((float)VolumeTracker.Value) / 100;
                _sound.PlaybackSpeed = ((float)PitchTracker.Value) / 100;
                ((Timer)sender).Stop();
            }
        }

        private void AudioTracker_Scroll(object sender, EventArgs e)
        {
            _sound.PlayPosition = (uint)AudioTracker.Value;
        }

        private void RepeatCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            _sound.Looped = !_sound.Looped;
        }

        /// <summary>
        /// It takes a total time in milliseconds and converts it into
        /// a more coherent string of numbers IE: (minutes, seconds).
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        private static string ConvertToTime(int number)
        {
            int seconds = number / 1000;
            int minutes = seconds / 60;

            // And we'd have to adjust the newer values (integer rounding):
            seconds -= minutes * 60;

            return "(" + minutes + ":" + ((seconds < 10) ? "0" : "") + seconds + ")";
        }

        // test function to see if the source file is a module format...
        private bool IsMod()
        {
            if (_filename.EndsWith(".mod")) return true;
            if (_filename.EndsWith(".it")) return true;
            if (_filename.EndsWith(".xm")) return true;
            if (_filename.EndsWith(".s3m")) return true;
            return false;
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            _engine.StopAllSounds();
            _engine.RemoveAllSoundSources();
            _sound.Dispose();
            Parent.Controls.Remove(this);
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
            _sound.Volume = ((float)VolumeTracker.Value) / 100;
            InfoLabel.Text = "Volume: " + VolumeTracker.Value + "%";
        }

        private void PitchTracker_ValueChanged(object sender, EventArgs e)
        {
            _sound.PlaybackSpeed = ((float)PitchTracker.Value) / 100;
            InfoLabel.Text = "Pitch: " + PitchTracker.Value + "%";
        }

        private void NameLabel_DoubleClick(object sender, EventArgs e)
        {
            Height = (Height == 36) ? 121 : 36;
        }
    }
}
