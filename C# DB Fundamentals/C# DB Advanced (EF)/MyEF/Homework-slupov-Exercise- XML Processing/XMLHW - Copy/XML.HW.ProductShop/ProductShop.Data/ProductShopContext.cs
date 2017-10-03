using ProductShop.Data.Models;

namespace ProductShop.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class ProductShopContext : DbContext
    {
        public ProductShopContext()
            : base("name=ProductShopContext")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasMany(e => e.Products)
                .WithMany(e => e.Categories)
                .Map(m => m.ToTable("CategoryProducts").MapLeftKey("Product_Id").MapRightKey("Category_Id"));

            modelBuilder.Entity<User>()
                .HasMany(e => e.BoughtProducts)
                .WithOptional(e => e.Buyer)
                .HasForeignKey(e => e.BuyerId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.SoldProducts)
                .WithRequired(e => e.Seller)
                .HasForeignKey(e => e.SellerId);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Friends)
                .WithMany()
                .Map(m => m.ToTable("UserFriends").MapLeftKey("FriendId").MapRightKey("UserId"));
        }
    }
}
