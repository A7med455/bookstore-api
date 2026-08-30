using BookStoreAPI.DTOs.User;

namespace BookStoreAPI.Services
{
    public interface IUserService
    {
        List<UserResponseDto> GetAll();
        UserResponseDto? GetById(int UserId);
    }
}