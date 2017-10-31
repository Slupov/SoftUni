using System.ComponentModel.DataAnnotations;

namespace Judge.Data.Models
{
    public class Submission
    {
        [Key]
        public int Id { get; set; }

        public string Code { get; set; }

        public int ContestId { get; set; }
        public Contest Contest { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}