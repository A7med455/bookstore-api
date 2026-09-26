using BookStoreAPI.DTOs.Customer;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomersController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
 
        [HttpGet]
        public async Task<ActionResult<List<CustomerResponseDto>>> GetAll()
        {
            var Customers = await _customerService.GetAll();
            return Ok(Customers);
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerResponseDto>> GetById(int id)
        {
            var customer = await _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return Ok(customer);
        }
 
        [HttpPost]
        public async Task<ActionResult<CustomerResponseDto>> Create(CustomerRegisterDto registerDto)
        {
            try
            {
                var customer = await _customerService.Create(registerDto);
                return Ok(customer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, CustomerUpdateDto updateDto)
        {
            try
            {
                var success = await _customerService.Update(id, updateDto);
                if (!success)
                {
                    return NotFound($"Customer with ID {id} not found");
                }
                return Ok($"Customer with ID {id} updated");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _customerService.Delete(id);
            if (!success)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return Ok($"Customer with ID {id} deleted");
        }
    }
}