using BookStoreAPI.Models;
namespace BookStoreAPI.DTOs.User
{
    public class UserResponseDto
    {
        public int UserId { get; set; }
        public required string Email { get; set; }
        public required Role Role { get; set; }
    }
}