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
        public ActionResult<List<CategoryResponseDto>> GetAll()
        {
            return Ok(_categoryService.GetAll());
        }
        [HttpGet("{id}")]
        public ActionResult<CategoryResponseDto> GetById(int id)
        {
            var Category = _categoryService.GetById(id);
            if(Category == null)
            {
                return NotFound($"Category with ID {id} not found");
            }
            return Ok(Category);
        }
        [HttpPost]
        public ActionResult<CategoryResponseDto> Create(CategoryCreateDto createDto)
        {
            try
            {
                var category = _categoryService.Create(createDto);
                return Ok(category);
            }
            catch(ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id,CategoryUpdateDto updateDto)
        {
            try
            {
                var Success = _categoryService.Update(id,updateDto);
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
        public ActionResult Delete(int id)
        {
                var Success = _categoryService.Delete(id);
                if(!Success)
                {
                    return NotFound($"Category with ID {id} not found");
                }
                return Ok($"Category with ID {id} deleted");
        }
    }
}