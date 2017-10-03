using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _04.Bank_System.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [StringLength(20)]
        public string Username { get; set; }

        //TO DO: Make password byte[]
        public string Password { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public virtual ICollection<CheckingAccount> CheckingAccounts { get; set; }
        public virtual ICollection<SavingAccount> SavingAccounts { get; set; }
    }
}