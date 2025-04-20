using BookStore.Web.Models;
using Microsoft.EntityFrameworkCore;
namespace BookStore.Web.Data;

public class ApplicationDbContext:DbContext
{   
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Book>Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Category> Categories { get; set; }
}
