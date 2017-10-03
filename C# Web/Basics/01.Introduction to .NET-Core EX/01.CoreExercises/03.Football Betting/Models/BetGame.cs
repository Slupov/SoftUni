using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Models
{
    public class BetGame
    {
        public int GameId { get; set; }

        [Required]

        public Game Game { get; set; }

        public int BetId { get; set; }
        public Bet Bet { get; set; }
        public int ResultPredictionId { get; set; }

        [Required]

        public ResultPrediction ResultPrediction { get; set; }
    }
}