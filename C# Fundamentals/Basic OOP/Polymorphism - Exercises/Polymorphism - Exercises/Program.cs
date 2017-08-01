using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism___Exercises
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(' ');
            Car car = new Car(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            input = Console.ReadLine().Split(' ');
            Truck truck = new Truck(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            input = Console.ReadLine().Split(' ');
            Bus bus = new Bus(double.Parse(input[1]), double.Parse(input[2]), double.Parse(input[3]));

            var cmds = int.Parse(Console.ReadLine());

            for (int i = 0; i < cmds; i++)
            {
                input = Console.ReadLine().Split(' ');

                switch (input[0])
                {
                    case "Drive":
                        if (input[1] == "Car")
                        {
                            car.Drive(double.Parse(input[2]));
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Drive(double.Parse(input[2]));
                        }
                        else if (input[1] == "Bus")
                        {
                            bus.Drive(double.Parse(input[2]));
                        }
                        break;
                    case "DriveEmpty":
                        if (input[1] == "Bus")
                        {
                            bus.DriveEmpty(double.Parse(input[2]));
                        }
                        break;
                    case "Refuel":
                        if (input[1] == "Car")
                        {
                            car.Refuel(double.Parse(input[2]));
                        }
                        else if (input[1] == "Truck")
                        {
                            truck.Refuel(double.Parse(input[2]));
                        }
                        else if (input[1] == "Bus")
                        {
                            bus.Refuel(double.Parse(input[2]));
                        }
                        break;
                    default:
                        break;
                }
            }

            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }
    }
}