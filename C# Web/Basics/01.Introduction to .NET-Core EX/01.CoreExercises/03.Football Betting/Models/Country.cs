using System.Collections.Generic;
using _03.Football_Betting.Validations;

namespace _03.Football_Betting.Models
{
    public class Country
    {
        [CountryIdValidation]
        public string Id { get; set; }

        public string Name { get; set; }
        public int ContinentId { get; set; }
        public ICollection<Town> Towns { get; set; } = new HashSet<Town>();
        public ICollection<Continent> Continents { get; set; } = new HashSet<Continent>();
    }
}