using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineClothingStoreAPI.Data;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FavouriteController : ControllerBase
    {
        private readonly FavouriteRepository favouriteRepository;

        public FavouriteController(FavouriteRepository favouriteRepository)
        {
            this.favouriteRepository = favouriteRepository;
        }

        [HttpGet]
        public IActionResult GetAllFavouritess()
        {
            var favourites = favouriteRepository.SelectAll();
            return Ok(favourites);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult InsertFavourite([FromBody] FavouriteModel favourite)
        {
            if (favourite == null)
            {
                return BadRequest();
            }

            if (favouriteRepository.Insert(favourite))
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFavourite(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (favouriteRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("FavouritesByUser/{id}")]
        public IActionResult GetFavouritesByUserID(int id)
        {
            var favourites = favouriteRepository.SelectByUserID(id);

            if (!favourites.Any())
            {
                return NotFound();
            }

            return Ok(favourites);
        }
    }
}
