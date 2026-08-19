namespace BookStoreAPI.DTOs.Author
{
    public class AuthorResponseDto
    {
         public int AuthorId{ get; set;} 
        public required string Name{ get; set;}
        public string? Bio{ get; set;} //optional if not existed will not be sent
        public required int Age{ get; set;}
    }
}