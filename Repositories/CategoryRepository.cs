using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;
        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category? GetById(int CategoryId)
        {
           return  _context.Categories.Find(CategoryId);
        }

        public Category Create(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return category;
        }

        public bool Update(int CategoryId,Category category)
        {
            var existingCategory = _context.Categories.Find(CategoryId);
            if(existingCategory == null)
            {
                return false;
            }
            existingCategory.CategoryId = category.CategoryId;
            existingCategory.CategoryType = category.CategoryType;
            existingCategory.Description = category.Description;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int CategoryId)
        {
            var existingCategory = _context.Categories.Find(CategoryId);
            if(existingCategory == null)
            {
                return false;
            }
            _context.Categories.Remove(existingCategory);
            _context.SaveChanges();
            return true;
        }
    }
}