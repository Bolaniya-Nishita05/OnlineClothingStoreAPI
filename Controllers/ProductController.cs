using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineClothingStoreAPI.Data;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository productRepository;

        public ProductController(ProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAllProducts()
        {
            var products = productRepository.SelectAll();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public IActionResult GetProductByID(int id)
        {
            var product = productRepository.SelectByPK(id);

            if (id != product.ProductID)
            {
                return NotFound();
            }

            return Ok(product);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult InsertProduct([FromBody] ProductModel product)
        {
            if (product == null)
            {
                return BadRequest();
            }

            if (productRepository.Insert(product))
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public IActionResult UpdateProduct(int id, [FromBody] ProductModel product)
        {
            if (product == null || id != product.ProductID)
            {
                return BadRequest();
            }

            if (productRepository.Update(product))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (productRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("ProductsByCategory/{CategoryID}")]
        public IActionResult GetProductByCategoryID(int CategoryID)
        {
            var products = productRepository.SelectByCategoryID(CategoryID);

            if(!products.Any())
            {
                return NotFound("Enter Valid CategoryID");
            }

            return Ok(products);
        }

        [HttpGet("ProductsByBrand/{BrandID}")]
        public IActionResult GetProductByBrandID(int BrandID)
        {
            var products = productRepository.SelectByBrandID(BrandID);

            if(!products.Any())
            {
                return NotFound("Enter valid BrandID");
            }

            return Ok(products);
        }

        [HttpGet("Categories")]
        public IActionResult GetCategories()
        {
            var categories = productRepository.GetCategories();

            if (!categories.Any())
            {
                return NotFound("No categories found");
            }

            return Ok(categories);
        }

        [HttpGet("Brands")]
        public IActionResult GetBrands()
        {
            var brands = productRepository.GetBrands();

            if (!brands.Any())
            {
                return NotFound("No brands found");
            }

            return Ok(brands);
        }
    }
}
