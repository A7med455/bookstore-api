using BookStoreAPI.DTOs.User;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;

namespace BookStoreAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        private UserResponseDto MapToResponse(User user)
        {
            return new UserResponseDto
            {
                UserId = user.UserId,
                Email = user.Email,
                Role = user.Role
            };
        }
        public async Task<List<UserResponseDto>> GetAll()
        {
            List<User> users = await _userRepository.GetAll();
            List<UserResponseDto> Result = new List<UserResponseDto>();
            foreach(User user in users)
            {
                Result.Add(MapToResponse(user));
            } 
            return Result;
        }
        public async Task<UserResponseDto?> GetById(int UserId)
        {
            User? ExistingUser = await _userRepository.GetById(UserId);
            if(ExistingUser == null)
            {
                return null;
            }
            return MapToResponse(ExistingUser);
        }
    }
}