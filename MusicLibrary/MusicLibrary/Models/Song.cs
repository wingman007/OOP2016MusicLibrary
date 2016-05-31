using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicLibrary.Models
{
    public class Song
    {
        public int id { get; set; }
        public string songName { get; set; }
        public string artist { get; set; }
        public string imageSrc { get; set; }
        public string fileSrc { get; set; }
        public int playlistId { get; set; }
        public virtual Playlist Playlist { get; set; }
    }
}