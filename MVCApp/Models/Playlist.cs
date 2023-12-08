using System;
using System.Collections.Generic;

namespace MVCApp.Models
{
    public partial class Playlist
    {
        public int PId { get; set; }
        public string? PName { get; set; }
        public int? NumOfSongs { get; set; }
        public int? Userid { get; set; }

        public virtual User? User { get; set; }
    }
}
