namespace BookStoreAPI.Models
{
    public class OrderItem
    {
        public int ItemId{ get; set;}
        public required int OrderId{ get; set;}
        public required int BookId{ get; set;}
        public required int Quantity{ get; set;}
        public required decimal PriceAtPurchase{ get; set;}
    }
}