using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.BankSystem
{
    public class CheckingAccount : Account
    {
        public CheckingAccount() : base()
        {
        }

        public void Deposit(decimal value)
        {
            this.Balance += value;
        }

        public decimal Fee { get; set; }

        public void Withdraw(decimal value)
        {
            if (this.Balance < value)
            {
                Console.WriteLine($"Insufficient funds, Balance: {this.Balance}");
                return;
            }
            this.Balance -= value;
            this.Fee += this.Fee;
        }

        public void DeductFee()
        {
            if (this.Fee > this.Balance)
            {
                Console.WriteLine("Cannot pay fees now. Insufficient funds!");
                return;
            }
            this.Balance -= this.Fee;
        }
    }
}