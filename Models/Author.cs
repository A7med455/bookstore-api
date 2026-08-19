namespace BookStoreAPI.Models
{
    public class Author
    {
        public int AuthorId{ get; set;} //auto incremented in DB
        public int? UserId{ get; set;} 
        public required string Name{ get; set;}
        public string? Bio{ get; set;}
        public required int Age{ get; set;}//should be provided in post to avoid fake accounts
    }
}