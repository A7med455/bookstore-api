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
        public async Task<ActionResult<List<AuthorResponseDto>>> GetAll()
        {
            var authors = await _authorService.GetAll();
            return Ok(authors);
        }
 
        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorResponseDto>> GetById(int id)
        {
            var author = await _authorService.GetById(id);
            if (author == null)
            {
                return NotFound($"Author with ID {id} not found");
            }
            return Ok(author);
        }
        [HttpPost("admin")]
        public async Task<ActionResult<AuthorResponseDto>> CreateByAdmin(AuthorAdminCreateDto createDto)
        {
            try
            {
                var author = await _authorService.CreateByAdmin(createDto);
                return Ok(author);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpPost("register")]
        public async Task<ActionResult<AuthorResponseDto>> Register(AuthorRegisterDto registerDto)
        {
            try
            {
                var author = await _authorService.Register(registerDto);
                return Ok(author);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
 
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, AuthorUpdateDto updateDto)
        {
            try
            {
                var success = await _authorService.Update(id, updateDto);
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
        public async Task<ActionResult> Delete(int id)
        {
            var success = await _authorService.Delete(id);
            if (!success)
            {
                return NotFound($"Author with ID {id} not found");
            }
            return Ok($"Author with ID {id} deleted");
        }
    }
}