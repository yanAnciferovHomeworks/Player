using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using Player.Views;
using Player.Models;
using System.Windows.Forms;
using System.ComponentModel;
using System.IO;

namespace Player.Presenters
{
    
    class PlayerPresenter
    {

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Timer audioTimer;
        private Track CurrentTrack;
        IViewPlayer _viewPlayer;
        IViewPlayList _viewPlayList;
        PlayList sounds = new PlayList();
        public PlayerPresenter(IViewPlayer viewPlayer, IViewPlayList viewPlayList)
        {
            _viewPlayer = viewPlayer;
            _viewPlayer.Play += _viewPlayer_Play;
            _viewPlayer.VolumeScroll += _viewPlayer_VolumeScroll;
            _viewPlayer.TimeScroll += _viewPlayer_TimeScroll;
            _viewPlayer.Pause += _viewPlayer_Pause;
            _viewPlayer.Stop += _viewPlayer_Stop;
            _viewPlayer.Next += _viewPlayer_Next;
            _viewPlayer.Prev += _viewPlayer_Prev;
            _viewPlayer.OnEndTrack += _viewPlayer_OnEndTrack;
            _viewPlayer.CheckChanged += _viewPlayer_CheckChanged;

            _viewPlayList = viewPlayList;
            _viewPlayList.LoadTrack += _viewPlayList_Add;
            _viewPlayList.RemoveTrack += _viewPlayList_Remove;
            _viewPlayList.DoubleClockOnTrack += _viewPlayList_DoubleClockOnTrack;
            _viewPlayList.OnSelectedTrack += _viewPlayList_OnSelectedTrack;
            _viewPlayList.OnLoadClick += _viewPlayList_OnLoadClick;
            _viewPlayList.OnSaveClick += _viewPlayList_OnSaveClick;
            audioTimer = new Timer();

            _viewPlayList.SetBindingData(sounds.GetList);
            audioTimer.Interval = 250;
            audioTimer.Tick += (e, arg) => {
                var pos = (audioFile.CurrentTime.TotalMilliseconds / audioFile.TotalTime.TotalMilliseconds) * 100;
                _viewPlayer.SetTimePosition((int)pos);

                };

        }

        private void _viewPlayer_CheckChanged(object sender, EventArgs e)
        {
            var check = sender as CheckBox;
            _viewPlayList.Visible = check.Checked;
        }

        private void _viewPlayList_OnSaveClick(object sender, EventArgs e)
        {
            sounds.Save();
        }

        private void _viewPlayList_OnLoadClick(object sender, EventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Filter = "MyPlayer|*.mplr";
            if (op.ShowDialog() == DialogResult.OK)
            {
               sounds = new PlayList(op.FileName);
                _viewPlayList.SetBindingData(sounds.GetList);
            }
        }

        private void _viewPlayer_OnEndTrack(object sender, EventArgs e)
        {
            _viewPlayer_Next(null, null);
        }

        void _viewPlayer_Prev(object sender, EventArgs e)
        {
            try
            {
                _viewPlayList.SelectedIndex = sounds.GetList.IndexOf(sounds.Prev());
                Play();
            }
            catch (InvalidateTrackException ex)
            {
                audioTimer.Stop();
                OnPlaybackStopped(null, null);
                // MessageBox.Show("Плейлист закончился!");

                _viewPlayList.SelectedIndex = 0;
                _viewPlayer.SetName("");
                _viewPlayer.SetTime(new TimeSpan(0));
            }
            catch (EmptyPlayListException ex)
            {
                MessageBox.Show("Плейлист пуст!");
            }
        }

        void _viewPlayList_OnSelectedTrack(object sender, EventArgs e)
        {
            sounds.Current = _viewPlayList.SelectedTrack;
        }

