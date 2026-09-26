using BookStoreAPI.DTOs.User;

namespace BookStoreAPI.Services
{
    public interface IUserService
    {
        Task<List<UserResponseDto>> GetAll();
        Task<UserResponseDto?> GetById(int UserId);
    }
}