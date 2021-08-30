using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.ViewModels;
using WebApi.Data.Services;
using System.ComponentModel;
using Microsoft.Extensions.Logging;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly PublisherService _publisherService;

        private readonly ILogger<PublishersController> _logger;

        public PublishersController(PublisherService publisherService, ILogger<PublishersController> logger)
        {
            _publisherService = publisherService;
            _logger = logger;
        }

        #region Gets

        [HttpGet("get-all-publishers")]
        public IActionResult GetAllPublishers(bool? sort, string searchString, int pageNumber)
        {
            _logger.LogInformation($"sortBy: {sort}\tsearchString: {searchString}\tpaageNumber: {pageNumber}");
            var allPublishers = _publisherService.GetAllPublishers(sort, searchString, pageNumber);
            return Ok(allPublishers);
        }

        [HttpGet("get-publisher-by-id/{id}")]
        public IActionResult GetPublisherById(int id)
        {
            var publisher = _publisherService.GetPublisherById(id);
            if (publisher == null)
                return BadRequest($"Invalid id : {id}");
            return Ok(publisher);
        }

        [HttpGet("get-publisher-books-with-authors/{id}")]
        public IActionResult GetPublisherData(int id)
        {
            var _allPublisherData = _publisherService.GetPublisherData(id);
            if (_allPublisherData != null)
                return Ok(_allPublisherData);
            else
                return BadRequest($"Invalid id : {id}");
        }

        #endregion

        #region Posts

        [HttpPost("add-new-publisher")]
        public IActionResult AddPublisher([FromBody] PublisherVM publisher)
        {
            var newPublisher = _publisherService.AddPublisher(publisher);
            return Created(nameof(AddPublisher), newPublisher);
        }

        //[HttpPost("add-new-publishers")]
        //public IActionResult AddPublishers([FromBody] List<PublisherVM> publishers)
        //{
        //    var newPublishers = _publisherService.AddPublishers(publishers);
        //    return Created(nameof(AddPublisher), newPublishers);
        //}


        #endregion

        #region Deletes

        [HttpDelete("delete-publisher/{id}")]
        public IActionResult DeletePublisher(int id)
        {
            var deletedPublisher = _publisherService.DeletePublisher(id);
            if (deletedPublisher == null)
                return BadRequest($"Invalid id : {id}");
            return Ok(deletedPublisher);
        }

        #endregion

        #region Puts

        [HttpPut("edit-publisher/{id}")]
        public IActionResult EditPublisher([FromBody] PublisherVM publisher, int id)
        {
            var editedPublisher = _publisherService.EditPublisher(id, publisher);
            if (editedPublisher == null)
                return BadRequest("Invalid id or body");
            return Ok(editedPublisher);
        }

        #endregion



    }
}
