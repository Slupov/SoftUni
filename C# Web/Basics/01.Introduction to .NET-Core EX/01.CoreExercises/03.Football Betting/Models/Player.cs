using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int SquadNumber { get; set; }
        public int TeamId { get; set; }
        public Team Team { get; set; }
        public int PositionId { get; set; }

        [Required]

        public Position Position { get; set; }

        public bool IsCurrentlyInjured { get; set; }
        public ICollection<PlayersGames> Games { get; set; } = new HashSet<PlayersGames>();
        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}