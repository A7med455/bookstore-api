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
        public required Status OrderStatus{ get; set;} // how it is gonna be tracked it will be changing from state to state 

    }
}