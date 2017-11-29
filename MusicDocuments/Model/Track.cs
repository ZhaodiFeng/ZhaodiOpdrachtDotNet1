using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Track
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public int? Downloads  { get; set; }
        public TimeSpan? Duration  { get; set; }

        public ICollection<ArtistTrack> ArtistTracks { get; set; }
        public ICollection<TrackGenre> TrackGenres { get; set; }
        public ICollection<TrackAlbum> TrackAlbums { get; set; }
    }
}
