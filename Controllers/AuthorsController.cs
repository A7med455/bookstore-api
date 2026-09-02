using BookStoreAPI.DTOs.Author;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;
 
namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }
 
        [HttpGet]
        public ActionResult<List<AuthorResponseDto>> GetAll()
        {
            return Ok(_authorService.GetAll());
        }
 
        [HttpGet("{id}")]
        public ActionResult<AuthorResponseDto> GetById(int id)
        {
            var author = _authorService.GetById(id);
            if (author == null)
            {
                return NotFound($"Author with ID {id} not found");
            }
            return Ok(author);
        }
        [HttpPost("admin")]
        public ActionResult<AuthorResponseDto> CreateByAdmin(AuthorAdminCreateDto createDto)
        {
            try
            {
                var author = _authorService.CreateByAdmin(createDto);
                return Ok(author);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpPost("register")]
        public ActionResult<AuthorResponseDto> Register(AuthorRegisterDto registerDto)
        {
            try
            {
                var author = _authorService.Register(registerDto);
                return Ok(author);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpPut("{id}")]
        public ActionResult Update(int id, AuthorUpdateDto updateDto)
        {
            try
            {
                var success = _authorService.Update(id, updateDto);
                if (!success)
                {
                    return NotFound($"Author with ID {id} not found");
                }
                return Ok($"Author with ID {id} updated");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var success = _authorService.Delete(id);
            if (!success)
            {
                return NotFound($"Author with ID {id} not found");
            }
            return Ok($"Author with ID {id} deleted");
        }
    }
}