using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.Models
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string FullName => $"{Name} {Surname}";

        public List<Book_Author> Book_Authors { get; set; }
    }
}
