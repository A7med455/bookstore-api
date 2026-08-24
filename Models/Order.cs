namespace BookStoreAPI.Models
{
    public enum Status
    {
        Delivered,
        Pending,
        Shipped,
        Cancelled        
    }
    public class Order
    {
        public int OrderId{ get; set;} //auto incremented in DB
        public required int CustomerId{ get; set;}//a copy  is required when creating an obj
        public required DateTime OrderDate{ get; set;}
        public required Status OrderStatus{ get; set;} 
        public List<OrderItem> Items{ get; set;} = new(); // when a new Order is created immediately give Items an empty list so start with 
    }
}