using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _02.Social_Network.Models.Mappings;

namespace _02.Social_Network.Models
{
    public class Tag
    {
        public int Id { get; set; }

        [StringLength(20)]
        [Validations.TagAttribute]
        public string Name { get; set; }

        public virtual ICollection<AlbumsTags> Albums { get; set; }
    }
}