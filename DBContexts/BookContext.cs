using BooksMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMicroservice.DBContexts
{
    public class BookContext : DbContext
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
        public DbSet<Book> Books { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Java",
                    Author = "xyz",
                    ISBN = "0074625421",
                    PublicationDate= new DateTime(2015, 10, 11)
                },
                new Book
                {
                    Id = 2,
                    Title = "c#",
                    Author = "abc",
                    ISBN = "0074625422",
                    PublicationDate = new DateTime(2015, 08, 20)
                },
                new Book
                {
                    Id = 3,
                    Title = "Python",
                    Author = "123",
                    ISBN = "0074625423",
                    PublicationDate = new DateTime(2015, 12, 15)
                }
            ) ;
        }
    }
}
