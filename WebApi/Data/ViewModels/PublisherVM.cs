using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data.ViewModels
{
    public class PublisherVM
    {
        public string Name { get; set; }
    }

    public class BookAuthorVM
    {
        public string BookName { get; set; }

        public List<string> BookAuthors { get; set; }
    }

    public class PublisherWithBooksAndAuthors
    {
        public string Name { get; set; }

        public List<BookAuthorVM> BookAuthors { get; set; }
    }

    public class PublisherPageData
    {
        public List<Publisher> Publishers { get; set; }

        public bool Next { get; set; } = true;

        public bool Previous { get; set; } = true;

        public int PublishersInNextPage { get; set; }

        public int CurrentPage { get; set; }

        public int CountPublishers { get; set; }
    }
}
