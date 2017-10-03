using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.ValidationAttributes;

namespace Models.BankSystem
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [StringLength(22)]
        [Index(IsUnique = true)]
        [IBAN]
        public string IBAN { get; set; }
        public decimal Balance { get; set; }
        public virtual Customer Owner { get; set; }

       
    }
}
