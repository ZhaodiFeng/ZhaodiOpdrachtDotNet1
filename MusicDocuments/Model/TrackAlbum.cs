using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class TrackAlbum
    {
        public int Id { get; set; }
       // [Key,Column(Order = 0)]
        public int TrackId { get; set; }
        //[Key,Column(Order = 1)]
        public int AlbumId { get; set; }
        public int? Squence { get; set; }
        public virtual Track Track { get; set; }
        public virtual Album Album { get; set; }
    }
}
