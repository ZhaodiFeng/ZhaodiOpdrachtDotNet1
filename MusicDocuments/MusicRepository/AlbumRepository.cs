using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Model;

namespace MusicRepository
{
    public class AlbumRepository
    {
        public List<Album> GetAllAlbums()
        {
            using (var context = new MusicContext())
            {
                return context.Albums.AsNoTracking().ToList();
            }
        }

        public Album GetAlbumById(int? id)
        {
            using (var context = new MusicContext())
            {
                return context.Albums.AsNoTracking().SingleOrDefault(n => n.Id == id);
            }
        }

        public void CreateAlbum(Album album)
        {
            using (var context = new MusicContext())
            {
                context.Albums.Add(album);
                context.SaveChanges();
            }
        }

        public void UpdateAlbum(Album album)
        {
            using (var context = new MusicContext())
            {
                var a= context.Entry(album);
                a.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeletAlbumById(int? id)
        {
            using (var context = new MusicContext())
            {
                var album = context.Albums.Find(id);
                context.Entry(album).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<AlbumTracksTemplate> GetTracksOfAlbum(int? id)
        {
            List<AlbumTracksTemplate> albumTemplates=new List<AlbumTracksTemplate>();
            using (var context=new MusicContext())
            {
               var tracks=context.TrackAlbums.Where(ta => ta.AlbumId == id);
                foreach (var t in tracks)
                {
                    AlbumTracksTemplate template=new AlbumTracksTemplate();
                    template.Track = t.Track;
                    template.Sequnce = t.Squence;
                    albumTemplates.Add(template);
                }
            }
            return albumTemplates;
        }

        public void UpdateTracksOfAlbum(int? id,List<AlbumTracksTemplate> tracks)
        {
            using (var context=new MusicContext())
            {
                context.Database.ExecuteSqlCommand("Delete from TrackAlbums where AlbumId={0}", id);
                if(tracks!=null)
                    foreach (var track in tracks)
                    {
                        TrackAlbum trackAlbum=new TrackAlbum();
                        trackAlbum.AlbumId = id.Value;
                        trackAlbum.TrackId = track.Track.Id;
                        trackAlbum.Squence = track.Sequnce;
                        context.TrackAlbums.Add(trackAlbum);
                    }
                context.SaveChanges();
            }
        }

        public void UpdatePublishersOfAlbum(int? id, List<int> publishers)
        {
            using (var context = new MusicContext())
            {
                context.Database.ExecuteSqlCommand("Delete from PublisherAlbums where AlbumId={0}", id);
                if(publishers!=null)
                    foreach (int publisher in publishers)
                    {
                       PublisherAlbum publisherAlbum=new PublisherAlbum();
                        publisherAlbum.AlbumId = id.Value;
                        publisherAlbum.PublisherId = publisher;
                        context.PublisherAlbums.Add(publisherAlbum);
                    }
                context.SaveChanges();
            }
        }
        public List<Publisher> GetPublishersOfAlbum(int? id)
        {
            List<Publisher> publishers = new List<Publisher>();
            using (var context=new MusicContext())
            {
                publishers = context.PublisherAlbums.Where(pa => pa.AlbumId == id).Select(pa => pa.Publisher).ToList();
            }
            return publishers;
        }
    }
}
