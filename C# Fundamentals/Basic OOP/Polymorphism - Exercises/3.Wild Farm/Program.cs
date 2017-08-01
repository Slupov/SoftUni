using System;
using _3.Wild_Farm.Animal;
using _3.Wild_Farm.Food;

namespace _3.Wild_Farm
{
    class Program
    {
        private static void Main(string[] args)
        {
            FeedAnimals();
        }

        private static void FeedAnimals()
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var animalInformation = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                var foodInformation = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Animal.Animal currentAnimal = null;
                Food.Food currentFood = null;

                var animalType = animalInformation[0];
                var animalName = animalInformation[1];
                var animalWeight = double.Parse(animalInformation[2]);
                var animalRegion = animalInformation[3];
                var animalBreed = string.Empty;
                if (animalType == "Cat")
                {
                    animalBreed = animalInformation[4];
                    currentAnimal = new Cat(animalName, animalType, animalWeight, animalRegion, animalBreed);
                }
                else
                {
                    switch (animalType)
                    {
                        case "Tiger":
                            currentAnimal = new Tiger(animalName, animalType, animalWeight, animalRegion);
                            break;

                        case "Zebra":
                            currentAnimal = new Zebra(animalName, animalType, animalWeight, animalRegion);
                            break;

                        case "Mouse":
                            currentAnimal = new Mouse(animalName, animalType, animalWeight, animalRegion);
                            break;
                    }
                }

                var foodType = foodInformation[0];
                var foodAmount = int.Parse(foodInformation[1]);

                if (foodType == "Vegetable")
                {
                    currentFood = new Vegetable(foodAmount);
                }
                else if (foodType == "Meat")
                {
                    currentFood = new Meat(foodAmount);
                }

                currentAnimal.makeSound();
                currentAnimal.eatFood(currentFood);

                Console.WriteLine(currentAnimal);
            }
        }
    }
}