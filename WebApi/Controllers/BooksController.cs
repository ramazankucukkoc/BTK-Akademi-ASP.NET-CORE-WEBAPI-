using Entities.Models;
using Microsoft.AspNetCore.Mvc;
using WebApi.Repositories;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly RepositoryContext _repositoryContext;

        public BooksController(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_repositoryContext.Books.ToList());
        }
        [HttpGet("{id:int}")]
        public IActionResult GetOneBook([FromRoute(Name = "id")] int id)
        {
            try
            {
                var book = _repositoryContext.Books.Where(b => b.ID.Equals(id)).SingleOrDefault();
                if (book is null)
                    return NotFound($"Bu {id} ait veri bulunammadı ");

                return Ok(book);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
        [HttpPost]
        public IActionResult CreateOne([FromBody] Book book)
        {
            try
            {
                if (book is null)
                    return NotFound();

                _repositoryContext.Books.Add(book);
                _repositoryContext.SaveChanges();

                return StatusCode(201, book);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
