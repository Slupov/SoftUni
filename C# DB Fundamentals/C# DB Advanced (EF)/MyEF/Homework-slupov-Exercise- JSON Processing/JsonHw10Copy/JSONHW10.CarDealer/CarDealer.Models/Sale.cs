using System.ComponentModel.DataAnnotations;

namespace CarDealer.Models
{
    public class Sale
    {
        public int Id { get; set; }

        [Range(0.00, 100.00)]
        public double Discount { get; set; }

        [Required]
        public int Car_Id { get; set; }
        public virtual Car Car { get; set; }

        [Required]
        public int Customer_Id { get; set; }
        public virtual Customer Customer { get; set; }
    }
}