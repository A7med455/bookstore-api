using BookStoreAPI.DTOs.Payment;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IPaymentService
    {
        List<PaymentResposeDto> GetAll();
        PaymentResposeDto? GetById(int PaymentId);
        PaymentResposeDto Create(PaymentCreateDto createDto);
        bool UpdateStatus(int PaymentId,PaymentUpdateDto updateDto); 
    }
}