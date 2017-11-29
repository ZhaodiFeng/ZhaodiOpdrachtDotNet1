using Model;
using System.Data.Entity;


namespace DAL
{
    public class MusicContext:DbContext
    {
        public DbSet<Artist> Artists { get; set; }
        public DbSet<Track> Tracks { get; set; }
        public DbSet<ArtistTrack> ArtistTracks { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<TrackGenre> TrackGenres { get; set; }
        public DbSet<Album> Albums { get; set; }
        public DbSet<TrackAlbum> TrackAlbums { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<PublisherAlbum> PublisherAlbums { get; set; }
    }

    
}
