using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    public class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        [Required,StringLength(15, MinimumLength = 3,
            ErrorMessage = "Last Name must be at least of 3 and no more than 15 characters. ")]
        public string Name { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}