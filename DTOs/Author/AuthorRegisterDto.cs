namespace BookStoreAPI.DTOs.Author
{
    public class AuthorRegisterDto
    {
        public required string Email{ get; set;}
        public required string Password{ get; set;}
        public required string Name{ get; set;}
        public string? Bio{ get; set;}
        public required int Age{ get; set;}
    }
}