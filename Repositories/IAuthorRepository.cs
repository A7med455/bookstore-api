using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public interface IAuthorRepository
    {
        List<Author> GetAll();
        Author? GetById(int AuthorId);
        Author Create(Author author);
        bool Update(int AuthorId,Author author);
        bool Delete(int AuthorId);
    }
}