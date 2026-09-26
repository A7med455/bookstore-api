using BookStoreAPI.DTOs.Book;
using BookStoreAPI.Models;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookResponseDto>>> GetAll()
        {
            var books = await _bookService.GetAll();
            return Ok(books);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<BookResponseDto>> GetById(int id)
        {
            var book = await _bookService.GetById(id);
            if(book == null)
            {
                return NotFound($"Book With ID {id} not found");
            }
            return Ok(book);
        }
        [HttpPost]
        public async Task<ActionResult<BookResponseDto>> Create(BookCreateDto createDto)
        {
            try
            {
                var Book = await _bookService.Create(createDto);
                return Ok(Book);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,BookUpdateDto updateDto)
        {
            try
            {
                var Success = await _bookService.Update(id,updateDto);
                if(!Success)
                {
                    return NotFound($"Book with ID {id} not found");
                }
                return Ok($"Book with ID {id} updated");
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var Success = await _bookService.Delete(id);
            if(!Success)
            {
                return NotFound($"Book with ID {id} not found");
            }
            return Ok($"Book with ID {id} deleted");
        }
    }
}