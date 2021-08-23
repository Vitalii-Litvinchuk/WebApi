using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
}
