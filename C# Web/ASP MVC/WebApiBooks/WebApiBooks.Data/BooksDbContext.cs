using Microsoft.EntityFrameworkCore;
using WebApiBooks.Data.Models;

namespace WebApiBooks.Data
{
    public class BooksDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=.;Database=BooksApi;Trusted_Connection=True;MultipleActiveResultSets=true");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookCategories>()
                .HasKey(c => new {c.BookId, c.CategoryId});

            modelBuilder.Entity<Book>()
                .HasMany(b => b.BookCategories)
                .WithOne(c => c.Book);

            modelBuilder.Entity<Category>()
                .HasMany(b => b.BookCategories)
                .WithOne(c => c.Category);

            base.OnModelCreating(modelBuilder);
        }
    }
}