using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class PublisherAlbum
    {
        public int Id { get; set; }
        //[Key,Column(Order = 0)]
        public int PublisherId { get; set; }
        //[Key,Column(Order = 1)]
        public int AlbumId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public virtual Album Album { get; set; }
    }
}
