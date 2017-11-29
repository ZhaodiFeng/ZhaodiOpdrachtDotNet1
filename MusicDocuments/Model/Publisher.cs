using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Publisher
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime? FoundingDate { get; set; }
        public string Profile { get; set; }
        public ICollection<PublisherAlbum> PublisherAlbums { get; set; }
    }
}
