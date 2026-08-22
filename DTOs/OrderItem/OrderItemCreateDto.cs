namespace BookStoreAPI.DTOs.OrderItem
{
    public class OrderItemCreateDto
    {
        public required int BookId{ get; set;}
        public required int Quantity{ get; set;}
    }
}