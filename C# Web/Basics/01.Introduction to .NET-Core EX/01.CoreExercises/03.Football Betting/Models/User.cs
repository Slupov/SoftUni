using System.Collections.Generic;

namespace _03.Football_Betting.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FullName { get; set; }
        public decimal Balance { get; set; }
        public ICollection<Bet> Bets { get; set; } = new HashSet<Bet>();
    }
}