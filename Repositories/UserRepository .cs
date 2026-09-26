using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly AppDbContext _context;
        public UserRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetAll()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User?> GetById(int UserId)
        {
            return await _context.Users.FindAsync(UserId);
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User> Create(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<bool> Update(int UserId,User user)
        {
            var existingUser = await _context.Users.FindAsync(UserId);
            if(existingUser == null)
            {
                return false;
            }
            existingUser.Email = user.Email;
            existingUser.PasswordHash = user.PasswordHash;
            existingUser.Role = user.Role;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int UserId)
        {
            var existingUser = await _context.Users.FindAsync(UserId);
            if(existingUser == null)
            {
                return false;
            }
            _context.Users.Remove(existingUser);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}