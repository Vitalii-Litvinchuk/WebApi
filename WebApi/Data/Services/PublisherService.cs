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

        #region Adds

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

        public List<Publisher> AddPublishers(List<PublisherVM> publishers)
        {
            List<Publisher> lp = new List<Publisher>();
            foreach (var publisher in publishers)
            {
                var _publisher = new Publisher()
                {
                    Name = publisher.Name
                };
                _db.Publishers.Add(_publisher);
                lp.Add(_publisher);
            }

            _db.SaveChanges();
            return lp;
        }

        #endregion

        #region Gets

        private readonly int countPublishersInPage = 6;
        public PublisherPageData GetAllPublishers(bool? sort, string searchString, int pageNumber)
        {
            bool search = false;
            if (!string.IsNullOrEmpty(searchString))
                search = !search;

            int countPublishers = _db.Publishers.Count();
            int amountPublishers = countPublishersInPage;
            int nextPage = countPublishersInPage;

            PublisherPageData ppd = new PublisherPageData();
            List<Publisher> lp;

            if (sort == null)
                lp = _db.Publishers.ToList();
            else if (sort == true)
                lp = _db.Publishers.OrderBy((a) => a.Name).ToList();
            else
                lp = _db.Publishers.OrderByDescending((a) => a.Name).ToList();

            if (search)
            {
                lp = lp.FindAll(a => a.Name == searchString);
                countPublishers = lp.Count;
            }

            int other = countPublishers - countPublishers / countPublishersInPage * countPublishersInPage; 

            int plus = 0;

            if (other != 0)
                plus = 1;

            if (pageNumber >= countPublishers / countPublishersInPage + plus)
            {
                pageNumber = countPublishers / countPublishersInPage + 1;
                amountPublishers = other;

                if (other == 0)
                {
                    --pageNumber;
                    amountPublishers = countPublishersInPage;
                }

                ppd.Next = false;
            }

            if (pageNumber > 0)
                --pageNumber;

            if (pageNumber < 0)
                pageNumber = 0;

            if (pageNumber == countPublishers / countPublishersInPage - 1)
                nextPage = other;

            ppd.CurrentPage = pageNumber + 1;

            if (countPublishers / countPublishersInPage == pageNumber)
                ppd.PublishersInNextPage = 0;
            else
                ppd.PublishersInNextPage = nextPage;

            if (ppd.CurrentPage == 1)
                ppd.Previous = false;

            ppd.CountPublishers = countPublishers;
            if (countPublishers > 0)
                ppd.Publishers = lp.GetRange(pageNumber * countPublishersInPage, amountPublishers);
            else
            {
                ppd.CurrentPage = 0;
                ppd.Next = false;
            }
            return ppd;
        }

        public Publisher GetPublisherById(int id)
        {
            var publisher = _db.Publishers.FirstOrDefault(p => p.Id == id);
            return publisher;
        }

        public PublisherWithBooksAndAuthors GetPublisherData(int id)
        {
            var _publisherData =
                _db.Publishers.Where(p => p.Id == id)
                .Select(p => new PublisherWithBooksAndAuthors()
                {
                    Name = p.Name,
                    BookAuthors = p.Books.Select(b => new BookAuthorVM()
                    {
                        BookName = b.Title,
                        BookAuthors = b.Book_Authors.Where(ba => ba.BookId == b.Id).Select(ba => ba.Author.Name).ToList()
                    })
                    .ToList()
                }).FirstOrDefault();
            return _publisherData;
        }

        #endregion

        #region Edits


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

        #endregion

        #region Deletes

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

        #endregion


    }
}
