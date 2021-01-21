using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            // Empty constructor, but the parameter is needed for dependency injection. 
        }

        // Then we need to add the book model that we wish to add to the database.
        public DbSet<Book> Book { get; set; }

    }
}
