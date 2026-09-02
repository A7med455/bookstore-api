using BookStoreAPI.DTOs.Order;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
 
        [HttpGet]
        public ActionResult<List<OrderResponseDto>> GetAll()
        {
            return Ok(_orderService.GetAll());
        }
 
        [HttpGet("{id}")]
        public ActionResult<OrderResponseDto> GetById(int id)
        {
            var order = _orderService.GetById(id);
            if (order == null)
            {
                return NotFound($"Order with ID {id} not found");
            }
            return Ok(order);
        }
 
        [HttpPost]
        public ActionResult<OrderResponseDto> Create(OrderCreateDto createDto)
        {
            try
            {
                var order = _orderService.Create(createDto);
                return Ok(order);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, [FromBody] Status newStatus)
        {
            var success = _orderService.UpdateStatus(id, newStatus);
            if (!success)
            {
                return NotFound($"Order with ID {id} not found");
            }
            return Ok($"Order with ID {id} status updated");
        }
    }
}