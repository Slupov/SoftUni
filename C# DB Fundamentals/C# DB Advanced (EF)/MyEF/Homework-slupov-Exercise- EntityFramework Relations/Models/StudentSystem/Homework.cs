using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.StudentSystem
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
