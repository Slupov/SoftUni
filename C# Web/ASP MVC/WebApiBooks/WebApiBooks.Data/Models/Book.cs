using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiBooks.Data.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Copies { get; set; }

        [Required]
        public int AutorId { get; set; }

        public Author Author { get; set; }

        public int? Edition { get; set; }
        public IEnumerable<BookCategories> BookCategories { get; set; }
    }
}