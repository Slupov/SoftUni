using CarDealer.Data.Models;

namespace CarDealer.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CarDealerContext : DbContext
    {
        public CarDealerContext()
            : base("name=CarDealerContext")
        {
        }

        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Part> Parts { get; set; }
        public virtual DbSet<Sale> Sales { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Car)
                .HasForeignKey(e => e.Car_Id);

            modelBuilder.Entity<Car>()
                .HasMany(e => e.Parts)
                .WithMany(e => e.Cars)
                .Map(m => m.ToTable("PartCars"));

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Sales)
                .WithRequired(e => e.Customer)
                .HasForeignKey(e => e.Customer_Id);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Parts)
                .WithRequired(e => e.Supplier)
                .HasForeignKey(e => e.Supplier_Id);
        }
    }
}
