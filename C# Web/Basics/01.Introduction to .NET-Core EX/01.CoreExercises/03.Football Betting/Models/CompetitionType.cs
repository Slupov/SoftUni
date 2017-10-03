using System.Collections.Generic;

namespace _03.Football_Betting.Models
{
    public class CompetitionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Competition> Competitions { get; set; } = new HashSet<Competition>();
    }
}