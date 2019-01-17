using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using MusicPlayer.Extensions;

namespace MusicPlayer
{
    public class Player
    {
        private const int MIN_VOLUME = 0;
        private const int MAX_VOLUME = 100;
        private bool _locked;
        private bool _playing;
        private int _volume;

        public int Volume
        {
            get { return _volume; }
            private set
            {
                if (value < MIN_VOLUME)
                {
                    _volume = MIN_VOLUME;
                }
                else if (value > MAX_VOLUME)
                {
                    _volume = MAX_VOLUME;
                }
                else
                {
                    _volume = value;
                }
            }
        }

        public bool Playing
        {
            get { return _playing; }
        }

        public void Lock()
        {
            _locked = true;
            Console.WriteLine("Player has been locked");
        }

        public void Unlock()
        {
            _locked = false;
        }

        public List<Song> Songs { get; private set; } = new List<Song>();

        public void VolumeUp()
        {
            Volume++;
            Console.WriteLine("Volume Down");
        }

        public void VolumeDown()
        {
            if (_locked == false)
            {
                Volume--;
                Console.WriteLine("Volume Up");
            }
        }

        public void VolumeChange(int step)
        {
            if (_locked == false)
            {
                Volume += step;
            }
        }

        public void Play()
        {
            if (_locked) return;
            _playing = true;
            foreach (var song in Songs)
            {
                //BL8 -Player 2/3. LikeDislike
                if (song.Like == true) Console.ForegroundColor = ConsoleColor.Green; 
                else if (song.Like == false) Console.ForegroundColor = ConsoleColor.Red; 
                Console.WriteLine($"Player is playing: {song.Name}", $"duration is {song.Duration}");
                Console.ResetColor();
                System.Threading.Thread.Sleep(1000);
            }
        }

        public void Stop()
        {
            if (_locked) return;
            _playing = false;
            Console.WriteLine("Player is stopped");
        }

        public void Start()
        {
            if (_locked) return;
            _playing = true;
            Console.WriteLine("Player has been started");
        }

        public void Add(params Song[] songsArray)
        {
            Songs.AddRange(songsArray);
        }

        public  Artist AddArtist(string name = "Unknown Artist")
        {
            var artist = new Artist();
            artist.Name = name;
            return artist;
        }

        public Album AddAlbum(string name = "Unknown Album", int year = 0)
        {
            var album = new Album();
            album.Name = name;
            album.Year = year;
            return album;
        }
        public void Shuffle()
        {
            this.Songs.Shuffle();
        }

        public void Sort()
        {
            Songs.Sort();
        }

    }

}

