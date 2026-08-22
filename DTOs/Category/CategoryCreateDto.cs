namespace BookStoreAPI.DTOs.Category
{
    public class CategoryCreateDto
    {
        public required string CategoryType{ get; set;}
        public string? Description{ get; set;}
    }
}