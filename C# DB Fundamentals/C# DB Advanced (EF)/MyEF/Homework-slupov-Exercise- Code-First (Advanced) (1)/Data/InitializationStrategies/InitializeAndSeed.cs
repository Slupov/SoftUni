using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.LocalStore;


namespace Data
{
    public class InitializeAndSeed : DropCreateDatabaseAlways<LocalStoreContext>
    {
        protected override void Seed(LocalStoreContext context)
        {
            context.Products.AddRange(new List<Product>()
            {
                new Product()
                {
                    Name = "Peppers",
                    DistributorName = "Bai Kolio",
                    Desctiption = "Dobra chushka",
                    Price = 5.20m,
                    Quantity = 2
                },
                new Product()
                {
                    Name = "Conca Cola 2L",
                    DistributorName = "Litber OOD",
                    Desctiption = "A sugary drink",
                    Price = 2.20m,
                    Quantity = 10

                },
                new Product()
                {
                    Name = "Penspi Cola 2L",
                    DistributorName = "Litber OOD",
                    Desctiption = "A meh drink",
                    Price = 2.00m,
                    Quantity = 5
                }
            });

            context.SaveChanges();

            base.Seed(context);
        }
    }
}