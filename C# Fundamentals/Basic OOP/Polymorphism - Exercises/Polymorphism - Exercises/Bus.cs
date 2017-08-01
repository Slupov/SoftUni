using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism___Exercises
{
    class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            TankCapacity = tankCapacity;
            FuelQuantity = fuelQuantity;
            FuelConsumptionPerKm = fuelConsumption;
        }

        private bool _hasPeople;

        public bool HasPeople
        {
            get { return _hasPeople; }
            set { _hasPeople = value; }
        }

        public override void Drive(double kms)
        {
            IncreaseConsumption(1.4);
            base.Drive(kms);
            FuelConsumptionPerKm -= 1.4;
        }

        public void DriveEmpty(double kms)
        {
            base.Drive(kms);
        }
    }
}