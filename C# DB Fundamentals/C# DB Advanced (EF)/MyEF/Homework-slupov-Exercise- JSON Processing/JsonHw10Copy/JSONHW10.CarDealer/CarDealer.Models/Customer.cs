using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Sales = new HashSet<Sale>();
        }

        public int Id { get; set; }

        [Required, MaxLength(50)]
        public string Name { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        public bool IsYoungDriver { get; set; }

        public virtual ICollection<Sale> Sales { get; set; }
    }
}