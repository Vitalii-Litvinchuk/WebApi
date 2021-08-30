using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.Data;
using WebApi.Data.Models;
using WebApi.Data.Services;

namespace test_book_store_api
{
    class BookServiceTest
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "Library")
          .Options;

        ApplicationDbContext _db;
        BookService _bookService;

        //[SetUp]
        [OneTimeSetUp]
        public void Setup()
        {
            _db = new ApplicationDbContext(dbContextOptions);
            _db.Database.EnsureCreated();
            SeedData();
            _bookService = new BookService(_db);
        }

        private void SeedData()
        {
            var books = new List<Book>
            {
                new Book()
                {
                    Id= 1,
                    Title = "Book 1"
                },

                new Book()
                {
                    Id= 2,
                    Title = "Book 2"
                },

                new Book()
                {
                    Id= 3,
                    Title = "Book 3"
                },

                new Book()
                {
                    Id= 4,
                    Title = "Book 4"
                },

                new Book()
                {
                    Id= 5,
                    Title = "Book 5"
                },

                new Book()
                {
                    Id= 6,
                    Title = "Book 6"
                },

                new Book()
                {
                    Id= 7,
                    Title = "Book 7"
                },

                new Book()
                {
                    Id= 8,
                    Title = "Book 8"
                },

            };

            _db.Books.AddRange(books);
            _db.Publishers.Add(new Publisher() { Id = 1, Name = "Publisher" });
            _db.Authors.Add(new Author() { Id = 1, Name = "Aut", Surname = "hor"});
            _db.SaveChanges();
            return;
        }

        #region Gets

        [Test, Order(1)]
        public void GetAllBooks()
        {
            var result = _bookService.GetAllBooks();

            Assert.That(result.Count, Is.EqualTo(8));
        }
        
        [Test, Order(2)]
        public void GetBookById()
        {
            var result = _bookService.GetBookById(1);

            Assert.That(result.Id, Is.EqualTo(1));
        }
        
        [Test, Order(3)]
        public void GetBookWithAuthorsById()
        {
            var result = _bookService.GetBookWithAutorsById(2);
            // Need more information in SeedData()
            Assert.That(result, Is.EqualTo(null));
        }

        #endregion

        #region Adds

        [Test, Order(4)]
        public void AddNewBook()
        {
            _bookService.AddBook(new Book());

            Assert.That(_bookService.GetAllBooks().Count, Is.EqualTo(9));
        }

        [Test, Order(5)]
        public void AddNewBookWithAuthors()
        {
            _bookService.AddBookWithAuthors(new WebApi.Data.ViewModels.BookVM()
            {
                Title = "A",
                Description = "A",
                IsRead = false,
                DateRead = null,
                DateAdded = DateTime.Now,
                Rate = 1,
                Genre = "A",
                ImageURL = "A",
                PublisherId = 1,
                AuthorsIds = new List<int>() { 1 },
            }) ;
            Assert.That(_bookService.GetAllBooks().Count, Is.EqualTo(10));
        }

        #endregion

        #region Deletes

        [Test,Order(6)]
        public void DeleteAuthor()
        {
            var result = _bookService.DeleteBook(1);

            Assert.That(result.Id == 1);
        }

        #endregion

        #region Edits

        [Test, Order(7)]
        public void EditBook()
        {
            var result = _bookService.EditBook(3, new WebApi.Data.ViewModels.BookVM()
            {
                Title = "A",
                Description = "A",
                IsRead = false,
                DateRead = null,
                DateAdded = DateTime.Now,
                Rate = 1,
                Genre = "A",
                ImageURL = "A",
                PublisherId = 1,
                AuthorsIds = new List<int>() { 1 },
            });

            Assert.That(result.Id == 3);
        }

        #endregion

        [OneTimeTearDown]
        public void CleanUp()
        {
            _db.Database.EnsureDeleted();
            //Assert.Pass();
        }
    }
}
