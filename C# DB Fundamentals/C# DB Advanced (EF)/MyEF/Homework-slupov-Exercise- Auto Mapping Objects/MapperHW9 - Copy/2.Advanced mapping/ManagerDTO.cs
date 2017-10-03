using System.Collections.Generic;
using System.Text;

namespace _2.Advanced_mapping
{
    public class ManagerDTO
    {
        public ManagerDTO()
        {
            Subordinates = new List<EmployeeDto>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<EmployeeDto> Subordinates { get; set; }

        public int SubordinatesCount { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"{this.FirstName} {this.LastName} | Employees: {this.SubordinatesCount}");
            foreach (EmployeeDto subordinate in this.Subordinates)
            {
                sb.AppendLine(subordinate.ToString());
            }

            return sb.ToString();
        }
    }
}