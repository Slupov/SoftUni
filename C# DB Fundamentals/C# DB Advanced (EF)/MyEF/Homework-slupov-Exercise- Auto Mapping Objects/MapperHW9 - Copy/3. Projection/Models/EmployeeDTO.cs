namespace _3.Projection.Models
{
    public class EmployeeDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal Salary { get; set; }
        public string ManagersLastName { get; set; }

        public override string ToString()
        {
            if (this.ManagersLastName == null)
            {
                return $"{this.FirstName} {this.LastName} {this.Salary:F2} - Manager: BIG BOSS";
            }
            return $"{this.FirstName} {this.LastName} {this.Salary:F2} - Manager: {this.ManagersLastName}";
        }
    }
}