using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using _02.Social_Network.Models.Mappings;

namespace _02.Social_Network.Models
{
    public class Album
    {
        public Album()
        {
            this.Pictures = new HashSet<AlbumsPictures>();
            this.Owners = new HashSet<AlbumsPhotographers>();
            this.Viewers = new HashSet<AlbumsPhotographers>();
            this.Tags = new HashSet<AlbumsTags>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public string BackgroundColor { get; set; }
        public bool IsPublic { get; set; }

        public ICollection<AlbumsPictures> Pictures { get; set; }
        public ICollection<AlbumsPhotographers> Owners { get; set; }
        public ICollection<AlbumsPhotographers> Viewers { get; set; }
        public ICollection<AlbumsTags> Tags { get; set; }
    }
}