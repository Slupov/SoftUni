namespace Polymorphism___Exercises
{
    class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumption;
            IncreaseConsumption(0.9);
        }
    }
}
