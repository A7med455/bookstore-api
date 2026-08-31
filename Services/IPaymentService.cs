using BookStoreAPI.DTOs.Payment;
using BookStoreAPI.Models;

namespace BookStoreAPI.Services
{
    public interface IPaymentService
    {
        List<PaymentResponseDto> GetAll();
        PaymentResponseDto? GetById(int PaymentId);
        PaymentResponseDto Create(PaymentCreateDto createDto);
        bool UpdateStatus(int PaymentId,PaymentUpdateDto updateDto); 
    }
}