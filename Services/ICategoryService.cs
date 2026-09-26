using BookStoreAPI.DTOs.Category;

namespace BookStoreAPI.Services
{
    public interface ICategoryService
    {
        public Task<List<CategoryResponseDto>> GetAll();
        public Task<CategoryResponseDto?> GetById(int CategoryId);
        public Task<CategoryResponseDto> Create(CategoryCreateDto category);
        public Task<bool> Update(int CategoryId,CategoryUpdateDto category);
        public Task<bool> Delete(int CategoryId);
    }
}