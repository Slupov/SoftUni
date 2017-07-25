using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public enum Gender
    {
        Male,
        Female
    }

    public class User
    {
        public User()
        {
            this.CreatedEvents = new List<Event>();
            this.Teams = new List<Team>();
            this.CreatedTeams = new List<Team>();
            this.ReceivedInvitations = new List<Invitation>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(25, MinimumLength = 3)]
        public string Username { get; set; }

        [MaxLength(25)]
        public string FirstName { get; set; }

        [MaxLength(25)]
        public string LastName { get; set; }

        [StringLength(30, MinimumLength = 6)]
        public string Password { get; set; }

        public Gender Gender { get; set; }

        public int Age { get; set; }

        public bool IsDeleted { get; set; }

        public virtual ICollection<Event> CreatedEvents { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public virtual ICollection<Team> CreatedTeams { get; set; }
        public virtual ICollection<Invitation> ReceivedInvitations { get; set; }
    }
}