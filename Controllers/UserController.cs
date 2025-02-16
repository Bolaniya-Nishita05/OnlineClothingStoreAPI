using Microsoft.AspNetCore.Mvc;
using OnlineClothingStoreAPI.Data;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository userRepository;

        public UserController(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = userRepository.SelectAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserByID(int id)
        {
            var user = userRepository.SelectByPK(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult InsertUser([FromBody] UserModel user)
        {
            if (user == null)
            {
                return BadRequest();
            }

            if (userRepository.Insert(user))
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public IActionResult UpdateUser(int id, [FromBody] UserModel user)
        {
            if (user == null || id != user.UserID)
            {
                return BadRequest();
            }

            if (userRepository.Update(user))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }

            if (userRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }
    }
}
