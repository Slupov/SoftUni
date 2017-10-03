using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class UserTeams
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
    }
}