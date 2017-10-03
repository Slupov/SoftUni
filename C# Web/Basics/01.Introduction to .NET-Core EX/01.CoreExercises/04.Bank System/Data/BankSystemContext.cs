using Microsoft.EntityFrameworkCore;
using _04.Bank_System.Models;

namespace _04.Bank_System.Data
{
    public class BankSystemContext : DbContext
    {
        public virtual DbSet<SavingAccount> SavingAccounts { get; set; }
        public virtual DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                @"Server=.;Database=BankSystemDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Account>()
                .HasIndex(t => t.IBAN)
                .IsUnique();
        }
    }
}