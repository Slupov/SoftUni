namespace _05.BarracksWars___Return_of_the_Dependencies.Models.Units
{
    public class Horseman : Unit
    {
        private const int DefaultHealth = 50;
        private const int DefaultDamage = 10;
        public Horseman() : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}