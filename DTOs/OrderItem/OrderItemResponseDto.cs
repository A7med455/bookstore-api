namespace BookStoreAPI.DTOs.OrderItem
{
    public class OrderItemResponseDto
    {
        public int ItemId{ get; set;}
        public required int BookId{ get; set;}
        public required int Quantity{ get; set;}
        public required decimal PriceAtPurchase{ get; set;}
    }
}