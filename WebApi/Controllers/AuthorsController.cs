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

        #region Gets

        [HttpGet("get-all-authors")]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _authorService.GetAllAuthors();
            return Ok(allAuthors);
        }

        [HttpGet("get-author-by-id/{id}")]
        public IActionResult GetAuthorById(int id)
        {
            var author = _authorService.GetAuthorById(id);
            if (author == null)
                return BadRequest($"Invalid id : {id}");
            return Ok(author);
        }

        #endregion

        #region Posts

        [HttpPost("add-author")]
        public IActionResult AddAuthor(AuthorVM author)
        {
            var newAuthor = _authorService.AddAuthor(author);
            return Created(nameof(AddAuthor), newAuthor);
        }

        #endregion

        #region Deletes

        [HttpDelete("delete-author/{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            var deletedAuthor = _authorService.DeleteAuthor(id);
            if (deletedAuthor == null)
                return BadRequest($"Invalid id : {id}");
            return Ok(deletedAuthor);
        }

        #endregion

        #region Puts

        [HttpPut("edit-author/{id}")]
        public IActionResult EditAuthor([FromBody] AuthorVM author, int id)
        {
            var editedAuthor = _authorService.EditAuthor(id, author);
            if (editedAuthor == null)
                return BadRequest("Invalid id or body");
            return Ok(editedAuthor);
        } 

        #endregion



    }
}
