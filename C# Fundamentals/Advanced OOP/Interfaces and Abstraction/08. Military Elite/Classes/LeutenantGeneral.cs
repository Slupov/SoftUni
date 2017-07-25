using System;
using System.Collections.Generic;
using System.Text;

namespace _08.Military_Elite
{
    class LeutenantGeneral : Private, ILeutenantGeneral
    {
        private List<Soldier> privates = new List<Soldier>();

        public LeutenantGeneral(string id, string firstName, string lastName, double salary, List<Soldier> privates) : base(id, firstName, lastName, salary)
        {
            this.Privates = privates;
        }
        
        public List<Soldier> Privates { get;}

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            sb.Append($"Privates:");
            

            foreach (var one in this.Privates)
            {
                sb.Append(Environment.NewLine);
                sb.Append($"  {one.ToString()}");
            }

            return base.ToString() +sb.ToString();
        }
    }
}
