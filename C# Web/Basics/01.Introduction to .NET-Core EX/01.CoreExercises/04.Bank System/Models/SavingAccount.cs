using System;

namespace _04.Bank_System.Models
{
    public class SavingAccount : Account
    {
        public SavingAccount() : base()
        {
        }

        public double Interest { get; set; }

        public void Deposit(decimal value)
        {
            this.Balance += value;
        }

        public void Withdraw(decimal value)
        {
            if (this.Balance < value)
            {
                Console.WriteLine("Insufficient funds.");
                return;
            }
            this.Balance -= value;
        }

        public void AddInterest()
        {
            this.Balance += this.Balance * (decimal) this.Interest;
        }
    }
}