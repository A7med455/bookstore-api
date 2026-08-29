using BookStoreAPI.DTOs.Category;
using BookStoreAPI.Models;
using BookStoreAPI.Repositories;

namespace BookStoreAPI.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        private CategoryResponseDto MapToResponse(Category category)
        {
            return new CategoryResponseDto
            {
                CategoryId = category.CategoryId,
                CategoryType = category.CategoryType,
                Description = category.Description
            };
        }
        private Category MapToCategory(CategoryCreateDto createDto)
        {
            return new Category
            {
                CategoryType = createDto.CategoryType,
                Description = createDto.Description
            };
        }
        public List<CategoryResponseDto> GetAll()
        {
            List<Category> categories = _categoryRepository.GetAll();
            List<CategoryResponseDto> results = new List<CategoryResponseDto>();
            foreach(Category category in categories)
            {
                results.Add(MapToResponse(category));
            }
            return results;
        }
        public CategoryResponseDto? GetById(int CategoryId)
        {
            Category? ExistingCategory = _categoryRepository.GetById(CategoryId);
            if(ExistingCategory == null)
            {
                return null;
            }
            return MapToResponse(ExistingCategory);
        }
        public CategoryResponseDto Create(CategoryCreateDto CategoryDto)
        {
            if(string.IsNullOrWhiteSpace(CategoryDto.CategoryType))
            {
                throw new ArgumentException("Category Type cannot be empty");
            }
            if(string.IsNullOrWhiteSpace(CategoryDto.Description))
            {
                throw new ArgumentException("Description cannot be empty");
            }
            Category category = MapToCategory(CategoryDto);
            _categoryRepository.Create(category);
            return MapToResponse(category);
        }
        public bool Update(int CategoryId,CategoryUpdateDto updateDto)
        {
            Category? category = _categoryRepository.GetById(CategoryId);
            if(category == null)
            {
                return false;
            }

            if (updateDto.CategoryType != null && string.IsNullOrWhiteSpace(updateDto.CategoryType))
            {
                throw new ArgumentException("Category Type cannot be empty");
            }
            if (updateDto.CategoryType != null) 
            {
                category.CategoryType = updateDto.CategoryType;
            }
            if (updateDto.Description != null)
            {
                category.Description = updateDto.Description;
            }
            _categoryRepository.Update(CategoryId,category);
            return true;
        }
        public bool Delete(int CategoryId)
        {
            if(!_categoryRepository.Delete(CategoryId))
            {
                return false;
            }
            return true;
        }
    }
}