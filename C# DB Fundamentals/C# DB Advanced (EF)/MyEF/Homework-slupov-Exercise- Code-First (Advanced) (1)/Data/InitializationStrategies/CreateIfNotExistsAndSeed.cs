using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace Data
{
    public class CreateIfNotExistsAndSeed : CreateDatabaseIfNotExists<SalesContext>
    {
        protected override void Seed(SalesContext context)
        {
            //seed 5 products, customers,locations,sales
            for (int i = 0; i < 5; i++)
            {
                seedProduct(context);
                seedCustomer(context);
                seedLocation(context);
            }

            for (int i = 0; i < 5; i++)
            {
                seedSale(context);
            }
            base.Seed(context);
        }

        private void seedProduct(SalesContext db)
        {
            db.Products.Add(new Product()
            {
                Name = this.ProductNames[gen.Next(0, this.ProductNames.Count)],
                Quantity = this.gen.Next(0, 100),
                //prices will be in the range 0.01 lv to 30.00 lv 
                Price = (decimal) gen.NextDouble() * (decimal) (30.00 - 0.01) + 0.01m,
                Description = "No description"
            });

            db.SaveChanges();
        }

        private void seedCustomer(SalesContext db)
        {
            string tempName = this.FirstNames[gen.Next(0, this.FirstNames.Count)];
            string lastName = this.LastNames[gen.Next(0, this.LastNames.Count)];

            db.Customers.Add(new Customer()
            {
                FirstName = tempName,
                LastName = lastName,
                Email = tempName + "@gmail.com",
                CreditCardNumber = this.RandomCreditCardNumber(),
            });

            db.SaveChanges();
        }

        private void seedLocation(SalesContext db)
        {
            db.StoreLocations.Add(new StoreLocation()
            {
                LocationName = this.StoreLocationNames[gen.Next(0, this.StoreLocationNames.Count)]
            });

            db.SaveChanges();
        }

        private void seedSale(SalesContext db)
        {
            db.Sales.Add(new Sale()
            {
                Product = db.Products.ToList().ElementAt(gen.Next(0, db.Products.ToList().Count())),
                Customer = db.Customers.ToList().ElementAt(gen.Next(0, db.Customers.ToList().Count())),
                StoreLocation = db.StoreLocations.ToList().ElementAt(gen.Next(0, db.StoreLocations.ToList().Count())),
                Date = RandomDay()
            });

            db.SaveChanges();
        }

        private DateTime RandomDay()
        {
            DateTime start = new DateTime(2000, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(gen.Next(range));
        }

        private string RandomCreditCardNumber()
        {
            string result = "";
            for (int i = 0; i < 16; i += 4)
            {
                for (int j = 0; j < 4; j++)
                {
                    result += gen.Next(0, 9).ToString();
                }
                result += " ";
            }

            return result;
        }

        private readonly Random gen = new Random();

        private List<string> ProductNames = new List<string>()
        {
            "Red Peppers",
            "Conca Cola",
            "Penspi Cola",
            "Salt sticks",
            "Milka chocolate",
            "Water",
            "Apple juice",
            "Orange juice"
        };

        private List<string> FirstNames = new List<string>()
        {
            "Ivan",
            "Petar",
            "George",
            "Mincho",
            "Ilia",
            "Konstantin",
            "Stoyan",
            "Svetlin"
        };

        private List<string> LastNames = new List<string>()
        {
            "Ivanov",
            "Petrov",
            "Georgiev",
            "Minchov",
            "Iliev",
            "Konstantinov",
            "Stoyanov",
            "Svetlinski"
        };

        private List<string> StoreLocationNames = new List<string>()
        {
            "Tintyava 16",
            "Ivan Stranski 15",
            "Monah Filaret 69",
            "Bul.Bulgaria 102",
            "6 Septemvri 158",
            "Montevideo 5",
            "Argenitna 123",
            "Alpha Beta 7"
        };
    }
}