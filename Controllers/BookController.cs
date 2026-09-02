using BookStoreAPI.DTOs.Book;
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
        public ActionResult<List<BookResponseDto>> GetAll()
        {
            return Ok(_bookService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<BookResponseDto> GetById(int id)
        {
            var book = _bookService.GetById(id);
            if(book == null)
            {
                return NotFound($"Book With ID {id} not found");
            }
            return Ok(book);
        }
        [HttpPost]
        public ActionResult<BookResponseDto> Create(BookCreateDto createDto)
        {
            try
            {
                var Book = _bookService.Create(createDto);
                return Ok(Book);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id,BookUpdateDto updateDto)
        {
            try
            {
                var Success = _bookService.Update(id,updateDto);
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
        public ActionResult Delete(int id)
        {
            var Success = _bookService.Delete(id);
            if(!Success)
            {
                return NotFound($"Book with ID {id} not found");
            }
            return Ok($"Book with ID {id} deleted");
        }
    }
}