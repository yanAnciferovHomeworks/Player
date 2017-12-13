using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.ComponentModel;

    


namespace Player.Models
{

    class InvalidateTrackException : Exception{ }
    class EmptyPlayListException : Exception { }
    public class PlayList
    {
        BindingList<Track> sounds = new BindingList<Track>();

        int currentTrack = -1;

        public BindingList<Track> GetList { get { return sounds; } }

        public void AddTrack(Track track){
            if (currentTrack == -1)
                currentTrack = 0;
            sounds.Add(track);
        }


        public void RemoveTrack(Track track)
        {
            sounds.Remove(track);
        }


        public Track Next()
        {
            if(sounds.Count == 0)
            {
                currentTrack = -1;
                throw new EmptyPlayListException();
            }

            currentTrack++;
            if (currentTrack == sounds.Count)
            {
                currentTrack = 0;
                throw new InvalidateTrackException();
            }
            else
            {
                return sounds[currentTrack];
            }
        }

        public Track Prev()
        {
            if (sounds.Count == 0)
            {
                currentTrack = -1;
                throw new EmptyPlayListException();
            }

            currentTrack--;
            if (currentTrack == -1)
            {
                currentTrack = 0;
                throw new InvalidateTrackException();
            }
            else
            {
                return sounds[currentTrack];
            }
            
        }

        public Track Current
        {
            get
            {
                if (sounds.Count == 0)
                {
                    currentTrack = -1;
                    throw new EmptyPlayListException();
                }

                if (currentTrack == -1)
                    throw new InvalidateTrackException();
                else
                {
                    return sounds[currentTrack];
                }
            }
            set{
                if (sounds.Count == 0)
                {
                    currentTrack = -1;
                    throw new EmptyPlayListException();
                }

                if (sounds.IndexOf(value) != -1)
                {
                    currentTrack = sounds.IndexOf(value);
                }
            }
        }
    }

    public class Track {

        public Track(string path)
        {
            Path = path;
            audioFile = new AudioFileReader(path);
            Length = audioFile.TotalTime;
            Name = path.Split('\\').Last().Split('.')[0];
        }

        private AudioFileReader audioFile;

        public string Path { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }

    }
}
