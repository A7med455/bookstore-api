using BookStoreAPI.Models;
namespace BookStoreAPI.Repositories
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAll();
        Task<Category?> GetById(int CategoryId);
        Task<Category> Create(Category category);
        Task<bool> Update(int CategoryId,Category category);
        Task<bool> Delete(int CategoryId);

    }
}