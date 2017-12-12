using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

    


namespace Player.Models
{
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
