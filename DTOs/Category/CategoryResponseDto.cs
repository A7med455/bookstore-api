namespace BookStoreAPI.DTOs.Category
{
    public class CategoryResponseDto
    {
        public int CategoryId{ get; set;}
        public required string CategoryType{ get; set;}
        public string? Description{ get; set;}
    }
}