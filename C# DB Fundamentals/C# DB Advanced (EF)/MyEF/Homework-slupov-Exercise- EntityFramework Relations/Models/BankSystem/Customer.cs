using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Models.BankSystem
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Index(IsUnique = true)]
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