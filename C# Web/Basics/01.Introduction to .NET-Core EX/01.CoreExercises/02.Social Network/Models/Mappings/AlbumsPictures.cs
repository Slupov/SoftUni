namespace _02.Social_Network.Models.Mappings
{
    public class AlbumsPictures
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int PictureId { get; set; }
        public Picture Picture { get; set; }
    }
}