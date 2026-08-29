using BookStoreAPI.DTOs.Book;
namespace BookStoreAPI.Services
{
    public interface IBookService
    {
            List<BookResponseDto> GetAll();
            BookResponseDto? GetById(int BookId);
            BookResponseDto Create(BookCreateDto dto);
            bool Update(int BookId,BookUpdateDto dto);
            bool Delete(int BookId);
    
    }
}