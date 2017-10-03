namespace _05.BarracksWars___Return_of_the_Dependencies.Models.Units
{
    public class Gunner : Unit
    {
        private const int DefaultHealth = 20;
        private const int DefaultDamage = 20;
        public Gunner() : base(DefaultHealth, DefaultDamage)
        {
        }
    }
}