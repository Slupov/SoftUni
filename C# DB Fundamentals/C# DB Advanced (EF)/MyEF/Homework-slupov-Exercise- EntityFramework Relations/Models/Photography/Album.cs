using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Models.Photography
{
    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<Picture>();
            this.Owners = new HashSet<Photographer>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsPublic { get; set; }
        public virtual ICollection<Picture> Pictures { get; set; }
        public virtual ICollection<Photographer> Owners { get; set; }
        public virtual ICollection<Tag> Tags { get; set; }

    }
}