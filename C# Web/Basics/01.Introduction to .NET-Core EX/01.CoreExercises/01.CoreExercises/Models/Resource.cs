using System.ComponentModel.DataAnnotations;

namespace _01.Student_System.Models
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
