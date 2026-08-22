namespace BookStoreAPI.DTOs.Author
{
    public class AuthorAdminCreateDto
    {
        public required string Name{ get; set;}
        public string? Bio{ get; set;}
        public required int Age{ get; set;}
    }
}