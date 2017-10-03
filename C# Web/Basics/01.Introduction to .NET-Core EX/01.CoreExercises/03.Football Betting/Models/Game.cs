using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Models
{
    public class Game
    {
        public int Id { get; set; }
        public int HomeTeamId { get; set; }
        public Team HomeTeam { get; set; }
        public int AwayTeamId { get; set; }
        public Team AwayTeam { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public DateTime DateTime { get; set; }
        public decimal HomeTeamWinBetRate { get; set; }
        public decimal AwayTeamWinBetRate { get; set; }
        public decimal DrawBetRate { get; set; }
        public int RoundId { get; set; }

        [Required]

        public Round Round { get; set; }

        public int CompetitionId { get; set; }

        [Required]

        public Competition Competition { get; set; }

        public ICollection<BetGame> BetGames { get; set; } = new HashSet<BetGame>();
        public ICollection<GamesBets> Bets { get; set; } = new HashSet<GamesBets>();
        public ICollection<PlayersGames> Players { get; set; } = new HashSet<PlayersGames>();
        public ICollection<PlayerStatistic> PlayerStatistics { get; set; } = new HashSet<PlayerStatistic>();
    }
}