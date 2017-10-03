namespace _02.Social_Network.Models.Mappings
{
    public class AlbumsPhotographers
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int PhotographerId { get; set; }
        public Photographer Photographer { get; set; }
    }
}