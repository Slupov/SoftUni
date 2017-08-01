using System;

namespace _3.Wild_Farm.Animal
{
    abstract class Animal
    {
        protected string animalName;

        public string AnimalName
        {
            get { return animalName; }
            set { animalName = value; }
        }

        protected string animalType;

        public string AnimalType
        {
            get { return animalType; }
            set { animalType = value; }
        }

        protected double animalWeight;

        public double AnimalWeight
        {
            get { return animalWeight; }
            set { animalWeight = value; }
        }

        protected int foodEaten;

        public int FoodEaten
        {
            get { return foodEaten; }
            set { foodEaten = value; }
        }

        public abstract void makeSound();

        public virtual void eatFood(Food.Food food)
        {
            if (this.GetType().Name == "Zebra" || this.GetType().Name == "Mouse")
            {
                if (food.GetType().Name != "Vegetable")
                {
                    Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
                    return;
                }
            }
            else if (this.GetType().Name == "Tiger")
            {
                if (food.GetType().Name == "Vegetable")
                {
                    Console.WriteLine($"{this.GetType().Name}s are not eating that type of food!");
                    return;
                }
            }

            this.FoodEaten += food.Quantity;
        }
    }
}