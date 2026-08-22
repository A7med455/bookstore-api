using BookStoreAPI.Models;
namespace BookStoreAPI.DTOs.Payment
{
    public class PaymentCreateDto
    {
        public required int OrderId{ get; set;}
         public required PaymentMethod PaymentMethod{ get; set;}
    }
}