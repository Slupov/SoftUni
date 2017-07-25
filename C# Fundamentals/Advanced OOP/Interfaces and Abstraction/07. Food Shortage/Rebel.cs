namespace _05.Border_Control
{
    public class Rebel : IBuyer
    {
        private string name;
        private string age;
        private string group;
        private int food;

        public Rebel(string name, string age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
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

        public string Group
        {
            get { return this.group; }
            protected set { this.group = value; }
        }

        public int Food
        {
            get { return this.food; }
            set { this.food += value; }
        }

        public int BuyFood()
        {
            return 5;
        }
    }
}
