using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Category>> GetAll()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category?> GetById(int CategoryId)
        {
           return  await _context.Categories.FindAsync(CategoryId);
        }

        public async Task<Category> Create(Category category)
        {
            _context.Categories.Add(category);
            await _context.SaveChangesAsync();
            return category;
        }

        public async Task<bool> Update(int CategoryId,Category category)
        {
            var existingCategory = await _context.Categories.FindAsync(CategoryId);
            if(existingCategory == null)
            {
                return false;
            }
            existingCategory.CategoryType = category.CategoryType;
            existingCategory.Description = category.Description;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int CategoryId)
        {
            var existingCategory = await _context.Categories.FindAsync(CategoryId);
            if(existingCategory == null)
            {
                return false;
            }
            _context.Categories.Remove(existingCategory);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}