using System.Collections.Generic;

namespace _03.Football_Betting.Models
{
    public class Round
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}