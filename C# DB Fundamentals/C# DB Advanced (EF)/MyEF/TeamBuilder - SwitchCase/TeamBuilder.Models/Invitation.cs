using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Invitation
    {
        public Invitation()
        {
            this.IsActive = true;
        }
        [Key]
        public int Id { get; set; }

        public int InvitedUserId { get; set; }
        public User InvitedUser { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }

        public bool IsActive { get; set; }
    }
}