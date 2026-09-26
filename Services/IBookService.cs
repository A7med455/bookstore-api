using BookStoreAPI.DTOs.Book;
namespace BookStoreAPI.Services
{
    public interface IBookService
    {
            Task<List<BookResponseDto>> GetAll();
            Task<BookResponseDto?> GetById(int BookId);
            Task<BookResponseDto> Create(BookCreateDto dto);
            Task<bool> Update(int BookId,BookUpdateDto dto);
            Task<bool> Delete(int BookId);
    
    }
}