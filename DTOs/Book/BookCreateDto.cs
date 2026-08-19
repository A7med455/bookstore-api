namespace BookStoreAPI.DTOs.Book
{
    public class BookCreateDto
    {
        public required int CategoryId{ get; set;} 
        public required int AuthorId{ get; set;}  
        public required string Title{ get; set;}
        public required string ISBN{ get; set;} 
        public required int Stock{ get; set;}
        public required decimal Price{get; set;}
        public required DateTime PublishedDate{ get; set;}
    }
}
    