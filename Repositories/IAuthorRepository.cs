using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAll();
        Task<Author?> GetById(int AuthorId);
        Task<Author> Create(Author author);
        Task<bool> Update(int AuthorId,Author author);
        Task<bool> Delete(int AuthorId);
    }
}