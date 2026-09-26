using BookStoreAPI.DTOs.Author;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;
using Microsoft.AspNetCore.Identity;

namespace BookStoreAPI.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUserRepository _userRepository;
        public AuthorService(IAuthorRepository authorRepository, IUserRepository userRepository)
        {
            _authorRepository = authorRepository;
            _userRepository = userRepository;
        }
        private AuthorResponseDto MapToResponseDto(Author author)
        {
            return new AuthorResponseDto
            {
                AuthorId =author.AuthorId,
                Name = author.Name,
                Bio = author.Bio,
                Age = author.Age
            };
        }
        private Author MapToAuthor(AuthorAdminCreateDto createDto)
        {
            return new Author
            {
                Name = createDto.Name,
                Bio = createDto.Bio,
                Age = createDto.Age
            };
        }
        public async Task<AuthorResponseDto> Register(AuthorRegisterDto registerDto)
        {
            var hasher = new PasswordHasher<User>();
            string hashedPassword = hasher.HashPassword(null!,registerDto.Password);

            User NewUser = new User
            {
                Email = registerDto.Email,
                PasswordHash = hashedPassword,
                Role = Role.Author
            };
            User CreatedUser =  await _userRepository.Create(NewUser);
            Author NewAuthor = new Author
            {
                UserId = CreatedUser.UserId,
                Name = registerDto.Name,
                Bio = registerDto.Bio,
                Age = registerDto.Age
            };
            Author CreatedAuthor = await _authorRepository.Create(NewAuthor);
            return MapToResponseDto(CreatedAuthor);
        }
        public async Task<AuthorResponseDto> CreateByAdmin(AuthorAdminCreateDto dto)
        {
            if(string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            Author newAuthor = MapToAuthor(dto);
            Author createdAuthor = await _authorRepository.Create(newAuthor);
            return MapToResponseDto(createdAuthor);
        }
        public async Task<List<AuthorResponseDto>> GetAll()
        {
            List<Author> authors = await _authorRepository.GetAll();
            List<AuthorResponseDto> result = new List<AuthorResponseDto>();
            foreach (Author author in authors)
            {
                result.Add(MapToResponseDto(author));
            }
            return result;
        }
        public async Task<AuthorResponseDto?> GetById(int AuthorId)
        {
            Author? author = await _authorRepository.GetById(AuthorId);
            if (author == null)
            { 
                return null;
            }
            return MapToResponseDto(author);
        }
        public async Task<bool> Update(int AuthorId, AuthorUpdateDto dto)
        {
            Author? existingAuthor = await _authorRepository.GetById(AuthorId);
            if (existingAuthor == null) 
            {
                return false;
            }
            if (dto.Name != null && string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }

            if (dto.Name != null) 
            {
                existingAuthor.Name = dto.Name;
            }
            if (dto.Bio != null)
            {
                existingAuthor.Bio = dto.Bio;
            }
            if (dto.Age.HasValue)
            { 
                existingAuthor.Age = dto.Age.Value;
            }
            await _authorRepository.Update(AuthorId, existingAuthor);
            return true;
        }
        public async Task<bool> Delete(int AuthorId)
        {
            Author? existingAuthor = await _authorRepository.GetById(AuthorId);
            if (existingAuthor == null)
            { 
                return false;
            }
            bool AuthorDeleted = await _authorRepository.Delete(AuthorId);
            if(AuthorDeleted && existingAuthor.UserId.HasValue)
            {
                await _userRepository.Delete(existingAuthor.UserId.Value);
            }
            return AuthorDeleted;
        }
        
    }
}