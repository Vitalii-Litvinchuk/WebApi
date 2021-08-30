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

        #region GetAll

        [Test, Order(1)]
        public void GetAllPublishers_WithNoSort_WithNoSearch_WithNoPageNumber()
        {
            var result = _publisherService.GetAllPublishers(null, "", 0);

            Assert.That(result.Publishers.Count, Is.EqualTo(6));
        }

        [Test, Order(2)]
        public void GetAllPublishers_WithSort_WithNoSearch_WithNoPageNumber()
        {
            var result = _publisherService.GetAllPublishers(false, "", 0);
            var result1 = _publisherService.GetAllPublishers(true, "", 2);


            Assert.That(result.Publishers[0], Is.EqualTo(result1.Publishers[1]));
        }

        [Test, Order(3)]
        public void GetAllPublishers_WithNoSort_WithSearch_WithNoPageNumber()
        {
            var result = _publisherService.GetAllPublishers(null, "Publisher 20", 0);

            Assert.That(result.Publishers, Is.EqualTo(null));
        }

        [Test, Order(4)]
        public void GetAllPublishers_WithNoSort_WithNoSearch_WithPageNumber()
        {
            var result = _publisherService.GetAllPublishers(null, "", 12);

            Assert.That(result.Publishers, !Is.EqualTo(null));
        }

        #endregion

        #region GetById

        [Test, Order(5)]
        public void GetPublisherById()
        {
            var result = _publisherService.GetPublisherById(1);

            Assert.That(result, !Is.EqualTo(null));
        }

        [Test, Order(6)]
        public void GetPublisherById_WithNoId()
        {
            var result = _publisherService.GetPublisherById(0);

            Assert.That(result, Is.EqualTo(null));
        }

        #endregion

        #region GetData

        [Test, Order(7)]
        public void GetPublisherBooksWithAuthors()
        {
            var result = _publisherService.GetPublisherData(1);

            Assert.That(result, !Is.EqualTo(null));
        }

        [Test, Order(8)]
        public void GetPublisherBooksWithAuthors_WithNoId()
        {
            var result = _publisherService.GetPublisherData(0);

            Assert.That(result, Is.EqualTo(null));
        }

        #endregion

        #region AddNew

        [Test, Order(9)]
        public void AddNewPublisher()
        {
            var result = _publisherService.AddPublisher(new WebApi.Data.ViewModels
                .PublisherVM() { Name = "Publisher 2" });

            Assert.That(result, !Is.EqualTo(null));
        }

        [Test, Order(10)]
        public void AddNewPublisher_WithNoName()
        {
            var result = _publisherService.AddPublisher(new WebApi.Data.ViewModels
                .PublisherVM() { Name = null });

            Assert.That(result.Name, Is.EqualTo(null));
        }

        #endregion

        #region Delete

        [Test, Order(11)]
        public void DeletePublisher()
        {
            var result = _publisherService.DeletePublisher(8);

            Assert.That(result, !Is.EqualTo(null));
        }

        [Test, Order(12)]
        public void DeletePublisher_WithNoId()
        {
            var result = _publisherService.DeletePublisher(0);

            Assert.That(result, Is.EqualTo(null));
        }

        #endregion

        #region Edit

        [Test, Order(12)]
        public void EditPublisher()
        {
            var result = _publisherService.EditPublisher(1, new WebApi.Data.ViewModels.
                    PublisherVM() { Name = "Publisher 12" });

            Assert.That(result.Name, Is.EqualTo("Publisher 12"));
        }

        [Test, Order(13)]
        public void EditPublisher_WithNoId()
        {
            var result = _publisherService.EditPublisher(0, new WebApi.Data.ViewModels.
                    PublisherVM()
            { Name = "Publisher 12" });

            Assert.That(result, Is.EqualTo(null));
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