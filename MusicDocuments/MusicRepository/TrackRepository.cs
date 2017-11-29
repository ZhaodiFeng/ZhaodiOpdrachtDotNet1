using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace MusicRepository
{
    public class TrackRepository
    {
        public List<Track> GetAllTracks()
        {
            using (var context = new MusicContext())
            {
                return context.Tracks.AsNoTracking().ToList();
            }
        }

        public Track GetTrackById(int? id)
        {
            using (var context = new MusicContext())
            {
                return context.Tracks.AsNoTracking().SingleOrDefault(n => n.Id == id);
            }
        }

        public void CreateTrack(Track track)
        {
            using (var context = new MusicContext())
            {
                context.Tracks.Add(track);
                context.SaveChanges();
            }
        }

        public void UpdateTrack(Track track)
        {
            using (var context = new MusicContext())
            {
                context.Entry(track).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeleteTrackById(int? id)
        {
            using (var context = new MusicContext())
            {
                var track = context.Tracks.Find(id);
                context.Entry(track).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void UpdateArtistsOfTrack(int? id,List<int> artistsId)
        {
            using (var context = new MusicContext())
            {
                context.Database.ExecuteSqlCommand("Delete from ArtistTracks where TrackId = {0}", id);
                foreach (int a in artistsId)
                {
                    var artistTrack =new ArtistTrack();
                    artistTrack.ArtistId = a;
                    artistTrack.TrackId = id.Value;
                    context.ArtistTracks.Add(artistTrack);
                    context.SaveChanges();
                }
            }
        }

        public void UpdateGenresOfTrack(int? id,List<int> genresId)
        {
            using (var context = new MusicContext())
            {
                context.Database.ExecuteSqlCommand("Delete from TrackGenres where TrackId = {0}", id);
                foreach (int g in genresId)
                {
                   var trackGenre=new TrackGenre();
                    trackGenre.TrackId = id.Value;
                    trackGenre.GenreId = g;
                    context.TrackGenres.Add(trackGenre);
                    context.SaveChanges();
                }
            }
        }

        public List<Artist> GetArtistsOfTrack(int? id)
        {
            using (var context=new MusicContext())
            {
                //context.Database.Log = Console.WriteLine;
                /*context.Database.ExecuteSqlCommand(
                    @"Create Procedure GetArtistsOfTrack @id int 
                    as select *
                        from Artists
                        where Id in
                        (select ArtistId from ArtistTracks where TrackId=@id)");*/
                SqlParameter track = new SqlParameter("@id", id);
                return context.Artists.SqlQuery("GetArtistsOfTrack @id", track).ToList();
            }

        }

        public List<Artist> GetArtistsOfTrackWithProcedure(int? id)
        {
            using (var context = new MusicContext())
            {      
                context.Database.ExecuteSqlCommand(
                    @"Create Procedure GetArtistsOfTrack @id int 
                    as select *
                        from Artists
                        where Id in
                        (select ArtistId from ArtistTracks where TrackId=@id)");
                SqlParameter track = new SqlParameter("@id", id);
                return context.Artists.SqlQuery("GetArtistsOfTrack @id", track).ToList();
            }

        }
        public List<Genre> GetGenresOfTrack(int? id)
        {
            using (var context=new MusicContext())
            {
                /*var genres = from g in context.Genres
                    where (
                        from tg in context.TrackGenres
                        where tg.TrackId == id
                        select tg.GenreId
                    ).Contains(g.Id)
                    select g;
                return genres.ToList();*/
                return context.TrackGenres.Where(tg => tg.TrackId == id).Select(tg => tg.Genre).ToList();
            }
        }

        public List<Album> GetAlbumsOfTrack(int? id)
        {
            using (var context=new MusicContext())
            {
                var albums = context.Albums.Where(
                    a => context.TrackAlbums.Where(ta => ta.TrackId == id).Select(i => i.AlbumId).Contains(a.Id)).ToList();
      
                return albums;
            }
        }
    }
}
