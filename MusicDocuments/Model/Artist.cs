using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Artist
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? BirthDay  { get; set; }
        public string Bio  { get; set; }

        public ICollection<ArtistTrack> ArtistTracks { get; set; }
    }
}
