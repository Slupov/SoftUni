using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using CarDealer.Data;
using CarDealer.Data.Models;

namespace CarDealer.Client
{
    class Program
    {
        static void Main(string[] args)
        {
//            Exercise5();
//            SeedSells();
//
//            Exercise6.Query1();
//            Exercise6.Query2();
//            Exercise6.Query3();
//            Exercise6.Query4();
//            Exercise6.Query5();
            Exercise6.Query6();
        }

        static void Exercise5()
        {
            ImportSuppliers();
            ImportCustomers();
            ImportParts();
            ImportCars();
        }

        static void ImportSuppliers()
        {
            XDocument xmlDoc = XDocument.Load("../../Import/suppliers.xml");

            if (xmlDoc.Root != null)
            {
                var suppliers = xmlDoc.Root.Elements();

                var suppliersList = new List<Supplier>();

                using (var db = new CarDealerContext())
                {
                    foreach (var sup in suppliers)
                    {
                        suppliersList.Add(new Supplier()
                        {
                            Name = sup.Attribute("name").Value,
                            IsImporter = bool.Parse(sup.Attribute("is-importer").Value)
                        });
                    }

                    db.Suppliers.AddOrUpdate(s => s.Name, suppliersList.ToArray());

                    db.SaveChanges();
                }
            }
        }

        static void ImportCustomers()
        {
            XDocument xmlDoc = XDocument.Load("../../Import/customers.xml");

            if (xmlDoc.Root != null)
            {
                var customers = xmlDoc.Root.Elements();

                var customersList = new List<Customer>();

                using (var db = new CarDealerContext())
                {
                    foreach (var sup in customers)
                    {
                        customersList.Add(new Customer()
                        {
                            Name = sup.Attribute("name").Value,
                            BirthDate = DateTime.Parse(sup.Element("birth-date").Value),
                            IsYoungDriver = bool.Parse(sup.Element("is-young-driver").Value)
                        });
                    }

                    db.Customers.AddOrUpdate(s => s.Name, customersList.ToArray());

                    db.SaveChanges();
                }
            }
        }

        static void ImportParts()
        {
            XDocument xmlDoc = XDocument.Load("../../Import/parts.xml");

            if (xmlDoc.Root != null)
            {
                Random rnd = new Random();

                var parts = xmlDoc.Root.Elements();

                var partsList = new List<Part>();

                using (var db = new CarDealerContext())
                {
                    int supplierCount = db.Suppliers.Count();

                    foreach (var sup in parts)
                    {
                        partsList.Add(new Part()
                        {
                            Name = sup.Attribute("name").Value,
                            Price = decimal.Parse(sup.Attribute("price").Value),
                            Quantity = int.Parse(sup.Attribute("quantity").Value),
                            Supplier_Id = rnd.Next(1, supplierCount)
                        });
                    }

                    db.Parts.AddOrUpdate(s => new {s.Name, s.Supplier_Id}, partsList.ToArray());

                    db.SaveChanges();
                }
            }
        }

        static void ImportCars()
        {
            XDocument xmlDoc = XDocument.Load("../../Import/cars.xml");

            if (xmlDoc.Root != null)
            {
                Random rnd = new Random();
                var cars = xmlDoc.Root.Elements();
                var carsList = new List<Car>();

                using (var db = new CarDealerContext())
                {
                    var parts = db.Parts.ToList();
                    var partsCount = parts.Count;

                    foreach (var sup in cars)
                    {
                        carsList.Add(new Car()
                        {
                            Make = sup.Element("make").Value,
                            Model = sup.Element("model").Value,
                            TravelledDistance = long.Parse(sup.Element("travelled-distance").Value),
                        });
                    }

                    foreach (var car in carsList)
                        for (var i = 0; i < rnd.Next(10, 21); i++)
                            car.Parts.Add(parts[rnd.Next(1, partsCount)]);

                    try
                    {
                        db.Cars.AddOrUpdate(s => new {s.Make, s.Model, s.TravelledDistance}, carsList.ToArray());
                    }
                    catch (Exception e)
                    {
                        if (e.Message == "Sequence contains more than one element")
                        {
                            Console.WriteLine("Duplicate items! Seed unsuccessful");
                        }
                    }

                    db.SaveChanges();
                }
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
    }
}