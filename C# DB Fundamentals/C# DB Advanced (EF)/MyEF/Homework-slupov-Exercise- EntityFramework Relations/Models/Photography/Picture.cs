using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Photography
{
    public class Picture
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }
        public string Caption { get; set; }
        public string Path { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

    }
}
