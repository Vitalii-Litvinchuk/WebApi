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
    class AuthorServiceTest
    {
        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
          .UseInMemoryDatabase(databaseName: "Library")
          .Options;

        ApplicationDbContext _db;
        AuthorService _authorService;

        //[SetUp]
        [OneTimeSetUp]
        public void Setup()
        {
            _db = new ApplicationDbContext(dbContextOptions);
            _db.Database.EnsureCreated();
            SeedData();
            _authorService = new AuthorService(_db);
        }

        private void SeedData()
        {
            var authors = new List<Author>
            {
                new Author()
                {
                    Id= 1,
                    Name = "Author",
                    Surname = "1"
                },

                new Author()
                {
                    Id= 2,
                    Name = "Author",
                    Surname = "2"
                },

                new Author()
                {
                    Id= 3,
                    Name = "Author",
                    Surname = "3"
                },

                new Author()
                {
                    Id= 4,
                    Name = "Author",
                    Surname = "4"
                },

                new Author()
                {
                    Id= 5,
                    Name = "Author",
                    Surname = "5"
                },

                new Author()
                {
                    Id= 6,
                    Name = "Author",
                    Surname = "6"
                },

                new Author()
                {
                    Id= 7,
                    Name = "Author",
                    Surname = "7"
                },

                new Author()
                {
                    Id= 8,
                    Name = "Author",
                    Surname = "8"
                },

            };
            _db.Authors.AddRange(authors);
            _db.SaveChanges();
            return;
        }

        #region Gets

        [Test, Order(1)]
        public void GetAllAuthors()
        {
            var result = _authorService.GetAllAuthors();

            Assert.That(result.Count, Is.EqualTo(_db.Authors.Count()));
        }

        [Test, Order(2)]
        public void GetAuthorById()
        {
            var result = _authorService.GetAuthorById(1);

            Assert.That(result.Id, Is.EqualTo(1));
        }

        [Test, Order(3)]
        public void GetAuthorWithBooks()
        {
            var result = _authorService.GetAuthorWithBooks(1);
            var result1 = _authorService.GetAuthorById(1);

            Assert.That(result.FullName, Is.EqualTo(result1.FullName));
        }

        #endregion

        #region Adds

        [Test, Order(4)]
        public void AddNewAuthor()
        {
            var result = _authorService.AddAuthor(new WebApi.Data.ViewModels.AuthorVM() { Name = "Author", Surname = "9" });

            Assert.That(result.FullName, Is.EqualTo(_authorService.GetAuthorById(result.Id).FullName));
        }

        #endregion

        #region Delete

        [Test, Order(5)]
        public void DeleteAuthor()
        {
            var result = _authorService.DeleteAuthor(1);

            Assert.That(result.Id, Is.EqualTo(1));
        }

        #endregion

        #region Edit

        [Test, Order(6)]
        public void EditAuthor()
        {
            var result = _authorService.EditAuthor(5, new WebApi.Data.ViewModels.
                AuthorVM() { Name = "Hello", Surname= "World!" });

            Assert.That(result.FullName, Is.EqualTo("Hello World!") );
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
