using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Car
    {
        public Car()
        {
            Parts = new HashSet<Part>();
        }

        public int Id { get; set; }

        [Required, MaxLength(30)]
        public string Make { get; set; }

        [Required, MaxLength(50)]
        public string Model { get; set; }

        [Required]
        public long TravelledDistance { get; set; }

        public virtual ICollection<Part> Parts { get; set; }
    }
}