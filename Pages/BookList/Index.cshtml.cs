using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Pages.BookList
{
    public class IndexModel : PageModel
    {
        // Whenever we want to deal with the database, we require the ApplicationDbContext class.
        private readonly ApplicationDbContext _db;

        public IndexModel(ApplicationDbContext db)
        {
            // Extract the app db context that's inside the dependency injection container. 
            // If you didn't have dependency injection container, you would have to create and dispose off the object. 
            _db = db;
        }

        public IEnumerable<Book> Books { get; set; }

        // With MVC, we would have action methods. But with Razor pages, inside the PageModel, we have handlers.
        public async Task OnGet()
        {
            Books = await _db.Book.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var book = await _db.Book.FindAsync(id);
            if (book is null)
            {
                return NotFound();
            }

            _db.Book.Remove(book);
            await _db.SaveChangesAsync();

            return RedirectToPage("Index");
        }
    }
}
