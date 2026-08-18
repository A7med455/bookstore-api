namespace BookStoreAPI.Models
{
    public class Category
    {
        public  int CategoryId{ get; set;} //auto incremented in DB
        public required string CategoryType{ get; set;}
        public string? Description{ get; set;}
    }
}