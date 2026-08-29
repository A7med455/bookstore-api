using BookStoreAPI.DTOs.Book;
using BookStoreAPI.DTOs.Category;
using BookStoreAPI.DTOs.Author;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;
namespace BookStoreAPI.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _BookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _BookRepository = bookRepository;   
        }
        private BookResponseDto MapToResponseDto(Book book)
        {
             return new BookResponseDto
            {
                BookId = book.BookId,
                Title = book.Title,
                ISBN = book.ISBN,
                Stock = book.Stock,
                Price = book.Price,
                PublishedDate = book.PublishedDate,
                Category = new CategoryResponseDto
                {
                    CategoryId = book.Category!.CategoryId,
                    CategoryType = book.Category.CategoryType,
                    Description = book.Category.Description
                },
                Author = new AuthorResponseDto
                {
                    AuthorId = book.Author!.AuthorId,
                    Name = book.Author.Name,
                    Bio = book.Author.Bio,
                    Age = book.Author.Age
                }
            };
        }
        private Book MapToBook(BookCreateDto dto)
        {
            return new Book
            {
                Title = dto.Title,
                ISBN = dto.ISBN,
                Stock = dto.Stock,
                Price = dto.Price,
                PublishedDate = dto.PublishedDate,
                CategoryId = dto.CategoryId,
                AuthorId = dto.AuthorId
            };
        }
        public List<BookResponseDto> GetAll()
        {
            List<Book> books = _BookRepository.GetAll();
            List<BookResponseDto> result = new List<BookResponseDto>();

            foreach(Book book in books)
            {
                result.Add(MapToResponseDto(book));
            }
            return result;
        }

        public BookResponseDto? GetById(int BookId)
        {
            Book? book = _BookRepository.GetById(BookId);
            if(book == null)
            {
                return null;
            }
            return MapToResponseDto(book);
        }
        public BookResponseDto Create(BookCreateDto BookDto)
        {
            if(BookDto.Price < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            if(BookDto.Stock < 0)
            {
                throw new ArgumentException("Stock cannot be negative");
            }
            if(string.IsNullOrWhiteSpace(BookDto.Title))
            {
                throw new ArgumentException("Title cannot be empty");
            }

            Book NewBook = MapToBook(BookDto);
            Book CreatedBook = _BookRepository.Create(NewBook);
            Book? BookWithDetails = _BookRepository.GetById(CreatedBook.BookId);
            return MapToResponseDto(BookWithDetails!);
        }
        public bool Update(int BookId, BookUpdateDto BookDto)
        {
            Book? ExistingBook = _BookRepository.GetById(BookId);
            if(ExistingBook == null)
            {
                return false;
            }

            if(BookDto.Price.HasValue && BookDto.Price.Value < 0)
            {
                throw new ArgumentException("Price cannot be negative");
            }
            if(BookDto.Stock.HasValue && BookDto.Stock < 0)
            {
                throw new ArgumentException("Stock cannot be negative");
            }
            if(BookDto.Title != null && string.IsNullOrWhiteSpace(BookDto.Title))
            {
                throw new ArgumentException("Title cannot be empty");
            }
            if(BookDto.PublishedDate.HasValue && BookDto.PublishedDate.Value > DateTime.UtcNow)
            {
                throw new ArgumentException("Published date cannot be in the future");
            }
            if(BookDto.Title != null)
            {
                ExistingBook.Title = BookDto.Title;
            }
            if(BookDto.ISBN != null)
            {
                ExistingBook.ISBN = BookDto.ISBN!;
            }
            if(BookDto.Stock.HasValue)
            {
                ExistingBook.Stock = BookDto.Stock.Value;
            }
            if(BookDto.Price.HasValue)
            {
                ExistingBook.Price = BookDto.Price.Value;
            }
            if(BookDto.PublishedDate.HasValue)
            {
                ExistingBook.PublishedDate = BookDto.PublishedDate.Value;
            }
            _BookRepository.Update(BookId,ExistingBook);
            return true;
        }
        public bool Delete(int BookId)
        {
            Book? ExistingBook = _BookRepository.GetById(BookId);
            if(ExistingBook == null)
            {
                return false;
            }
            return _BookRepository.Delete(BookId);
        }
    }   
}