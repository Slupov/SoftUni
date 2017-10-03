using System.ComponentModel.DataAnnotations;
using _04.Bank_System.Validations;

namespace _04.Bank_System.Models
{
    public class Account
    {
        [Key]
        public int Id { get; set; }

        [StringLength(22)]
        [IBAN]
        public string IBAN { get; set; }

        public decimal Balance { get; set; }
        public virtual Customer Owner { get; set; }
    }
}