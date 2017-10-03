using System.Collections.Generic;

namespace _03.Football_Betting.Models
{
    public class Position
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}