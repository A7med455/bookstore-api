using BookStoreAPI.DTOs.Author;

namespace BookStoreAPI.Services
{
    public interface IAuthorService
    {
        Task<List<AuthorResponseDto>> GetAll();
        Task<AuthorResponseDto?> GetById(int AuthorId);
        Task<AuthorResponseDto> Register(AuthorRegisterDto registerDto);
        Task<AuthorResponseDto> CreateByAdmin(AuthorAdminCreateDto createDto);
        Task<bool> Update(int AuthorId, AuthorUpdateDto dto);
        Task<bool> Delete(int AuthorId);

    }
}