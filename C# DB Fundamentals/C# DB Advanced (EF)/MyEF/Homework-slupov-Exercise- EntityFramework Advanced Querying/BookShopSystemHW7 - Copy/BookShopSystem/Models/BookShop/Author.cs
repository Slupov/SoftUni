using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShopSystem.Models.BookShop
{
    public class Author
    {
        private ICollection<Book> _books;

        public Author()
        {
            this._books = new HashSet<Book>();
        }
        [Key]
        public int Id { get; set; }

        [StringLength(30)]
        public string FirstName { get; set; }

        [StringLength(30)]
        [Required]
        public string LastName { get; set; }

        public virtual ICollection<Book> Books
        {
            get { return this._books; }
            set { this._books = value; }
        }
    }
}
