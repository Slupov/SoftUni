using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Models
{
    public class PlayerStatistic
    {
        public int GameId { get; set; }

        [Required]


        public Game Game { get; set; }

        public int PlayerId { get; set; }

        [Required]

        public Player Player { get; set; }

        public int ScoredGoals { get; set; }
        public int PlayerAssists { get; set; }
        public double PlayedMinutesDuringGame { get; set; }
    }
}