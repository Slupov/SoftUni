using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Data;
using Newtonsoft.Json;

namespace CarDealer.Client
{
    public class Exercise6
    {
        public static void Query1()
        {
            using (var db = new CarDealerContext())
            {
                var customers = db.Customers
                    .OrderBy(c => c.BirthDate)
                    .ThenBy(c => c.IsYoungDriver)
                    .Select(c => new
                    {
                        c.Id,
                        c.Name,
                        c.BirthDate,
                        c.IsYoungDriver,
                        Sales = c.Sales.Select(s => new
                        {
                            Id = s.Id,
                            Car = s.Car_Id + ". " + s.Car.Make + " : " + s.Car.Model,
                            Discount = s.Discount
                        })
                    });
                var customersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/ordered-customers.json", customersJson);
            }
        }

        public static void Query2()
        {
            using (var db = new CarDealerContext())
            {
                var cars = db.Cars
                    .Where(c => c.Make == "Toyota")
                    .OrderBy(c => c.Model).ThenByDescending(c => c.TravelledDistance)
                    .Select(c => new
                    {
                        c.Id,
                        c.Make,
                        c.Model,
                        c.TravelledDistance
                    })
                    .ToList();

                var carsJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/toyota-cars.json", carsJson);
            }
        }

        public static void Query3()
        {
            using (var db = new CarDealerContext())
            {
                var suppliers = db.Suppliers.Where(s => s.IsImporter == false)
                    .Select(s => new
                    {
                        s.Id,
                        s.Name,
                        //fix count
                        PartsCount = s.Parts.Count
                    });

                var suppliersJson = JsonConvert.SerializeObject(suppliers, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/local-suppliers.json", suppliersJson);
            }
        }

        public static void Query4()
        {
            using (var db = new CarDealerContext())
            {
                var cars = db.Cars
                    .Select(c => new
                    {
                        car = new
                        {
                            Make = c.Make,
                            Model = c.Model,
                            TravelledDistance = c.TravelledDistance
                        },
                        parts = c.Parts
                            .Select(p => new {p.Name, p.Price})
                    });

                var suppliersJson = JsonConvert.SerializeObject(cars, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/cars-and-parts.json", suppliersJson);
            }
        }

        public static void Query5()
        {
            using (var db = new CarDealerContext())
            {
                //will get back to summing the cars price
                var customers = db.Customers
                    .Where(c => c.Sales.Any())
                    .Select(c => new
                    {
                        fullname = c.Name,
                        boughtCars = c.Sales.Count,
                        spentMoney =
                        Math.Round(
                            (double) c.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price)) - c.Sales.Sum(s => s.Discount), 2)
                    }).ToList();

                var suppliersJson = JsonConvert.SerializeObject(customers, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/customers-total-sales.json", suppliersJson);
            }
        }

        public static void Query6()
        {
            using (var db = new CarDealerContext())
            {
                var sales = db.Sales
                    .Select(s => new
                    {
                        car = new
                        {
                            Make = s.Car.Make,
                            Model = s.Car.Model,
                            TravelledDistance = s.Car.TravelledDistance
                        },
                        customerName = s.Customer.Name,
                        s.Discount,
                        price = s.Car.Parts.Sum(p => p.Price),
                        priceWithDiscount =
                        Math.Round(
                            (double) s.Car.Parts.Sum(p => p.Price) -
                            (double) s.Car.Parts.Sum(p => p.Price) * (s.Discount / 100), 2)
                    });

                var salesJson = JsonConvert.SerializeObject(sales, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/sales-discounts.json", salesJson);
            }
        }
    }
}