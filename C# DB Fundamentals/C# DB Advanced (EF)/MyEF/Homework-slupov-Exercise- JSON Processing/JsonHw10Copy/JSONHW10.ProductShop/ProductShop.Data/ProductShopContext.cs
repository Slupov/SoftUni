using ProductShop.Data.Migrations;
using ProductShop.Models;

namespace ProductShop.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ProductShopContext, Configuration>());
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        protected override void
            OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>()
                .HasMany(u => u.BoughtProducts)
                .WithOptional(p => p.Buyer);
            modelBuilder.Entity<User>()
                .HasMany(u => u.SoldProducts)
                .WithRequired(p => p.Seller);
            modelBuilder.Entity<User>()
                .HasMany(u => u.Friends)
                .WithMany()
                .Map(m =>
                {
                    m.MapLeftKey("UserId");
                    m.MapRightKey("FriendId");
                    m.ToTable("UserFriends");
                });
          
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Categories)
                .Map(m =>
                {
                    m.ToTable("CategoryProducts");
                    m.MapLeftKey("Product_Id");
                    m.MapRightKey("Category_Id");
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}