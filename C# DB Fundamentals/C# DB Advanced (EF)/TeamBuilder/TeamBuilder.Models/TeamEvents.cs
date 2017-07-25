using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class TeamEvents
    {
        public int TeamId { get; set; }
        public Team Team { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}
