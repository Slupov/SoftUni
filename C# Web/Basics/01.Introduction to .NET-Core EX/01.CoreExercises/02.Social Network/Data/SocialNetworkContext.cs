using Microsoft.EntityFrameworkCore;
using _02.Social_Network.Models;
using _02.Social_Network.Models.Mappings;

namespace _02.Social_Network.Data
{
    public class SocialNetworkContext : DbContext
    {
        public virtual DbSet<Photographer> Photographers { get; set; }
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<Picture> Pictures { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDb;Database=SocialNetworkDB;Integrated Security=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Tag>()
                .HasIndex(t => t.Name)
                .IsUnique();

            modelBuilder.Entity<AlbumsPictures>()
                .HasKey(sc => new {sc.AlbumId, sc.PictureId});

            modelBuilder.Entity<AlbumsPictures>()
                .HasOne<Album>(sc => sc.Album)
                .WithMany(s => s.Pictures)
                .HasForeignKey(sc => sc.AlbumId);

            modelBuilder.Entity<AlbumsPictures>()
                .HasOne<Picture>(sc => sc.Picture)
                .WithMany(s => s.Albums)
                .HasForeignKey(sc => sc.PictureId);

            modelBuilder.Entity<AlbumsPhotographers>()
                .HasKey(sc => new {sc.AlbumId, sc.PhotographerId});

            modelBuilder.Entity<AlbumsPhotographers>()
                .HasOne<Album>(sc => sc.Album)
                .WithMany(s => s.Owners)
                .HasForeignKey(sc => sc.AlbumId);

            modelBuilder.Entity<AlbumsPhotographers>()
                .HasOne<Photographer>(sc => sc.Photographer)
                .WithMany(s => s.Albums)
                .HasForeignKey(sc => sc.PhotographerId);

            modelBuilder.Entity<AlbumsTags>()
                .HasKey(sc => new {sc.AlbumId, sc.TagId});

            modelBuilder.Entity<AlbumsTags>()
                .HasOne<Album>(sc => sc.Album)
                .WithMany(s => s.Tags)
                .HasForeignKey(sc => sc.AlbumId);

            modelBuilder.Entity<AlbumsTags>()
                .HasOne<Tag>(sc => sc.Tag)
                .WithMany(s => s.Albums)
                .HasForeignKey(sc => sc.TagId);

            modelBuilder.Entity<Friendship>()
                .HasKey(sc => new {sc.FromPhotographerId, sc.ToPhotographerId});

            modelBuilder.Entity<Photographer>()
                .HasMany(s => s.FromFriends)
                .WithOne(s => s.FromPhotographer)
                .HasForeignKey(sc => sc.FromPhotographerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Photographer>()
                .HasMany(s => s.ToFriends)
                .WithOne(s => s.ToPhotographer)
                .HasForeignKey(sc => sc.ToPhotographerId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}