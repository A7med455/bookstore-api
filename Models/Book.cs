namespace BookStoreAPI.Models
{
    public class Book
    {
        public  int  BookId{ get; set;} //auto incremented (later)
        public required int CategoryId{ get; set;} 
        public required int AuthorId{ get; set;}  
        public required string Title{ get; set;}
        public required string ISBN{ get; set;} 
        public required int Stock{ get; set;}
        public required double Price{get; set;}
        public required DateTime PublishedDate{ get; set;}

        
    }
}
