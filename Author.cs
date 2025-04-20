namespace BookStore.Web.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        public string? AuthorName { get; set; }
        public string? Biography { get; set; }
        //Navigation Property 
        public ICollection<Book>? Books { get; set; }


    }
}
