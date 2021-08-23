using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.ViewModels;

namespace WebApi.Data.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _db;

        public BookService(ApplicationDbContext db)
        {
            _db = db;
        }

        public void AddBookWithAuthors(BookVM book)
        {
            var newBook = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.DateRead,
                Rate = book.Rate,
                Genre = book.Genre,
                ImageURL = book.ImageURL,
                PublisherId = book.PublisherId,
            };
            _db.Books.Add(newBook);
            _db.SaveChanges();

            foreach (var id in book.AuthorsIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = newBook.Id,
                    AuthorId = id
                };
                _db.Book_Authors.Add(_book_author);
                _db.SaveChanges();
            }
        }

        public List<Book> GetAllBooks() => _db.Books.ToList();

        public void AddBook(Book book)
        {
            _db.Books.Add(book);
            _db.SaveChanges();
        }

        public Book DeleteBook(int id)
        {
            var deleteBook = _db.Books.FirstOrDefault(p => p.Id == id);
            if (deleteBook != null)
            {
                _db.Books.Remove(deleteBook);
                _db.SaveChanges();
            }
            return deleteBook;
        }

        public Book EditBook(int id, BookVM book)
        {
            var oldBook = _db.Books.FirstOrDefault(p => p.Id == id);
            if (oldBook != null)
            {
                oldBook.Title = book.Title;
                oldBook.Description = book.Description;
                oldBook.IsRead = book.IsRead;
                oldBook.DateRead = book.DateRead;
                oldBook.Rate = book.Rate;
                oldBook.Genre = book.Genre;
                oldBook.ImageURL = book.ImageURL;
                oldBook.PublisherId = book.PublisherId;
                _db.Books.Update(oldBook);

                foreach (var book_author in _db.Book_Authors.Where(ba => ba.BookId == oldBook.Id))
                    _db.Book_Authors.Remove(book_author);

                foreach (var Id in book.AuthorsIds)
                    if (_db.Authors.FirstOrDefault(a => a.Id == Id) != null)
                    {
                        var _book_author = new Book_Author()
                        {
                            BookId = oldBook.Id,
                            AuthorId = Id
                        };
                        _db.Book_Authors.Add(_book_author);
                    }

                _db.SaveChanges();
            }
            return oldBook;
        }

        public Book GetBookById(int id)
        {
            var book = _db.Books.FirstOrDefault(p => p.Id == id);
            return book;
        }
    }
}
