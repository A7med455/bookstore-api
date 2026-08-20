using BookStoreAPI.DTOs.OrderItem;
using BookStoreAPI.Models;
namespace BookStoreAPI.DTOs.Order
{
    public class OrderCreateDto
    {
        public required List<OrderItemCreateDto> OrderedItems{ get; set;}
        public required int CustomerId{ get; set;}//it will be removed once JWT auth is added
    }
}