using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MusicRepository
{
    public class ArtistRepository
    {
        public List<Artist> GetAllArtists()
        {
            using (var context=new MusicContext())
            {
                return context.Artists.AsNoTracking().ToList();
            }
        }

        public Artist GetArtistById(int? id)
        {
            using (var context=new MusicContext())
            {
                //return context.Artists.AsNoTracking().SingleOrDefault(n=>n.Id==id);
                return context.Artists.SqlQuery("select * from Artists where Id={0}", id).FirstOrDefault();
            }
        }

        public void CreateArtist(Artist artist)
        {
            using (var context=new MusicContext())
            {
                context.Artists.Add(artist);
                context.SaveChanges();
            }
        }

        public void UpdateArtist(Artist artist)
        {
            using (var context=new MusicContext())
            {
                context.Entry(artist).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeletArtistById(int? id)
        {
            using (var context=new MusicContext())
            {
                var artist = context.Artists.Find(id);
                context.Entry(artist).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
