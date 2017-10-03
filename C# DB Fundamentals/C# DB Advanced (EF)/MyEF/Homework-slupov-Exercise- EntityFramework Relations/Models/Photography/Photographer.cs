using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Photography
{
    public class Photographer
    {
        public Photographer()
        {
            this.Albums = new HashSet<Album>();
        }
        [Key]
        public int Id { get; set; }
        public string Username { get; set; }
        //should be byte[] to be precise
        public string Password { get; set; }
        public string Email { get; set; }
        public DateTime RegisterDate { get; set; }
        public DateTime BirthDate { get; set; }

        public virtual ICollection<Album> Albums { get; set; }

    }
}
