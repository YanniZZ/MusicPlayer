using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace MusicPlayer
{
    class Program
    {
        static void Main(string[] args)
        {
            
            var player = new Player();
            //player.Volume = 50;
            int totalDuration = 0;
            player.Add(GetSongsData(ref totalDuration, out int minDuration, out int maxduration));
            Console.WriteLine($"Total: {totalDuration}, max: {maxduration}, min: {minDuration}");

            //TraceInformation(player);
            
            player.Start();
            player.Play();
            player.VolumeUp();
            player.VolumeChange(300);
            //player.Volume = -25;
            //Console.WriteLine(player.Volume);
            player.Stop();
            var song_1 = CreateSong();
            var song_2 = CreateSong("blablabla");
            var song_3 = CreateSong("Blablabla", 500);
            player.Add(song_1, song_2, song_3);
            
            Console.ReadLine();
        }

        public static Song[] GetSongsData(ref int totalDuration, out int minDuration, out int maxDuration)
        {
            minDuration = 1000;
            maxDuration = 0;
            var аlbum = new Album();
            аlbum.Name = "New Album";
            аlbum.Year = 2018;

            var аrtist = new Artist();
            аrtist.Name = "Powerwolf";
            аrtist.Genre = "Metal";

            var artist2 = new Artist("Lordi");
            Console.WriteLine(artist2.Name, artist2.Genre);

            var artist3 = new Artist("Sabaton", "Rock");
            Console.WriteLine(artist3.Name + artist3.Genre);

            var songs = new Song[10];
            var random = new Random();
            for (int i = 0; i < 10; i++)
            {
                var song = new Song()
                {
                    Duration = random.Next(1000),
                    Name = $"New song {i}",
                    Album = аlbum,
                    Artist = аrtist
                };
                songs[i] = song;
                totalDuration += song.Duration;
                if (song.Duration < minDuration)
                {
                    minDuration = song.Duration;
                }

                maxDuration = Math.Max(maxDuration, song.Duration);
            }
            return songs;
        }

        public static void TraceInformation(Player player)
        {

            Console.WriteLine(player.Songs[0].Artist.Name);
            Console.WriteLine(player.Songs[0].Duration);
            Console.WriteLine(player.Songs.Length);
            Console.WriteLine(player.Volume);
        }

        public static Song CreateSong()
        {
            return new Song
            {
                Name = "unknown Artist",
                Duration = 120
            };
        }

        public static Song CreateSong(string name)
        {
            return CreateSong(name, 120);
        }

        public static Song CreateSong(string name, int duration)
        {
            return new Song

            {
                Name = name,
                Duration = duration
            };
        }

    }
}
