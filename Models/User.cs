
namespace BookStoreAPI.Models
{
    public enum Role
    {
        Admin,
        Author,
        Customer
    }
    public class User
    {
        public int UserId{ get; set;} //auto incremented in DB
        public required string Email{ get; set;}
        public required string PasswordHash{ get; set;}
        public required Role Role{ get; set;}
    }
}