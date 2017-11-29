using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Album
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        
        public DateTime? ReleaseDate { get; set; }
        public string Description { get; set; }
        public ICollection<TrackAlbum> TtrackAlbums { get; set; }
        public ICollection<PublisherAlbum> PublisherAlbums { get; set; }
    }
}
