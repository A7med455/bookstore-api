using BookStoreAPI.DTOs.Category;

namespace BookStoreAPI.Services
{
    public interface ICategoryService
    {
        public List<CategoryResponseDto> GetAll();
        public CategoryResponseDto? GetById(int CategoryId);
        public CategoryResponseDto Create(CategoryCreateDto category);
        public bool Update(int CategoryId,CategoryUpdateDto category);
        public bool Delete(int CategoryId);
    }
}