using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Judge.Data.Validation.Users;

namespace Judge.Data.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(50)]
        [Email]
        public string Email { get; set; }

        [Password]
        public string Password { get; set; }

        [MaxLength(50)]
        public string FullName { get; set; }

        //contests created
        public ICollection<Contest> Contests { get; set; }

        public ICollection<Submission> Submissions { get; set; }

        public bool IsAdmin { get; set; }
    }
}