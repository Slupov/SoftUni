﻿using System.Collections.Generic;

namespace _03.Football_Betting.Models
{
    public class Continent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Country> Countries { get; set; } = new HashSet<Country>();
    }
}