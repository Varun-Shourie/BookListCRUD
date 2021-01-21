using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Models
{
    public class Book
    {
        // Automatically adds id as the identity column, it'll create it automatically. We do not have to pass value.
        [Key]
        public int Id { get; set; }

        // Name cannot be null.
        [Required]
        public string Name { get; set; }
        public string Author { get; set; }
        // Since you change the model, add a new migration to demonstrate this fact. 
        public string ISBN { get; set; }
    }
}
