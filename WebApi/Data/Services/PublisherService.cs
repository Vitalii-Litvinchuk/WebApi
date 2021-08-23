using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.ViewModels;

namespace WebApi.Data.Services
{
    public class PublisherService
    {
        private readonly ApplicationDbContext _db;

        public PublisherService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Publisher AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
                Name = publisher.Name
            };

            _db.Publishers.Add(_publisher);
            _db.SaveChanges();

            return _publisher;
        }

        public List<Publisher> GetAllPublishers()
        {
            var allPublishers = _db.Publishers.ToList();
            return allPublishers;
        }

        public Publisher DeletePublisher(int id)
        {
            var delete = _db.Publishers.FirstOrDefault(p => p.Id == id);
            if (delete != null)
            {
                _db.Publishers.Remove(delete);
                _db.SaveChanges();
            }
            return delete;
        }

        public Publisher EditPublisher(int id, PublisherVM publisher)
        {
            var oldPublisher = _db.Publishers.FirstOrDefault(p => p.Id == id);
            if (oldPublisher != null)
            {
                oldPublisher.Name = publisher.Name;
                _db.Publishers.Update(oldPublisher);
                _db.SaveChanges();
            }
            return oldPublisher;
        }

        public Publisher GetPublisherById(int id)
        {
            var publisher = _db.Publishers.FirstOrDefault(p => p.Id == id);
            return publisher;
        }
    }
}
