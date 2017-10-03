using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Photography
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }
        [Index(IsUnique = true)]
        [StringLength(20)]
        [ValidationAttributes.Tag]
        public string Name { get; set; }

        public virtual ICollection<Album> Albums { get; set; }
    }
}
