using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarDealer.Data;
using CarDealer.Models;
using Newtonsoft.Json;

namespace CarDealer.Client
{
    internal class Program
    {
        private static void Main(string[] args)
        {
//            Exercise5();
//            SeedSells();
//            Exercise6.Query1();
//            Exercise6.Query2();
//            Exercise6.Query3();
//            Exercise6.Query4();
//            Exercise6.Query5();
//            Exercise6.Query6();
        }

        #region Exercise5

        private static void Exercise5()
        {
            ImportSuppliers();
            ImportCustomers();
            ImportParts();
            ImportCars();
        }

        private static void ImportSuppliers()
        {
            var suppliersjson = File.ReadAllText("../../Import/suppliers.json");

            var suppliers = JsonConvert.DeserializeObject<List<Supplier>>(suppliersjson);

            using (var db = new CarDealerContext())
            {
                try
                {
                    db.Suppliers.AddOrUpdate(s => s.Name, suppliers.ToArray());
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    //in case there's a duplicate values in the json
                    if (e.Message != "Sequence contains more than one element")
                        throw;
                }
            }
        }

        private static void ImportCustomers()
        {
            var customersjson = File.ReadAllText("../../Import/customers.json");

            var customers = JsonConvert.DeserializeObject<List<Customer>>(customersjson);

            using (var db = new CarDealerContext())
            {
                db.Customers.AddOrUpdate(s => new {s.Name, s.BirthDate}, customers.ToArray());
                db.SaveChanges();
            }
        }

        private static void ImportParts()
        {
            var partsjson = File.ReadAllText("../../Import/parts.json");

            var parts = JsonConvert.DeserializeObject<List<Part>>(partsjson);
            using (var db = new CarDealerContext())
            {
                var rnd = new Random();
                var suppliersCount = db.Suppliers.Count();

                foreach (var part in parts)
                    part.Supplier_Id = rnd.Next(1, suppliersCount);

                db.Parts.AddOrUpdate(p => new {p.Name, p.Price}, parts.ToArray());
                db.SaveChanges();
            }
        }

        private static void ImportCars()
        {
            var carsjson = File.ReadAllText("../../Import/cars.json");

            var cars = JsonConvert.DeserializeObject<List<Car>>(carsjson);

            using (var db = new CarDealerContext())
            {
                var rnd = new Random();
                var parts = db.Parts.ToList();
                var partsCount = parts.Count;

                foreach (var car in cars)
                    for (var i = 0; i < rnd.Next(10, 21); i++)
                        car.Parts.Add(parts[rnd.Next(1, partsCount)]);

                db.Cars.AddOrUpdate(c => new {c.Make, c.Model, c.TravelledDistance}, cars.ToArray());
                db.SaveChanges();
            }
        }

        private static void SeedSells()
        {
            using (var db = new CarDealerContext())
            {
                var rnd = new Random();
                var sales = new List<Sale>();
                var customersCount = db.Customers.Count();
                var carsCount = db.Cars.Count();

                //random number of sells (up to 20)
                for (var i = 0; i < rnd.Next(1, 20); i++)
                {
                    var temp = new Sale()
                    {
                        Customer_Id = rnd.Next(1, customersCount),
                        Car_Id = rnd.Next(1, carsCount),
                        Discount = Math.Round(rnd.NextDouble() * 30.00d, 2, MidpointRounding.AwayFromZero)
                    };

                    sales.Add(temp);
                }

                db.Sales.AddOrUpdate(s => s.Car_Id, sales.ToArray());
                db.SaveChanges();
            }
        }

        #endregion
    }
}