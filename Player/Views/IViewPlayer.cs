using Player.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Player.Views
{
    interface IViewPlayer
    {
        event EventHandler Play;
        event EventHandler Pause;
        event EventHandler Stop;
        event EventHandler VolumeScroll;
        event EventHandler TimeScroll;
        event EventHandler Next;
        event EventHandler Prev;
        event EventHandler OnEndTrack;
        event EventHandler CheckChanged;
        void SetName(string name);
        void SetTime(TimeSpan time);
        void SetTimePosition(int position);
    }

    interface IViewPlayList
    {
        Track SelectedTrack{
            get;
            set;
        }

        int SelectedIndex
        {
            get;
            set;
        }

        event EventHandler LoadTrack;

        event EventHandler RemoveTrack;

        event EventHandler DoubleClockOnTrack;

        event EventHandler OnSelectedTrack;

        event EventHandler OnLoadClick;

        event EventHandler OnSaveClick;

        bool Visible { get; set; }

        void UpdateList();

        void SetBindingData(BindingList<Track> controlBindings);

        void AddTrackToList(Track track);
        void RemoveTrackFromList(Track track);
    }
}
