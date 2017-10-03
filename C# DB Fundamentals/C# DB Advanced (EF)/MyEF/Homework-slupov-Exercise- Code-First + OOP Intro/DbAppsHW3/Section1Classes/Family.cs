using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAppsHW3
{
    public class Family
    {
        public Family()
        {
            this.Members = new List<Person>();
        }

        private List<Person> Members;
        public void AddMember(Person member)
        {
            this.Members.Add(member);
        }

        public Person GetOldersMember()
        {
            return this.Members.OrderByDescending(m => m.Age).First();
        }
    }
}
