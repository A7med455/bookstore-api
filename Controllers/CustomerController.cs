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
        public ActionResult<List<CustomerResponseDto>> GetAll()
        {
            return Ok(_customerService.GetAll());
        }
 
        [HttpGet("{id}")]
        public ActionResult<CustomerResponseDto> GetById(int id)
        {
            var customer = _customerService.GetById(id);
            if (customer == null)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return Ok(customer);
        }
 
        [HttpPost]
        public ActionResult<CustomerResponseDto> Create(CustomerRegisterDto registerDto)
        {
            try
            {
                var customer = _customerService.Create(registerDto);
                return Ok(customer);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpPut("{id}")]
        public ActionResult Update(int id, CustomerUpdateDto updateDto)
        {
            try
            {
                var success = _customerService.Update(id, updateDto);
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
        public ActionResult Delete(int id)
        {
            var success = _customerService.Delete(id);
            if (!success)
            {
                return NotFound($"Customer with ID {id} not found");
            }
            return Ok($"Customer with ID {id} deleted");
        }
    }
}