using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class TrackGenre
    {
        public int Id { get; set; }
       // [Key,Column(Order = 0)]
        public int TrackId{ get; set; }
        //[Key,Column(Order = 1)]
        public int GenreId { get; set; }
        public virtual Track Track { get; set; }
        public virtual Genre Genre { get; set; }
    }
}
