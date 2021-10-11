using BooksMicroservice.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksMicroservice.Repository
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetBooks();
        Book GetBookById(int Id);
        void InsertBook(Book Book);
        void UpdateBook(Book Book);
        void DeleteBook(int Id);
        void Save(); 

    }
}
