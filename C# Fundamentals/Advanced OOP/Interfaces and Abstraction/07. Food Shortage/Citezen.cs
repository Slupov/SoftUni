namespace _05.Border_Control
{
    public class Citezen : IBuyer
    {

        private string name;
        private string age;
        private string id;
        private string birthdate;
        private int food;

        public Citezen(string name, string age, string id, string birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthdate = birthdate;
            this.Food = 0;
        }

        public string Name
        {
            get { return this.name; }
            protected set { this.name = value; }
        }

        public string Age
        {
            get { return this.age; }
            protected set { this.age = value; }
        }

        public string Id
        {
            get { return this.id; }
            protected set { this.id = value; }
        }

        public string Birthdate
        {
            get { return this.birthdate; }
            protected set { this.birthdate = value; }
        }

        public int Food
        {
            get { return this.food; }
            set { this.food += value; }
        }

        public int BuyFood()
        {
            return 10;
        }
    }
}
