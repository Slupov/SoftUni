using Microsoft.AspNetCore.Mvc;
using WebApiBooks.Data.Models;

namespace WebApiBooks.Controllers.Api
{
    [Route("books")]
    public class BooksController : ApiBaseController
    {
        [HttpGet("{id}")]
        public IActionResult GetBook(int id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetBooks(int id, string search)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutBook(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            return Ok();
        }

        [HttpPost("{id}")]
        public IActionResult PostBook(Book book)
        {
            return Ok();
        }
    }
}