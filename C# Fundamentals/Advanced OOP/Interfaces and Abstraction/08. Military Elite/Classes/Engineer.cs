using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Military_Elite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        private List<Repair> repairs = new List<Repair>();

        public Engineer(string id, string firstName, string lastName, double salary, string corps, List<Repair> repairs) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = repairs;
        }
        
        public List<Repair> Repairs { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append($"Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.Append(Environment.NewLine);
                sb.Append($"  {repair.ToString()}");
            }

            return base.ToString() + sb.ToString();
        }
    }
}
