using System;
using System.Collections.Generic;

namespace MVCApp.Models
{
    public partial class User
    {
        public User()
        {
            Playlists = new HashSet<Playlist>();
        }

        public int Id { get; set; }
        public string? Fname { get; set; }
        public string? Lname { get; set; }
        public DateTime? Dob { get; set; }

        public virtual ICollection<Playlist> Playlists { get; set; }
    }
}
