using System.ComponentModel.DataAnnotations;

namespace _01.Student_System.Models
{
    public class License
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Resource Resource { get; set; }
    }
}
