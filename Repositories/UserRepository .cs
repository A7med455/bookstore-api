using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<User> GetAll()
        {
            return _context.Users.ToList();
        }

        public User? GetById(int UserId)
        {
            return _context.Users.Find(UserId);
        }

        public User? GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }

        public User Create(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

        public bool Update(int UserId,User user)
        {
            var existingUser = _context.Users.Find(UserId);
            if(existingUser == null)
            {
                return false;
            }
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Role = user.Role;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int UserId)
        {
            var existingUser = _context.Users.Find(UserId);
            if(existingUser == null)
            {
                return false;
            }
            _context.Users.Remove(existingUser);
            _context.SaveChanges();
            return true;
        }
    }
}