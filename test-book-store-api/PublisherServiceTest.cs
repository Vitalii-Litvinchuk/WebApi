using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using WebApi.Data;
using WebApi.Data.Models;
using WebApi.Data.Services;

namespace test_book_store_api
{
    public class PublisherServiceTest
    {
        //"DefaultConnection": "Data Source=(localdb)\\MSSQLLocalDB;Database=Library"

        private static DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "Library")
            .Options;

        ApplicationDbContext _db;
        PublisherService _publisherService;

        //[SetUp]
        [OneTimeSetUp]
        public void Setup()
        {
            _db = new ApplicationDbContext(dbContextOptions);
            _db.Database.EnsureCreated();
            SeedData();
            _publisherService = new PublisherService(_db);
        }

        private void SeedData()
        {
            var publishers = new List<Publisher>
            {
                new Publisher()
                {
                    Id= 1,
                    Name = "Publisher 1"
                },

                new Publisher()
                {
                    Id= 2,
                    Name = "Publisher 2"
                },

                new Publisher()
                {
                    Id= 3,
                    Name = "Publisher 3"
                },

                new Publisher()
                {
                    Id= 4,
                    Name = "Publisher 4"
                },

                new Publisher()
                {
                    Id= 5,
                    Name = "Publisher 5"
                },

                new Publisher()
                {
                    Id= 6,
                    Name = "Publisher 6"
                },

                new Publisher()
                {
                    Id= 7,
                    Name = "Publisher 7"
                },

                new Publisher()
                {
                    Id= 8,
                    Name = "Publisher 8"
                },

            };
            _db.Publishers.AddRange(publishers);
            _db.SaveChanges();
            return;
        }

        [Test, Order(1)]
        public void GetAllPublishers_WithNoSort_WithNoSearch_WithNoPageNumber()
        {
            var result = _publisherService.GetAllPublishers(null,"",0);
            Assert.That(result.Publishers.Count, Is.EqualTo(6));
        }

        [OneTimeTearDown]
        public void CleanUp()
        {
            _db.Database.EnsureDeleted();
            //Assert.Pass();
        }
    }
}