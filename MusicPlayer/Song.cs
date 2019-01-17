using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicPlayer
{
    public class Song:IComparable
    {
        public int Duration;
        public String Name;
        public Artist Artist;
        public Album Album;
        

        public int CompareTo(object obj)
        {
            //if (this.Name == null)
            //    return 0;

            //var songToCompare = (obj as Song);
            //return this.Name.CompareTo(songToCompare);

            return this.Name?.CompareTo((obj as Song)?.Name)??0;
        }

        //BL8 -Player 2/3. LikeDislike
        public bool? Like;
        public bool? LikeDislike(bool like)
        {
            return Like = like;
        }

        //BL8-Player3/3.SongGenres.
        enum Genres
        {
            Classic = 1,
            Rock,
            HipHop
        }
    }
}
