using BookStoreAPI.DTOs.Order;
using BookStoreAPI.Models;
namespace BookStoreAPI.Services
{
    public interface IOrderService
    {
        List<OrderResponseDto> GetAll();
        OrderResponseDto? GetById(int OrderId);
        OrderResponseDto Create(OrderCreateDto createDto);
        bool UpdateStatus(int OrderId, Status newStatus);
    }
}