using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Artist
    {
        public string Genre;
        public string Name;

        public Artist()
        {
            this.Name = "Default Name";
            this.Genre = "Default Genre";
        }

        public Artist(string name)
        {
            this.Name = name;
            this.Genre = "Default Genre";
        }

        public Artist(string name, string genre)
        {
            this.Name = name;
            this.Genre = genre;
        }

    }
}
