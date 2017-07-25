
using System.Text;

namespace _08.Military_Elite
{
    public class Repair : IRepair
    {
        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }

        public string PartName { get; private set; }

        public int HoursWorked { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}");

            return sb.ToString();
        }
    }
}
