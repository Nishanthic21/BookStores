using BookStore.Web.Data;
using BookStore.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Web.Controllers
{
    public class BookStoreAdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public BookStoreAdminController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #region Author
        public async Task<IActionResult> Authors()
        {
            var authors = await _dbContext.Authors.ToListAsync();
            return View(authors);
        }

        public IActionResult AddAuthor()
        {
            Author author = new();
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> AddAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _dbContext.Authors.AddAsync(author);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Authors");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(author);
        }


        public async Task<IActionResult> EditAuthor(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> EditAuthor(Author author)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Authors.Update(author);
                    await _dbContext.SaveChangesAsync();
                    return RedirectToAction("Authors");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", $"Error: {ex.Message}");
                }
            }
            return View(author);
        }

        public async Task<IActionResult> DeleteAuthor(int id)
        {
            var author = await _dbContext.Authors.FindAsync(id);
            if (author == null)
            {
                return NotFound();
            }
            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Authors");
        }
        #endregion
    }
}
