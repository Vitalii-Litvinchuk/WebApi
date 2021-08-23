using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Models;
using WebApi.Data.Services;
using WebApi.Data.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {

        public BookService _bookService;

        public BooksController(BookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allBooks = _bookService.GetAllBooks();
            return Ok(allBooks);
        }

        [HttpPost("add-new-book")]
        public IActionResult AddBook(Book book) // ([FromBody] Book book)
        {
            _bookService.AddBook(book);
            return Ok(book);
        }

        [HttpPost("add-new-book-with-authors")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _bookService.AddBookWithAuthors(book);
            return Ok();
        }

        [HttpDelete("delete-book/{id}")]
        public IActionResult DeleteBook(int id)
        {
            var deletedBook = _bookService.DeleteBook(id);
            if (deletedBook == null)
                return BadRequest(id);
            return Ok(deletedBook);
        }

        [HttpPut("edit-book/{id}")]
        public IActionResult EditBook([FromBody] BookVM book, int id)
        {
            var editedBook = _bookService.EditBook(id, book);
            if (editedBook == null)
                return BadRequest("Invalid id or body");
            return Ok(book);
        }

        [HttpPatch("get-book-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var book = _bookService.GetById(id);
            if (book == null)
                return BadRequest(id);
            return Ok(book);
        }

    }
}
