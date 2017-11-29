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
    public class GenreRepository
    {
        public List<Genre> GetAllGenres()
        {
            using (var context = new MusicContext())
            {
                return context.Genres.AsNoTracking().ToList();
            }
        }

        public Genre GetGenreById(int? id)
        {
            using (var context = new MusicContext())
            {
                return context.Genres.AsNoTracking().SingleOrDefault(n => n.Id == id);
            }
        }

        public void CreateGenre(Genre genre)
        {
            using (var context = new MusicContext())
            {
                context.Genres.Add(genre);
                context.SaveChanges();
            }
        }

        public void UpdateGenre(Genre genre)
        {
            using (var context = new MusicContext())
            {
                context.Entry(genre).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeletGenreById(int? id)
        {
            using (var context = new MusicContext())
            {
                var genre = context.Genres.Find(id);
                context.Entry(genre).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

    }
}
