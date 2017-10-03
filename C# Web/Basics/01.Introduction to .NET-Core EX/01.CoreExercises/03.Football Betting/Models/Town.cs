using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace _03.Football_Betting.Models
{
    public class Town
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryId { get; set; }

        [Required]

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; } = new HashSet<Team>();
    }
}