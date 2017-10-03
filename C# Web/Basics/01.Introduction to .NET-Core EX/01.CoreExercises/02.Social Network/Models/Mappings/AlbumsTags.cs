namespace _02.Social_Network.Models.Mappings
{
    public class AlbumsTags
    {
        public int AlbumId { get; set; }
        public Album Album { get; set; }

        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}