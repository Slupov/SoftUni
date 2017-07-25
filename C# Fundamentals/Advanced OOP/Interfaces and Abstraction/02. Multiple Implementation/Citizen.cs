using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.Define_an_Interface_IPerson
{
    class Citizen : IPerson, IIdentifiable, IBirthable
    {
        public Citizen(string name, int age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.BirthDate = birthdate;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Id { get; }
        public string BirthDate { get; }
    }
}
