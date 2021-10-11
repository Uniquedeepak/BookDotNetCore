using BooksMicroservice.Models;
using BooksMicroservice.Repository;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;

namespace BooksMicroservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookRepository _BookRepository;

        public BookController(IBookRepository BookRepository)
        {
            _BookRepository = BookRepository;
        }

        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var Books = _BookRepository.GetBooks();
            return new OkObjectResult(Books);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Book = _BookRepository.GetBookById(id);
            return new OkObjectResult(Book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book Book)
        {
            using (var scope = new TransactionScope())
            {
                _BookRepository.InsertBook(Book);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = Book.Id }, Book);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book Book)
        {
            if (Book != null)
            {
                using (var scope = new TransactionScope())
                {
                    _BookRepository.UpdateBook(Book);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _BookRepository.DeleteBook(id);
            return new OkResult();
        }
    }
}
