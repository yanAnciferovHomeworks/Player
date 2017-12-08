using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Views
{
    interface IViewPlayer
    {
        void Play();
        void Next();
        void Prev();
        void Stop();
        void Pause();
        string TrackName { get; set; }
    }
}
