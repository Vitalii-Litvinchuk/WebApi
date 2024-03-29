﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.ViewModels
{
    public class BookVM
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public DateTime? DateRead { get; set; }

        public DateTime DateAdded { get; set; }

        public int Rate { get; set; }

        public bool IsRead { get; set; }

        public string Genre { get; set; }

        public int PublisherId { get; set; }

        public List<int> AuthorsIds { get; set; }
    }

    public class BookWithAutorsVM
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string ImageURL { get; set; }

        public DateTime? DateRead { get; set; }

        public DateTime DateAdded { get; set; }

        public int Rate { get; set; }

        public bool IsRead { get; set; }

        public string Genre { get; set; }

        public string PublisherName { get; set; }

        public List<string> AuthorsNames { get; set; }
    }
}
