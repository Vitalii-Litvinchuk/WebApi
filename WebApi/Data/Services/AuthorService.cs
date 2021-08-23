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

        #region Adds

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

        #endregion

        #region Gets

        public List<Author> GetAllAuthors()
        {
            var allAuthors = _db.Authors.ToList();
            return allAuthors;
        }

        public Author GetAuthorById(int id)
        {
            var author = _db.Authors.FirstOrDefault(p => p.Id == id);
            return author;
        }

        public AuthorWithBookVM GetAuthorWithBooks(int id)
        {
            var _author = _db.Authors.Where(a => a.Id == id).Select(a => new AuthorWithBookVM()
            {
                FullName = a.FullName,
                BookTitles = a.Book_Authors.Select(ba => ba.Book.Title).ToList()
            }).FirstOrDefault();
            return _author;
        }

        #endregion

        #region Edits

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

        #endregion

        #region Deletes

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

        #endregion


    }
}
