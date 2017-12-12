using Microsoft.AspNetCore.Mvc;

namespace WebApiBooks.Controllers.Api
{
    [Route("categories")]
    public class CategoryController : ApiBaseController
    {
        [HttpGet]
        public IActionResult GetCategories()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetCategories(int id)
        {
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult PutCategory(int id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult PostCategory()
        {
            return Ok();
        }
    }
}