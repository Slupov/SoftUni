using System;

namespace _3.Wild_Farm.Animal
{
    class Tiger : Feline
    {
        public Tiger(string animalName, string animalType, double animalWeight, string animalRegion)
        {
            AnimalName = animalName;
            AnimalType = animalType;
            AnimalWeight = animalWeight;
            LivingRegion = animalRegion;
        }
        public override void makeSound()
        {
            Console.WriteLine("ROAAR!!!");
        }
    }
}
