using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism___Exercises
{
    class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumption;
            IncreaseConsumption(1.6);
        }

        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }

        protected override double FuelQuantity
        {
            get { return _fuelQuantity; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                    return;
                }
                _fuelQuantity = value;
            }
        }
    }
}
