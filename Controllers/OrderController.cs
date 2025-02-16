using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineClothingStoreAPI.Data;
using OnlineClothingStoreAPI.Models;

namespace OnlineClothingStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            this.orderRepository = orderRepository;
        }

        [HttpGet]
        public IActionResult GetAllOrders()
        {
            var orders = orderRepository.SelectAll();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public IActionResult GetOrderByID(int id)
        {
            var order = orderRepository.SelectByPK(id);

            if (id != order.OrderID)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult InsertOrder([FromBody] OrderModel order)
        {
            if (order == null)
            {
                return BadRequest();
            }

            if (orderRepository.Insert(order))
            {
                return Ok();
            }

            return StatusCode(500);
        }

        [HttpPut("{id}")]
        [Consumes("application/json")]
        public IActionResult UpdateOrder(int id, [FromBody] OrderModel order)
        {
            if (order == null || id != order.OrderID)
            {
                return BadRequest();
            }

            if (orderRepository.Update(order))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteOrder(int id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            if (orderRepository.Delete(id))
            {
                return NoContent();
            }

            return NotFound();
        }

        [HttpGet("OrdersByUser/{id}")]
        public IActionResult GetOrdersByUserID(int id)
        {
            var orders = orderRepository.SelectByUserID(id);

            if (!orders.Any())
            {
                return NotFound();
            }

            return Ok(orders);
        }
    }
}
