using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Player.Models
{

    class InvalidateTrackException : Exception{ }
    class EmptyPlayListException : Exception { }

    [Serializable]
    public class PlayList
    {

        public PlayList()
        {
            Path = "";
        }

        public PlayList(string path)
        {
            FileStream fs = new FileStream(path, FileMode.Open);
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();

                // Deserialize the hashtable from the file and 
                // assign the reference to the local variable.
                var des = (PlayList)formatter.Deserialize(fs);
                sounds = des.sounds;
                foreach (var item in sounds)
                {
                    if (File.Exists(item.Path) == false)
                    {
                        item.Name += "(Не найдено)";
                    }
                }
                currentTrack = 0;
                Path = des.Path;
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to deserialize. Reason: " + e.Message);

            }
            finally
            {
                fs.Close();
            }
        }

        public void Save()
        {
            if (Path == "")
            {
                SaveFileDialog save = new SaveFileDialog();
                save.Filter = "MyPlayer|*.mplr";
                if(save.ShowDialog() == DialogResult.OK)
                {
                    Path = save.FileName;
                }
            }

            FileStream fs = new FileStream(Path, FileMode.Create);
            BinaryFormatter formatter = new BinaryFormatter();
            try
            {
                formatter.Serialize(fs, this);
            }
            catch (SerializationException e)
            {
                MessageBox.Show("Failed to serialize. Reason: " + e.Message);
                
            }
            finally
            {
                fs.Close();
            }
        }

        BindingList<Track> sounds = new BindingList<Track>();

        int currentTrack = -1;

        public BindingList<Track> GetList { get { return sounds; } }

        public void AddTrack(Track track){
            if (currentTrack == -1)
                currentTrack = 0;

            if (File.Exists(track.Path) == false)
            {
                track.Name += "(Не найдено)";
            }
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

        public string Path { get; set; }

    }

    [Serializable]
    public class Track {

        public Track(string path)
        {
            Path = path;
            AudioFileReader audioFile = new AudioFileReader(path);
            Length = audioFile.TotalTime;
            Name = path.Split('\\').Last().Split('.')[0];
        }

    

        public string Path { get; set; }
        public string Name { get; set; }
        public TimeSpan Length { get; set; }

    }
}
