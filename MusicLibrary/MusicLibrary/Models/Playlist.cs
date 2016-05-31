using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicLibrary.Models
{
    public class Playlist
    {
        public int id { get; set; }
        //public int userId { get; set; }
        public string name { get; set; }
        public virtual ApplicationUser User { get; set; }
        public virtual ICollection<Song> Songs { get; set; }
    }
}