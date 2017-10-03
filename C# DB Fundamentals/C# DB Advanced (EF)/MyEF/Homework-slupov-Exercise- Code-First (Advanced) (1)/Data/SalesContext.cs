
namespace Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using Models;
    using Data;


    public class SalesContext : DbContext
    {
        public SalesContext()
            : base("name=SalesContext")
        {
            //Database.SetInitializer(new CreateIfNotExistsAndSeed());
        }

        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<StoreLocation> StoreLocations { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

    }


}