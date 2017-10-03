using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Models
{
    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Logo { get; set; }
        public string Initials { get; set; }
        public int PrimaryKitColorId { get; set; }
        public Color PrimaryKitColor { get; set; }
        public int SecondaryKitColorId { get; set; }
        public Color SecondaryKitColor { get; set; }
        public int TownId { get; set; }

        [Required]
        public Town Town { get; set; }

        public decimal Budged { get; set; }
        public ICollection<Player> Players { get; set; } = new HashSet<Player>();
    }
}