using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Author>> GetAll()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetById(int AuthorId)
        {
            return await _context.Authors.FindAsync(AuthorId);
        }

        public async Task<Author> Create(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }
        
        public async Task<bool> Update(int AuthorId,Author author)
        {
            var existingAuthor = await _context.Authors.FindAsync(AuthorId);
            if(existingAuthor == null)
            {
                return false;
            }
            existingAuthor.UserId = author.UserId;
            existingAuthor.Name = author.Name;
            existingAuthor.Bio = author.Bio;
            existingAuthor.Age = author.Age;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int AuthorId)
        {
            var existingAuthor = await _context.Authors.FindAsync(AuthorId);
            if(existingAuthor == null)
            {
                return false;
            }
            _context.Authors.Remove(existingAuthor);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}