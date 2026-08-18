namespace BookStoreAPI.Models
{
    public class Customer
    {
        public int CustomerId{ get; set;} // auto incremented in DB
        public required int UserId{ get; set;} //should  sent a copy when creating an obj
        public required string AccountUserName{ get; set;}
        public required string Name{ get; set;}
        public required int Age{ get; set;}
    }
}