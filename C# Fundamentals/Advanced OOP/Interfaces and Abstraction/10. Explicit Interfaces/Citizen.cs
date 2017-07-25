
namespace _10.Explicit_Interface
{
    class Citizen : IResident, IPerson
    {
        public Citizen(string name,string age, string country)
        {
            Name = name;
            Age = age;
            Country = country;            
        }

        public string Name { get; protected set; }
        public string Age { get; protected set; }
        public string Country { get; protected set; }

        string IResident.Name { get; }
        string IPerson.Name { get; }

        string IPerson.GetName()
        {
            return $"{this.Name}";
        }

        string IResident.GetName()
        {
            return $"Mr/Ms/Mrs {this.Name}";
        }
    }
}
