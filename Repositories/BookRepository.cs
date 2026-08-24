using BookStoreAPI.Data;
using BookStoreAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreAPI.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Book> GetAll()
        {
            return _context.Books.Include(b => b.Category).Include(b => b.Author).ToList();
        }

        public Book? GetById(int id)
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Category).FirstOrDefault(b => b.BookId == id);
        }
         
        public Book Create(Book book)
        {
            _context.Books.Add(book); //stage the change in memory , not saved in DB yet
            _context.SaveChanges();   //now it's saved in DB
            return book;
        }

        public bool Update(int id, Book book)
        {
            var existingBook = _context.Books.Find(id);
            if (existingBook == null)
            {
                return false;
            }
            existingBook.Title = book.Title;
            existingBook.ISBN = book.ISBN;
            existingBook.Price = book.Price;
            existingBook.Stock = book.Stock;
            existingBook.CategoryId = book.CategoryId;
            existingBook.AuthorId = book.AuthorId;
            existingBook.PublishedDate = book.PublishedDate;
            _context.Books.Update(existingBook);
            _context.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var existingBook = _context.Books.Find(id);
            if(existingBook == null)
            {
                return false;
            }
            _context.Books.Remove(existingBook);
            _context.SaveChanges();
            return true;
        }

    }
}