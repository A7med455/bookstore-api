using BookStoreAPI.DTOs.Category;

namespace BookStoreAPI.Services
{
    public interface ICategoryService
    {
        public List<CategoryResponseDto> GetAll();
        public CategoryResponseDto? GetById(int CategoryId);
        public CategoryCreateDto Create(CategoryResponseDto category);
        public bool Update(int CategoryId,CategoryUpdateDto category);
        public bool Delete(int CategoryId);
    }
}