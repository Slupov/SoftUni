using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Models
{
    public class Competition
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }

        [Required]

        public CompetitionType Type { get; set; }

        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}