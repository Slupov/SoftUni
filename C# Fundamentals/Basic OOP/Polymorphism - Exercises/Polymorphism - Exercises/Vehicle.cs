namespace Polymorphism___Exercises
{
    using System;

    abstract class Vehicle
    {
        protected double _fuelQuantity;
        protected virtual double FuelQuantity
        {
            get { return _fuelQuantity; }
            set
            {
                if (value <= 0)
                {
                    Console.WriteLine("Fuel must be a positive number");
                    return;
                }
                else if (value > TankCapacity)
                {
                    Console.WriteLine("Cannot fit fuel in tank");
                    return;
                }
                _fuelQuantity = value;
            }
        }

        protected double _tankCapacity;
        protected double TankCapacity
        {
            get { return _tankCapacity; }
            set { _tankCapacity = value; }
        }


        protected double _fuelConsumptionPerKm;
        protected double FuelConsumptionPerKm
        {
            get { return _fuelConsumptionPerKm; }
            set { _fuelConsumptionPerKm = value; }
        }


        public virtual void Drive(double kms)
        {
            if (CanTravel(kms))
            {
                FuelQuantity -= FuelConsumptionPerKm * kms;
                Console.WriteLine("{0} travelled {1} km", this.GetType().Name, kms);
            }
            else
            {
                Console.WriteLine("{0} needs refueling", this.GetType().Name);
            }
        }

        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
                return;
            }
            this.FuelQuantity += fuel;
        }

        protected virtual void IncreaseConsumption(double increaseValue)
        {
            this.FuelConsumptionPerKm += increaseValue;
        }

        protected bool CanTravel(double kms)
        {
            if (FuelConsumptionPerKm * kms > FuelQuantity)
            {
                return false;
            }

            return true;
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}