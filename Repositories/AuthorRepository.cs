using BookStoreAPI.Data;
using BookStoreAPI.Models;

namespace BookStoreAPI.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly AppDbContext _context;
        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }
        public List<Author> GetAll()
        {
            return _context.Authors.ToList();
        }

        public Author? GetById(int AuthorId)
        {
            return _context.Authors.Find(AuthorId);
        }

        public Author Create(Author author)
        {
            _context.Authors.Add(author);
            _context.SaveChanges();
            return author;
        }
        
        public bool Update(int AuthorId,Author author)
        {
            var existingAuthor = _context.Authors.Find(AuthorId);
            if(existingAuthor == null)
            {
                return false;
            }
            existingAuthor.UserId = author.UserId;
            existingAuthor.Name = author.Name;
            existingAuthor.Bio = author.Bio;
            existingAuthor.Age = author.Age;
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int AuthorId)
        {
            var existingAuthor = _context.Authors.Find(AuthorId);
            if(existingAuthor == null)
            {
                return false;
            }
            _context.Authors.Remove(existingAuthor);
            _context.SaveChanges();
            return true;
        }
    }
}