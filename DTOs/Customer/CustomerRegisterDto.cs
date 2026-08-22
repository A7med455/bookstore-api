namespace BookStoreAPI.DTOs.Customer
{
    public class CustomerRegisterDto
    {
        public required string Email{ get; set;}
        public required string Password{ get; set;}
        public required string AccountUserName{ get; set;}
        public required string Name{ get; set;}
        public required int Age{ get; set;}
    }
}