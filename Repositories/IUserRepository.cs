using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetById(int userId);
        Task<User?> GetByEmail(string email);   // needed for login lookups later
        Task<User> Create(User user);
        Task<bool> Update(int userId, User user);
        Task<bool> Delete(int userId);
    }
}