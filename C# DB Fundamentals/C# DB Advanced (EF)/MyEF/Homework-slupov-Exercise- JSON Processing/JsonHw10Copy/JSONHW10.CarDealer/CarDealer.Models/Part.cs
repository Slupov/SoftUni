using System.Collections.Generic;
using Microsoft.Build.Framework;

namespace CarDealer.Models
{
    public class Part
    {
        public Part()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public int Supplier_Id { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}