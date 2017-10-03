namespace _03.Football_Betting.Models
{
    public class PlayersGames
    {
        public int PlayerId { get; set; }
        public Player Player { get; set; }

        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}