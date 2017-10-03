namespace _03.Football_Betting.Models
{
    public class GamesBets
    {
        public int GameId { get; set; }
        public Game Game { get; set; }

        public int BetId { get; set; }
        public Bet Bet { get; set; }
    }
}