using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Player.Models;
using Player.Views;
namespace Player
{
    public partial class SoundList : Form, IViewPlayList
    {
        public SoundList()
        {
            InitializeComponent();
            PlayList.DisplayMember = "Name";
            
        }

        public Track SelectedTrack {
            get { return (Track)PlayList.SelectedItem; }
            set { }

        }

        public void SetBindingData(BindingList<Track> controlBindings)
        {
            PlayList.DataSource = controlBindings;
        }

        public event EventHandler LoadTrack;
        public event EventHandler OnSelectedTrack;
        public event EventHandler RemoveTrack;
        public event EventHandler DoubleClockOnTrack;
        public event EventHandler OnLoadClick;
        public event EventHandler OnSaveClick;

        public void AddTrackToList(Track track)
        {
            PlayList.Items.Add(track);
            PlayList.Update();
        }

        public void RemoveTrackFromList(Track track)
        {
            PlayList.Items.Remove(track);
        }

        private void Add_Click(object sender, EventArgs e)
        {
            LoadTrack(sender, e);
        }

        private void Remove_Click(object sender, EventArgs e)
        {
            RemoveTrack(sender, e);
        }

        private void PlayList_DoubleClick(object sender, EventArgs e)
        {
            DoubleClockOnTrack(sender, e);
        }


        public int SelectedIndex
        {
            get
            {
                return PlayList.SelectedIndex;
            }
            set
            {
                PlayList.SelectedIndex = value;
            }
        }

        

        private void PlayList_SelectedIndexChanged(object sender, EventArgs e)
        {
            OnSelectedTrack(sender,e);
        }

        private void Save_Click(object sender, EventArgs e)
        {
            OnSaveClick(sender, e);
        }

        private void Load_Click(object sender, EventArgs e)
        {
            OnLoadClick(sender, e);
        }

        public void UpdateList()
        {
            PlayList.Update();
        }
    }
}
