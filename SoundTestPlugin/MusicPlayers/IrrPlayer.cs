using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IrrKlang;

namespace SphereStudio.Plugins
{
    class IrrPlayer: IPlayer
    {
        ISoundEngine engine = new ISoundEngine();
        ISound       stream;

        public IrrPlayer(string filename, bool wantRepeat)
        {
            stream = engine.Play2D(filename, wantRepeat, true);
        }

        public void Dispose()
        {
            stream.Dispose();
            engine.Dispose();
        }

        public bool IsPaused
        {
            get { return stream.Paused; }
        }

        public uint Length
        {
            get { return stream.PlayLength; }
        }
        
        public uint Position
        {
            get { return stream.PlayPosition; }
            set { stream.PlayPosition = value; }
        }
        
        public void Play()
        {
            stream.Paused = false;
        }

        public void PlayOrPause()
        {
            stream.Paused = !stream.Paused;
        }
        
        public void Pause()
        {
            stream.Paused = true;
        }
        
        public void Stop()
        {
            stream.Stop();
        }
    }
}
