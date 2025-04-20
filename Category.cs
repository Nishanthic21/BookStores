namespace BookStore.Web.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        //Navigation Property 
        public ICollection<Book>? Books { get; set; }

    }
}

