using Models.BankSystem;

namespace DataBankSystem.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DataBankSystem.BankSystemContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DataBankSystem.BankSystemContext context)
        {
            context.Customers.AddOrUpdate(
                p => p.Username,
                new Customer
                {
                    Username = "Andrew Peters",
                    Password = "123Hashed@",
                    Email = "andro@gmail.com",
                },
                new Customer
                {
                    Username = "Stanimir Minchov",
                    Password = "123123@",
                    Email = "Minchoff@gmail.com",
                },
                new Customer
                {
                    Username = "Dzheronimo Iliev",
                    Password = "hoolaEdasd231x",
                    Email = "dzhero@abv.bg",
                }
            );
        }
    }
}