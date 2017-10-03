using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProductShop.Models
{
    public class User
    {
        public User()
        {
            Friends = new HashSet<User>();
            SoldProducts = new HashSet<Product>();
            BoughtProducts = new HashSet<Product>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }

        [Required,MinLength(3)]
        public string LastName { get; set; }

        public int? Age { get; set; }

        public virtual ICollection<User> Friends { get; set; }
        public virtual ICollection<Product> SoldProducts { get; set; }
        public virtual ICollection<Product> BoughtProducts { get; set; }
    }
}