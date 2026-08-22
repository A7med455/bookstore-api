using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User? GetById(int userId);
        User? GetByEmail(string email);   // needed for login lookups later
        User Create(User user);
        bool Update(int userId, User user);
        bool Delete(int userId);
    }
}