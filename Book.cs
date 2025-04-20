namespace BookStore.Web.Models
{
    public class Book
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public int StockQuantity { get; set; }
        //Navigation Property 

        public Author? Author { get; set; }
        public Category? Category { get; set; }
    }
}
