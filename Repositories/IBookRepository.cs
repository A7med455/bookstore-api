using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IBookRepository
    {
        Task<List<Book>> GetAll();
        Task<Book?> GetById(int id);
        Task<Book> Create(Book book);
        Task<bool> Update(int id, Book book);
        Task<bool> Delete(int id);
    }
}
