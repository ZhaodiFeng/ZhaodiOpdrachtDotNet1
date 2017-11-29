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
    public class PublisherRepository
    {
        public List<Publisher> GetAllPublishers()
        {
            using (var context = new MusicContext())
            {
                return context.Publishers.AsNoTracking().ToList();
            }
        }

        public Publisher GetPublisherById(int? id)
        {
            using (var context = new MusicContext())
            {
                return context.Publishers.AsNoTracking().SingleOrDefault(n => n.Id == id);
            }
        }

        public void CreatePublisher(Publisher publisher)
        {
            using (var context = new MusicContext())
            {
                context.Publishers.Add(publisher);
                context.SaveChanges();
            }
        }

        public void UpdatePublisher(Publisher publisher)
        {
            using (var context = new MusicContext())
            {
                context.Entry(publisher).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void DeletPublisherById(int? id)
        {
            using (var context = new MusicContext())
            {
                var publisher = context.Publishers.Find(id);
                context.Entry(publisher).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
