using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models.BookShop
{
    public enum EditionType
    {
        Normal,
        Promo,
        Gold
    }

    public enum AgeRestriction
    {
        Minor,
        Teen,
        Adult
    }

    public class Book
    {
        public Book()
        {
            this.Categories = new HashSet<Category>();
            this.RelatedBooks = new HashSet<Book>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        [Required]
        public string Title { get; set; }

        [StringLength(1000)]
        public string Description { get; set; }

        public EditionType Edition { get; set; }
        public AgeRestriction AgeRestriction { get; set; }

        public decimal Price { get; set; }
        public int Copies { get; set; }
        public DateTime? ReleaseDate { get; set; }

        [Required]
        public virtual Author Author { get; set; }

        [Required]
        public int AuthorId { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<Book> RelatedBooks { get; set; }
    }
}