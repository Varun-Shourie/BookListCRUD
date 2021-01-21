using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookListRazor.Models;
using Microsoft.EntityFrameworkCore;

namespace BookListRazor.Controllers
{

    // Book contrroller is an API controller, ensures this route will be used. Included in startup class
    // Get requests will return you data from GetAll() method.
    [Route("api/Book")]
    [ApiController]
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Retrieve the book and pass it back when you perform API calls.
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Json(new { data = await _db.Book.ToListAsync() });
        }

        // Add API call for delete with an HTTP delete
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var bookFromDb = await _db.Book.FirstOrDefaultAsync(u => u.Id == id);
            if (bookFromDb is null)
            {
                return Json(new { success = false, message = "Error while deleting." });
            }

            _db.Book.Remove(bookFromDb);
            await _db.SaveChangesAsync();
            return Json(new { success = true, message = "Delete successful." });
        }

    }
}
