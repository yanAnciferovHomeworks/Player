using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Player.Presenters
{
    interface IPlayerPresenter
    {
        void Play();
        void Next();
        void Prev();
        void Stop();
        void Pause();
    }
}