        void _viewPlayer_Next(object sender, EventArgs e)
        {
            try
            {
                _viewPlayList.SelectedIndex = sounds.GetList.IndexOf(sounds.Next());
                Play();
            }
            catch (InvalidateTrackException ex)
            {
                audioTimer.Stop();
                //MessageBox.Show("Плейлист закончился!");
                OnPlaybackStopped(null, null);
                _viewPlayList.SelectedIndex = 0;
                _viewPlayer.SetName("");
                _viewPlayer.SetTime(new TimeSpan(0));
            }
            catch (EmptyPlayListException)
            {
                MessageBox.Show("Плейлист пуст!");
            }
        }

        private void _viewPlayer_Stop(object sender, EventArgs e)
        {
            audioTimer.Stop();
            if (outputDevice != null)
                OnPlaybackStopped(null, null);
            _viewPlayer.SetName("");
            _viewPlayer.SetTime(new TimeSpan(0));
        }

        private void _viewPlayer_Play(object sender, EventArgs e)
        {

            if (outputDevice != null)
            {
                outputDevice.Play();
                audioTimer.Start();
            }
            else
            {
                try
                {
                    CurrentTrack = sounds.Current;
                    _viewPlayList.SelectedIndex = sounds.GetList.IndexOf(CurrentTrack);
                    audioTimer.Start();
                    Play();
                }
                catch (EmptyPlayListException)
                {

                    MessageBox.Show("Плейлист пуст!");
                }

            }
        }

        private void _viewPlayer_Pause(object sender, EventArgs e)
        {
            audioTimer.Stop();
            if (outputDevice != null)
            {
                outputDevice.Pause();
            }
            
        }

        private void _viewPlayer_TimeScroll(object sender, EventArgs e)
        {
            if (outputDevice != null)
            {
                
                audioFile.CurrentTime = new TimeSpan(0,0,0,0, (int)((audioFile.TotalTime.TotalMilliseconds / 100) * (sender as TrackBar).Value));
               
            }
        }

        private void _viewPlayer_VolumeScroll(object sender, EventArgs e)
        {
            if(outputDevice != null)
            {
                outputDevice.Volume = (float)(sender as TrackBar).Value / 100;
            }
        }

        private void _viewPlayList_DoubleClockOnTrack(object sender, EventArgs e)
        {
            Play();
        }


        private void Play()
        {

            if (audioTimer != null)
                audioTimer.Stop();
            if (outputDevice != null)
            {
                outputDevice.Stop();
                OnPlaybackStopped(null, null);
            }

            CurrentTrack = sounds.Current;

            

            outputDevice = new WaveOutEvent();

            try
            {
                audioFile = new AudioFileReader(CurrentTrack.Path);
                _viewPlayer.SetTime(CurrentTrack.Length);
                _viewPlayer.SetName(CurrentTrack.Name);
                outputDevice.Init(audioFile);
                audioTimer.Start();
                outputDevice.Play();
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show("Трек по пути " + CurrentTrack.Path + " не найден!");
                _viewPlayer_Next(null, null);
            }
           

            
        }


        private void _viewPlayList_Remove(object sender, EventArgs e)
        {
            sounds.RemoveTrack(_viewPlayList.SelectedTrack);
        }

        private void _viewPlayList_Add(object sender, EventArgs e)
        {
            OpenFileDialog openfile = new OpenFileDialog();
            openfile.Multiselect = true;
            openfile.Filter = "MP3|*.mp3";
            openfile.ShowDialog();

            foreach (var item in openfile.FileNames)
            {
                Track myTrack = new Track(item);
                sounds.AddTrack(myTrack);
            }

        }

        private void OnButtonStopClick(object sender, EventArgs args)
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
            }
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            audioTimer.Stop();
            _viewPlayer.SetTimePosition(0);
            if (outputDevice != null)
                outputDevice.Dispose();
            outputDevice = null;
            if (audioFile != null)
                audioFile.Dispose();
            audioFile = null;

            if (args != null && args.Exception == null)
            {
                MessageBox.Show("sfd");
            }
        }

    }
}
