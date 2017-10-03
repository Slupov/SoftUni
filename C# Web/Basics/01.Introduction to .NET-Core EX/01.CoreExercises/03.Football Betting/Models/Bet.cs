using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Models
{
    public class Bet
    {
        public int Id { get; set; }
        public decimal BetMoney { get; set; }
        public DateTime DateTime { get; set; }
        public int UserId { get; set; }

        [Required]

        public User User { get; set; }

        public ICollection<GamesBets> Games { get; set; } = new HashSet<GamesBets>();
        public ICollection<BetGame> BetGames { get; set; } = new HashSet<BetGame>();
    }
}