using BookStoreAPI.DTOs.Author;
using BookStoreAPI.DTOs.Category;

namespace BookStoreAPI.DTOs.Book
{
    public class BookResponseDto
    {
        public int BookId{ get; set;}
        public required CategoryResponseDto Category{ get; set;}
        public required AuthorResponseDto Author{ get; set;}
        public required string Title{ get; set;}
        public required string ISBN{ get; set;} 
        public required int Stock{ get; set;}
        public required decimal Price{get; set;}
        public required DateTime PublishedDate{ get; set;}
    }
}