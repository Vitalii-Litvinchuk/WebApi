using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.ViewModels;
using WebApi.Data.Services;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        public PublishersController(PublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers()
        {
            var allPublishers = _publisherService.GetAllPublishers();
            return Ok(allPublishers);
        }

        [HttpPost("add-new-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            var newPublisher = _publisherService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher);
        }

        [HttpDelete("delete-publisher/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            var deletedPublisher = _publisherService.DeletePublisher(id);
            if (deletedPublisher == null)
                return BadRequest(id);
            return Ok(deletedPublisher);
        }

        [HttpPut("edit-publisher/{id}")]
        public IActionResult EditPublisher([FromBody] PublisherVM publisher, int id)
        {
            var editedPublisher = _publisherService.EditPublisher(id, publisher);
            if (editedPublisher == null)
                return BadRequest();
            return Ok(editedPublisher);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            if (publisher == null)
                return BadRequest(id);
            return Ok(publisher);
        }

    }
}
