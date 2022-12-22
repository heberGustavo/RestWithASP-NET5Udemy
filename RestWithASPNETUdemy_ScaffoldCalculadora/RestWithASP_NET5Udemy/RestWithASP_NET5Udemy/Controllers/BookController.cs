using Microsoft.AspNetCore.Mvc;
using RestWithASP_NET5Udemy.Business;
using RestWithASP_NET5Udemy.Model;

namespace RestWithASP_NET5Udemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : Controller
    {
        private readonly IBookBussiness _bookBussiness;

        public BookController(IBookBussiness bookBussiness)
        {
            _bookBussiness = bookBussiness;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_bookBussiness.FindAll());
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var book = _bookBussiness.FindById(id);
            if (book == null) return NotFound();

            return Ok(book);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBussiness.Create(book));
        }

        [HttpPut]
        public IActionResult Put([FromBody] Book book)
        {
            if (book == null) return BadRequest();
            return Ok(_bookBussiness.Update(book));
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _bookBussiness.Delete(id);
            return NoContent();
        }
    }
}
