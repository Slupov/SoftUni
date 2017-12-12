using Microsoft.AspNetCore.Mvc;
using WebApiBooks.Data.Models;
using WebApiBooks.Models;

namespace WebApiBooks.Controllers.Api
{
    public class AuthorsController : ApiBaseController
    {
        private readonly IAuthorsDataService authors;

        public AuthorsController(IAuthorsDataService authors)
        {
            this.authors = authors;
        }

        [HttpGet("{id}")]
        public IActionResult Authors(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Authors(AuthorRequestModel author)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(this.ModelState);
            }

            //bii go w bazata
            return Ok();
        }

        [HttpGet("{id}/books")]
        public IActionResult GetBooks()
        {
            return Ok();
        }
    }
}