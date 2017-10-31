using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Judge.Data.Models
{
    public class Contest
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        //creator of contest
        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Submission> Submissions { get; set; }
    }
}