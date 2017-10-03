using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.StudentSystem
{
    public class Resource
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ResourceType { get; set; }
        public string Url { get; set; }
        public virtual Course Course { get; set; }
    }
}
