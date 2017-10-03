using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBankSystem.Migrations;
using Models.BankSystem;

namespace DataBankSystem
{
    public class BankSystemContext : DbContext
    {
        public BankSystemContext()
            : base("name=BankSystemContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BankSystemContext, Configuration>());
        }

        public virtual DbSet<SavingAccount> SavingAccounts { get; set; }
        public virtual DbSet<CheckingAccount> CheckingAccounts { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
    }
}
