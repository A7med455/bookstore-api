using BookStoreAPI.DTOs.OrderItem;
using BookStoreAPI.Models;
namespace BookStoreAPI.DTOs.Order
{
    public class OrderResponseDto
    {
        public int OrderId{ get; set;} 
        public required int CustomerId{ get; set;}
        public required DateTime OrderDate{ get; set;}
        public required Status OrderStatus{ get; set;} 
        public required List<OrderItemResponseDto> OrderedItems{ get; set;}
    }
}