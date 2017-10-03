using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Team
    {
        public Team()
        {
            this.Members = new List<User>();
            this.ParticipatedEvents = new List<Event>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Acronym { get; set; }

        public int CreatorId { get; set; }
        public User Creator { get; set; }

        public virtual ICollection<User> Members { get; set; }
        public virtual ICollection<Event> ParticipatedEvents { get; set; }
    }
}