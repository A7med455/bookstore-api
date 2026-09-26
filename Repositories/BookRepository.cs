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

        public async Task<List<Book>> GetAll()
        {
            return await _context.Books.Include(b => b.Category).Include(b => b.Author).ToListAsync();
        }

        public async Task<Book?> GetById(int id)
        {
            return await _context.Books.Include(b => b.Author).Include(b => b.Category).FirstOrDefaultAsync(b => b.BookId == id);
        }
         
        public async Task<Book> Create(Book book)
        {
            _context.Books.Add(book); //stage the change in memory , not saved in DB yet
            await _context.SaveChangesAsync();   //now it's saved in DB
            return  book;
        }

        public async Task<bool> Update(int id, Book book)
        {
            var existingBook = await _context.Books.FindAsync(id);
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
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Delete(int id)
        {
            var existingBook = await _context.Books.FindAsync(id);
            if(existingBook == null)
            {
                return false;
            }
            _context.Books.Remove(existingBook);
            await _context.SaveChangesAsync();
            return true;
        }

    }
}