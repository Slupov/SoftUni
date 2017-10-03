namespace _02.Social_Network.Models.Mappings
{
    public class Friendship
    {
        public int FromPhotographerId { get; set; }
        public Photographer FromPhotographer { get; set; }

        public int ToPhotographerId { get; set; }
        public Photographer ToPhotographer { get; set; }
    }
}