using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;

namespace WebApi.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /// [ForeignKey("")] =>
            //modelBuilder.Entity<Book_Author>()
            //    .HasOne(b => b.Book)
            //    .WithMany(ba => ba.Book_Authors)
            //    .HasForeignKey(bi => bi.BookId);

            //modelBuilder.Entity<Book_Author>()
            //    .HasOne(b => b.Author)
            //    .WithMany(ba => ba.Book_Authors)
            //    .HasForeignKey(bi => bi.AuthorId);



            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Publisher> Publishers { get; set; }

        public DbSet<Book_Author> Book_Authors { get; set; }

    }
}
