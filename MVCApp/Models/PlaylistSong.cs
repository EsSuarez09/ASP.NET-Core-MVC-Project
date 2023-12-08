using System;
using System.Collections.Generic;

namespace MVCApp.Models
{
    public partial class PlaylistSong
    {
        public int? PId { get; set; }
        public int? SId { get; set; }

        public virtual Playlist? PIdNavigation { get; set; }
        public virtual Song? SIdNavigation { get; set; }
    }
}
