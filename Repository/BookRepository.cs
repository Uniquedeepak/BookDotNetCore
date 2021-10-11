using BooksMicroservice.DBContexts;
using BooksMicroservice.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BooksMicroservice.Repository
{
    public class BookRepository: IBookRepository
    {
        private readonly BookContext _dbContext;

        public BookRepository(BookContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void DeleteBook(int BookId)
        {
            var Book = _dbContext.Books.Find(BookId);
            _dbContext.Books.Remove(Book);
            Save();
        }

        public Book GetBookById(int Id)
        {
            return _dbContext.Books.Find(Id);
        }

        public IEnumerable<Book> GetBooks()
        {
            return _dbContext.Books;
        }

        public void InsertBook(Book Book)
        {
            _dbContext.Add(Book);
            Save();
        }

        public void Save()
        {
            _dbContext.SaveChanges();
        }

        public void UpdateBook(Book Book)
        {
            _dbContext.Entry(Book).State = EntityState.Modified;
            Save();
        }
    }
}
