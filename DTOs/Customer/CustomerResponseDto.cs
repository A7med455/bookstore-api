namespace BookStoreAPI.DTOs.Customer
{
    public class CustomerResponseDto
    {
        public int CustomerId{ get; set;} 
        public string Email{ get; set;}
        public required string AccountUserName{ get; set;}
        public required string Name{ get; set;}
        public required int Age{ get; set;}
    }
}