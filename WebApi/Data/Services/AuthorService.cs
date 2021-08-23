using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.ViewModels;

namespace WebApi.Data.Services
{
    public class AuthorService
    {
        private readonly ApplicationDbContext _db;

        public AuthorService(ApplicationDbContext db)
        {
            _db = db;
        }

        public Author AddAuthor(AuthorVM author)
        {
            var newAuthor = new Author()
            {
                Name = author.Name,
                Surname = author.Surname
            };

            _db.Authors.Add(newAuthor);
            _db.SaveChanges();

            return newAuthor;
        }

        public List<Author> GetAllAuthors()
        {
            var allAuthors = _db.Authors.ToList();
            return allAuthors;
        }

        public Author DeleteAuthor(int id)
        {
            var deleteAuthor = _db.Authors.FirstOrDefault(p => p.Id == id);
            if (deleteAuthor != null)
            {
                _db.Authors.Remove(deleteAuthor);
                _db.SaveChanges();
            }
            return deleteAuthor;
        }

        public Author EditAuthor(int id, AuthorVM publisher)
        {
            var oldAuthor = _db.Authors.FirstOrDefault(p => p.Id == id);
            if (oldAuthor != null)
            {
                oldAuthor.Name = publisher.Name;
                oldAuthor.Surname = publisher.Surname;
                _db.Authors.Update(oldAuthor);
                _db.SaveChanges();
            }
            return oldAuthor;
        }

        public Author GetAuthorById(int id)
        {
            var author = _db.Authors.FirstOrDefault(p => p.Id == id);
            return author;
        }
    }
}
