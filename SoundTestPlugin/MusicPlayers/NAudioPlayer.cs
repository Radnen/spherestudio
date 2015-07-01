using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio;
using NAudio.Wave;
using NAudio.Vorbis;

namespace SphereStudio.Plugins
{
    class NAudioPlayer: IPlayer
    {
        IWavePlayer player = new DirectSoundOut();
        WaveStream stream;
        
        public NAudioPlayer(string filename, bool wantRepeat)
        {
            try { stream = new AudioFileReader(filename); }
            catch (Exception) { stream = new VorbisWaveReader(filename); }
            player.Init(stream);
        }

        public void Dispose()
        {
            player.Dispose();
            stream.Dispose();
        }
        
        public bool IsPaused
        {
            get { return player.PlaybackState == PlaybackState.Paused; }
        }

        public uint Position
        {
            get { return (uint)stream.Position; }
            set { stream.Position = value; }
        }

        public uint Length
        {
            get { return (uint)stream.Length; }
        }

        public void Play()
        {
            player.Play();
        }

        public void PlayOrPause()
        {
            if (IsPaused)
                player.Play();
            else
                player.Pause();
        }

        public void Pause()
        {
            player.Pause();
        }

        public void Stop()
        {
            player.Stop();
        }
    }
}
