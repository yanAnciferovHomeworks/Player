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

    class PlayerPresenter : IPlayerPresenter
    {

        private WaveOutEvent outputDevice;
        private AudioFileReader audioFile;
        private Timer audioTimer;
        private Track CurrentTrack;
        IViewPlayer _viewPlayer;
        IViewPlayList _viewPlayList;
        BindingList<Track> sounds = new BindingList<Track>();
        public PlayerPresenter(IViewPlayer viewPlayer, IViewPlayList viewPlayList)
        {
            _viewPlayer = viewPlayer;
            _viewPlayer.Play += _viewPlayer_Play;
            _viewPlayer.VolumeScroll += _viewPlayer_VolumeScroll;
            _viewPlayer.TimeScroll += _viewPlayer_TimeScroll;
            _viewPlayer.Pause += _viewPlayer_Pause;
            _viewPlayer.Stop += _viewPlayer_Stop;

            _viewPlayList = viewPlayList;
            _viewPlayList.LoadTrack += _viewPlayList_Add;
            _viewPlayList.RemoveTrack += _viewPlayList_Remove;
            _viewPlayList.DoubleClockOnTrack += _viewPlayList_DoubleClockOnTrack;

            audioTimer = new Timer();


            _viewPlayList.SetBindingData(sounds);
            audioTimer.Interval = 250;
            audioTimer.Tick += (e, arg) => {
                var pos = (audioFile.CurrentTime.TotalMilliseconds / audioFile.TotalTime.TotalMilliseconds) * 100;
                _viewPlayer.SetTimePosition((int)pos);

                };



        }

        private void _viewPlayer_Stop(object sender, EventArgs e)
        {
            audioTimer.Stop();
            outputDevice.Stop();
        }

        private void _viewPlayer_Play(object sender, EventArgs e)
        {
            audioTimer.Start();
            if(outputDevice != null) 
                outputDevice.Play();
            else
            {
                Play(CurrentTrack);
            }
        }

        private void _viewPlayer_Pause(object sender, EventArgs e)
        {
            audioTimer.Stop();
            outputDevice.Pause();
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
            CurrentTrack = _viewPlayList.SelectedTrack;
            
            audioTimer.Start();
           
            _viewPlayer.SetTime(CurrentTrack.Length);
            _viewPlayer.SetName(CurrentTrack.Name);
            Play(_viewPlayList.SelectedTrack);
        }

        private void _viewPlayList_Remove(object sender, EventArgs e)
        {
            sounds.Remove(_viewPlayList.SelectedTrack);
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
                sounds.Add(myTrack);
            }
           
        }

        private void Play(Track track)
        {
            if (outputDevice == null)
            {
                outputDevice = new WaveOutEvent();
                outputDevice.PlaybackStopped += OnPlaybackStopped;
            }
            if (audioFile == null)
            {
                audioFile = new AudioFileReader(track.Path);
                outputDevice.Init(audioFile);
            }
           
            outputDevice.Play();
        }

        private void OnButtonStopClick(object sender, EventArgs args)
        {
            outputDevice?.Stop();
        }

        private void OnPlaybackStopped(object sender, StoppedEventArgs args)
        {
            audioTimer.Stop();
            _viewPlayer.SetTimePosition(0);
            outputDevice.Dispose();
            outputDevice = null;
            audioFile.Dispose();
            audioFile = null;
        }

        List<String> PlayList = new List<string>();

        public void Next()
        {
            throw new NotImplementedException();
        }

        public void Pause()
        {
            throw new NotImplementedException();
        }

        public void Play()
        {
            throw new NotImplementedException();
        }

        public void Prev()
        {
            throw new NotImplementedException();
        }

        public void Stop()
        {
            throw new NotImplementedException();
        }
    }
}
