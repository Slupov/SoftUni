using System.Collections.Generic;
using _02.Social_Network.Models.Mappings;

namespace _02.Social_Network.Models
{
    public class Picture
    {
        public Picture()
        {
            this.Albums = new HashSet<AlbumsPictures>();
        }

        public int Id { get; set; }

        public string Title { get; set; }
        public string Caption { get; set; }
        public string Path { get; set; }
        public ICollection<AlbumsPictures> Albums { get; set; }
    }
}