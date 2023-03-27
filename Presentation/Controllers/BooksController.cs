using Entities.DataTransferObjects;
using Entities.Exceptions;
using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class BooksController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public BooksController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_serviceManager.BookService.GetAllBooks(false));
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            var book = _serviceManager.BookService.GetOneBookById(id, false);
         
            return Ok(book);
        }
        [HttpPost]
        public IActionResult CreateOne([FromBody] Book book)
        {
            if (book is null)
                return NotFound();

            _serviceManager.BookService.CreateOneBook(book);

            return StatusCode(201, book);

        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateOneBook([FromRoute(Name = "id")] int id, [FromBody] BookDtoForUpdate bookDtoForUpdate)
        {
            if (bookDtoForUpdate is null) return BadRequest();

            _serviceManager.BookService.UpdateOneBook(id, bookDtoForUpdate, true);
            return NoContent();

        }

    }
}

