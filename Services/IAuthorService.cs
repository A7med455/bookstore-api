using BookStoreAPI.DTOs.Author;

namespace BookStoreAPI.Services
{
    public interface IAuthorService
    {
        List<AuthorResponseDto> GetAll();
        AuthorResponseDto? GetById(int AuthorId);
        AuthorResponseDto Register(AuthorRegisterDto registerDto);
        AuthorResponseDto CreateByAdmin(AuthorAdminCreateDto createDto);
        bool Update(int AuthorId, AuthorUpdateDto dto);
        bool Delete(int AuthorId);

    }
}