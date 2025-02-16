using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineClothingStoreAPI.Data;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly CategoryRepository categoryRepository;

        public CategoryController(CategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IActionResult GetAllCategorys()
        {
            var categories = categoryRepository.SelectAll();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetCategoryByID(int id)
        {
            var category = categoryRepository.SelectByPK(id);

            if (id != category.CategoryId)
            {
                return NotFound();
            }

            return Ok(category);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult InsertCategory([FromBody] CategoryModel category)
        {
            if (category == null)
            {
                return BadRequest();
            }

            if (categoryRepository.Insert(category))
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public IActionResult UpdateCategory(int id, [FromBody] CategoryModel category)
        {
            if (category == null || id != category.CategoryId)
            {
                return BadRequest();
            }

            if (categoryRepository.Update(category))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCategory(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (categoryRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
