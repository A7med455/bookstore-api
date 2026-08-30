using BookStoreAPI.Models;
namespace BookStoreAPI.DTOs.Payment
{
    public class PaymentUpdateDto
    {
        public PaymentStatus? PaymentStatus { get; set;}
        public string? TransactionReference { get; set;}
    }
}