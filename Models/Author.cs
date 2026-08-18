namespace BookStoreAPI.Models
{
    public class Author
    {
        public int AuthorId{ get; set;} //auto incremented in DB
        public required int UserId{ get; set;} // what is the scenario like when creating author obj his intial userid if yes the should be provided 
        public required string Name{ get; set;}
        public required string Bio{ get; set;}//it could be optional but so client know more about Author
        public required int Age{ get; set;}//should be provided in post to avoid fake accounts
    }
}