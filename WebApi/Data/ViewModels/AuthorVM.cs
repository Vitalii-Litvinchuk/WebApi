using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Data.ViewModels
{
    public class AuthorVM
    {
        public string Name { get; set; }

        public string Surname { get; set; }
    }

    public class AuthorWithBookVM
    {
        public string FullName { get; set; }

        public List<string> BookTitles { get; set; } 
    }

}
