namespace BookStoreAPI.DTOs.Book
{
    public class BookUpdateDto
    {
        public int? CategoryId{ get; set;} 
        public int? AuthorId{ get; set;}  
        public string? Title{ get; set;}
        public string? ISBN{ get; set;} 
        public int? Stock{ get; set;}
        public decimal? Price{get; set;}
        public DateTime? PublishedDate{ get; set;}
    }
}