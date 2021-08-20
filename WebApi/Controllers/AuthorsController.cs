using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.Services;
using WebApi.Data.ViewModels;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;

        public AuthorsController(AuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _authorService.GetAllAuthors();
            return Ok(allAuthors);
        }

        [HttpPost("add-author")]
        public IActionResult AddAuthor(AuthorVM author)
        {
            var newAuthor = _authorService.AddAuthor(author);
            return Created(nameof(AddAuthor), newAuthor);
        }

        [HttpDelete("delete-author/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var deletedAuthor = _authorService.DeleteAuthor(id);
            if (deletedAuthor == null)
                return BadRequest(id);
            return Ok(deletedAuthor);
        }

        [HttpPut("edit-author/{id}")]
        public IActionResult EditAuthor([FromBody] AuthorVM author, int id)
        {
            var editedAuthor = _authorService.EditAuthor(id, author);
            if (editedAuthor == null)
                return BadRequest();
            return Ok(editedAuthor);
        }

        [HttpPatch("get-author-by-id/{id}")]
        public IActionResult GetById(int id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
                return BadRequest(id);
            return Ok(author);
        }

    }
}
