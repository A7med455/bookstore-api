using BookStoreAPI.Models;
namespace BookStoreAPI.DTOs.Payment
{
    public class PaymentCreateDto
    {
        public int PaymentId{ get; set;}
         public required PaymentMethod PaymentMethod{ get; set;}
    }
}