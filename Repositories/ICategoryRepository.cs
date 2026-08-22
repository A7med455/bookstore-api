using BookStoreAPI.Models;
namespace BookStoreAPI.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category? GetById(int CategoryId);
        Category Create(Category category);
        bool Update(int CategoryId,Category category);
        bool Delete(int CategoryId);

    }
}