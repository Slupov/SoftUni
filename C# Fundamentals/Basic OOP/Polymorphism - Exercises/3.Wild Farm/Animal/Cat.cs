using System;

namespace _3.Wild_Farm.Animal
{
    class Cat : Feline
    {
        public Cat(string animalName, string animalType, double animalWeight, string animalRegion, string animalBreed)
        {
            AnimalName = animalName;
            AnimalType = animalType;
            AnimalWeight = animalWeight;
            LivingRegion = animalRegion;
            Breed = animalBreed;
        }
        private string breed;

        public string Breed
        {
            get { return breed; }
            set { breed = value; }
        }

        public override void makeSound()
        {
            Console.WriteLine("Meowwww");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}[{this.AnimalName}, {this.Breed}, {this.AnimalWeight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}