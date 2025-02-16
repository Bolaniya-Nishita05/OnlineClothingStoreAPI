using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineClothingStoreAPI.Data;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly BrandRepository brandRepository;

        public BrandController(BrandRepository brandRepository)
        {
            this.brandRepository = brandRepository;
        }

        [HttpGet]
        public IActionResult GetAllBrands()
        {
            var brands = brandRepository.SelectAll();
            return Ok(brands);
        }

        [HttpGet("{id}")]
        public IActionResult GetBrandByID(int id)
        {
            var brand = brandRepository.SelectByPK(id);

            if (id != brand.BrandId)
            {
                return NotFound();
            }

            return Ok(brand);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult InsertBrand([FromBody] BrandModel brand)
        {
            if (brand == null)
            {
                return BadRequest();
            }

            if (brandRepository.Insert(brand))
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public IActionResult UpdateBrand(int id, [FromBody] BrandModel brand)
        {
            if (brand == null || id != brand.BrandId)
            {
                return BadRequest();
            }

            if (brandRepository.Update(brand))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBrand(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (brandRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
