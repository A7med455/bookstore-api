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
        public AuthorResponseDto Register(AuthorRegisterDto registerDto)
        {
            var hasher = new PasswordHasher<User>();
            string hashedPassword = hasher.HashPassword(null!,registerDto.Password);

            User NewUser = new User
            {
                Email = registerDto.Email,
                PasswordHash = hashedPassword,
                Role = Role.Author
            };
            User CreatedUser = _userRepository.Create(NewUser);

            Author NewAuthor = new Author
            {
                UserId = CreatedUser.UserId,
                Name = registerDto.Name,
                Bio = registerDto.Bio,
                Age = registerDto.Age
            };
            Author CreatedAuthor = _authorRepository.Create(NewAuthor);
            return MapToResponseDto(CreatedAuthor);
        }
        public AuthorResponseDto CreateByAdmin(AuthorAdminCreateDto dto)
        {
            if(string.IsNullOrWhiteSpace(dto.Name))
            {
                throw new ArgumentException("Name cannot be empty");
            }
            Author newAuthor = MapToAuthor(dto);
            Author createdAuthor = _authorRepository.Create(newAuthor);
            return MapToResponseDto(createdAuthor);
        }
        public List<AuthorResponseDto> GetAll()
        {
            List<Author> authors = _authorRepository.GetAll();
            List<AuthorResponseDto> result = new List<AuthorResponseDto>();
            foreach (Author author in authors)
            {
                result.Add(MapToResponseDto(author));
            }
            return result;
        }
        public AuthorResponseDto? GetById(int AuthorId)
        {
            Author? author = _authorRepository.GetById(AuthorId);
            if (author == null)
            { 
                return null;
            }
            return MapToResponseDto(author);
        }
        public bool Update(int AuthorId, AuthorUpdateDto dto)
        {
            Author? existingAuthor = _authorRepository.GetById(AuthorId);
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
            _authorRepository.Update(AuthorId, existingAuthor);
            return true;
        }
        public bool Delete(int AuthorId)
        {
            Author? existingAuthor = _authorRepository.GetById(AuthorId);
            if (existingAuthor == null)
            { 
                return false;
            }
            return _authorRepository.Delete(AuthorId);
        }
        
    }
}