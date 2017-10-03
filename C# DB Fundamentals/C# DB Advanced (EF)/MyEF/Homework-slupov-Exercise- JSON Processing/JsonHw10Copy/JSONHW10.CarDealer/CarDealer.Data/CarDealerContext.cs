using CarDealer.Data.Migrations;
using CarDealer.Models;

namespace CarDealer.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CarDealerContext : DbContext
    {
        public CarDealerContext()
            : base("name=CarDealerContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CarDealerContext, Configuration>());
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Part>()
                .HasRequired(p => p.Supplier)
                .WithMany(s => s.Parts)
                .HasForeignKey(p => p.Supplier_Id);

            modelBuilder.Entity<Sale>()
                .HasRequired(s => s.Car)
                .WithMany()
                .HasForeignKey(s => s.Car_Id);

            modelBuilder.Entity<Sale>()
               .HasRequired(s => s.Customer)
               .WithMany(c => c.Sales) 
               .HasForeignKey(s => s.Customer_Id);


            base.OnModelCreating(modelBuilder);
        }
    }
}