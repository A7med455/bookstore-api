using BookStoreAPI.DTOs.Payment;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentsController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentsController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }
 
        [HttpGet]
        public ActionResult<List<PaymentResponseDto>> GetAll()
        {
            return Ok(_paymentService.GetAll());
        }
 
        [HttpGet("{id}")]
        public ActionResult<PaymentResponseDto> GetById(int id)
        {
            var payment = _paymentService.GetById(id);
            if (payment == null)
            {
                return NotFound($"Payment with ID {id} not found");
            }
            return Ok(payment);
        }
 
        [HttpPost]
        public ActionResult<PaymentResponseDto> Create(PaymentCreateDto createDto)
        {
            try
            {
                var payment = _paymentService.Create(createDto);
                return Ok(payment);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpPut("{id}/status")]
        public ActionResult UpdateStatus(int id, PaymentUpdateDto updateDto)
        {
            try
            {
                var success = _paymentService.UpdateStatus(id, updateDto);
                if (!success)
                {
                    return NotFound($"Payment with ID {id} not found");
                }
                return Ok($"Payment with ID {id} status updated");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}