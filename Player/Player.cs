using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Player.Views;
using Player.Presenters;

namespace Player
{
    public partial class Player : Form, IViewPlayer
    {

        public event EventHandler Play;
        public event EventHandler VolumeScroll;
        public event EventHandler TimeScroll;
        public event EventHandler Pause;
        public event EventHandler Stop;
        public event EventHandler Next;
        public event EventHandler Prev;
        public Player()
        {
            InitializeComponent();
        }

   

        private void _play_Click(object sender, EventArgs e)
        {
            Play(sender,e);
            _pause.Enabled = true;
        }

        public void SetName(string name)
        {
            Name.Text = name;
        }

        public void SetTime(TimeSpan time)
        {
            Time.Text = time.Minutes + ":" + time.Seconds;
        }

        private void SoundBar_Scroll(object sender, EventArgs e)
        {
            VolumeScroll(sender, e);
        }

        public void SetTimePosition(int position)
        {
            
             TimeBar.Value = position;
           
        }

        private void TimeBar_Scroll(object sender, EventArgs e)
        {
            
             TimeScroll(sender, e);
        }

        private void _stop_Click(object sender, EventArgs e)
        {
            _pause.Enabled = false;
            Stop(sender, e);
        }

        private void _pause_Click(object sender, EventArgs e)
        {
            Pause(sender, e);
        }

        private void _prev_Click(object sender, EventArgs e)
        {
            Prev(sender,e);
        }

        private void _next_Click(object sender, EventArgs e)
        {
            Next(sender, e);
        }


       
    }
}
