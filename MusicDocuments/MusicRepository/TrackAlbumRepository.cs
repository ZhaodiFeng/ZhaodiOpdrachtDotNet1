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
    class TrackAlbumAlbumRepository
    {
        public List<TrackAlbum> GetAllTrackAlbums()
        {
            using (var context = new MusicContext())
            {
                return context.TrackAlbums.AsNoTracking().ToList();
            }
        }

        public TrackAlbum GetTrackAlbumById(int? id)
        {
            using (var context = new MusicContext())
            {
                return context.TrackAlbums.AsNoTracking().SingleOrDefault(n => n.Id == id);
            }
        }

        public void CreateTrackAlbum(TrackAlbum trackAlbum)
        {
            using (var context = new MusicContext())
            {
                context.TrackAlbums.Add(trackAlbum);
                context.SaveChanges();
            }
        }

        public void UpdateTrackAlbum(TrackAlbum trackAlbum)
        {
            using (var context = new MusicContext())
            {
                context.Entry(trackAlbum).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeletTrackAlbumById(int? id)
        {
            using (var context = new MusicContext())
            {
                var trackAlbum = context.TrackAlbums.Find(id);
                context.Entry(trackAlbum).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
