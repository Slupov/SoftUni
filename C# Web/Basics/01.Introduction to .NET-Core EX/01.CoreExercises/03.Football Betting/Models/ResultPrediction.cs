using System.ComponentModel.DataAnnotations;
using _03.Football_Betting.Validations;

namespace _03.Football_Betting.Models
{
    public class ResultPrediction
    {
        public int Id { get; set; }

        [PredictionValidation]
        public string Prediction { get; set; }

        public int BetGameId { get; set; }

        [Required]
        public BetGame BetGame { get; set; }
    }
}