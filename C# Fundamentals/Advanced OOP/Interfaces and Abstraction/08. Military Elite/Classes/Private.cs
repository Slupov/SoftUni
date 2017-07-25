using System.Text;

namespace _08.Military_Elite
{
    public class Private : Soldier, IPrivate
    {

        public Private(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
         
        public double Salary { get; protected set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($" Salary: {this.Salary:f2}");

            return base.ToString() + sb.ToString();
        }
    }
}
