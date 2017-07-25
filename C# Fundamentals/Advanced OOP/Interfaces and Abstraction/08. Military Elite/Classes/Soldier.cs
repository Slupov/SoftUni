using System.Text;


namespace _08.Military_Elite
{
   public abstract class Soldier : ISoldier
    {

        protected Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;        
        }

        public string Id { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");

            return sb.ToString();           
        }
    }
}
