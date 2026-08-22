using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAll();
        Book? GetById(int id);
        Book Create(Book book);
        bool Update(int id, Book book);
        bool Delete(int id);
    }
}
