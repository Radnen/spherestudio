using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SphereStudio.Plugins
{
    interface IPlayer : IDisposable
    {
        bool IsPaused { get; }
        uint Position { get; set; }
        uint Length { get; }
        
        void Play();
        void PlayOrPause();
        void Pause();
        void Stop();
    }
}
