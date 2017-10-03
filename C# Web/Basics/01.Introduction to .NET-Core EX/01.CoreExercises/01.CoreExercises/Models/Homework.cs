using System;
using System.ComponentModel.DataAnnotations;

namespace _01.Student_System.Models
{
    public class Homework
    {
        public Homework()
        {
            //Homework limit is 5MB
            this.Content = new byte[5120];
        }
        [Key]
        public int Id { get; set; }
        public byte[] Content { get; set; }
        public string ContentType { get; set; }
        public DateTime SubmissionDate { get; set; }
        public virtual Student Student { get; set; }
    }
}
