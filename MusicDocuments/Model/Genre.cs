using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Genre
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public ICollection<TrackGenre> TrackGenres { get; set; }
    }
}
