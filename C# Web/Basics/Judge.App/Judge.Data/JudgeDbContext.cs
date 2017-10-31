using Judge.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.ExpressionVisitors.Internal;

namespace Judge.Data
{
    public class JudgeDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Contest> Contests { get; set; }
        public DbSet<Submission> Submissions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder
                .UseSqlServer("Server=.;Database=JudgeAppDb;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Entity<User>()
                .HasIndex(u => u.Email)
                .IsUnique();

            builder
                .Entity<User>()
                .HasMany(u => u.Contests)
                .WithOne(c => c.User)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<User>()
                .HasMany(u => u.Submissions)
                .WithOne(s => s.User)
                .HasForeignKey(s => s.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .Entity<Contest>()
                .HasIndex(u => u.Name)
                .IsUnique();

            builder
                .Entity<Contest>()
                .HasMany(c => c.Submissions)
                .WithOne(s => s.Contest)
                .HasForeignKey(s => s.ContestId);

            builder
                .Entity<Submission>()
                .HasKey(s => new {s.UserId, s.ContestId});

            builder
                .Entity<Submission>()
                .HasOne(s => s.User)
                .WithMany(u => u.Submissions)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}