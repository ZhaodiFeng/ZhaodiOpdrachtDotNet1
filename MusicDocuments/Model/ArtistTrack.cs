using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;

namespace Model
{
    public class ArtistTrack
    {
        public int Id { get; set; }
        //[Key, Column(Order = 0)]
        public int ArtistId { get; set; }
        //[Key,Column(Order = 1)]
        public int TrackId { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual Track Track { get; set; }
    }
}
