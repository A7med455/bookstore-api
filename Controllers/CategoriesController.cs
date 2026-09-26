using BookStoreAPI.DTOs.Category;
using BookStoreAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public async Task<ActionResult<List<CategoryResponseDto>>> GetAll()
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryResponseDto>> GetById(int id)
        {
            var Category = await _categoryService.GetById(id);
            if(Category == null)
            {
                return NotFound($"Category with ID {id} not found");
            }
            return Ok(Category);
        }
        [HttpPost]
        public async Task<ActionResult<CategoryResponseDto>> Create(CategoryCreateDto createDto)
        {
            try
            {
                var category = await _categoryService.Create(createDto);
                return Ok(category);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id,CategoryUpdateDto updateDto)
        {
            try
            {
                var Success = await _categoryService.Update(id,updateDto);
                if(!Success)
                {
                    return NotFound($"Category with ID {id} not found");
                }
                return Ok($"Category with ID {id} updated");
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
                var Success = await _categoryService.Delete(id);
                if(!Success)
                {
                    return NotFound($"Category with ID {id} not found");
                }
                return Ok($"Category with ID {id} deleted");
        }
    }
}