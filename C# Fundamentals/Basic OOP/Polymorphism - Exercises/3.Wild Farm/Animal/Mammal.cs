namespace _3.Wild_Farm.Animal
{
    abstract class Mammal : Animal
    {
        protected string livingRegion;
        public string LivingRegion
        {
            get { return livingRegion; }
            set { livingRegion = value; }
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.AnimalName}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
