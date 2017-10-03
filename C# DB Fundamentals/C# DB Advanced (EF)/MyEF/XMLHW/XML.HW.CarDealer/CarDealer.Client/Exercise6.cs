using System;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CarDealer.Client.DTOs;
using CarDealer.Client.DTOs.Q1;
using CarDealer.Client.DTOs.Q2;
using CarDealer.Client.DTOs.Q3;
using CarDealer.Client.DTOs.Q4;
using CarDealer.Client.DTOs.Q5;
using CarDealer.Client.DTOs.Q6;
using CarDealer.Data;
using CarDealer.Data.Models;

namespace CarDealer.Client
{
    public class Exercise6
    {
        static void InitializeMapperQ1()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarDTO>()
                    .ForMember(dto => dto.make, opt => opt.MapFrom(src => src.Make))
                    .ForMember(dto => dto.model, opt => opt.MapFrom(src => src.Model))
                    .ForMember(dto => dto.travelledDistance, opt => opt.MapFrom(src => src.TravelledDistance));
            });
        }

        static void InitializeMapperQ2()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Car, CarDTOatr>()
                    .ForMember(dto => dto.id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dto => dto.model, opt => opt.MapFrom(src => src.Model))
                    .ForMember(dto => dto.travelledDistance, opt => opt.MapFrom(src => src.TravelledDistance));
            });
        }

        static void InitializeMapperQ3()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Supplier, SupplierDTO>()
                    .ForMember(dto => dto.id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dto => dto.name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dto => dto.partsCount, opt => opt.MapFrom(src => src.Parts.Count));
            });
        }

        static void InitializeMapperQ4()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Part, PartDTO>()
                    .ForMember(dto => dto.name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dto => dto.price, opt => opt.MapFrom(src => src.Price));

                cfg.CreateMap<Car, CarDTOq4>()
                    .ForMember(dto => dto.make, opt => opt.MapFrom(src => src.Make))
                    .ForMember(dto => dto.model, opt => opt.MapFrom(src => src.Model))
                    .ForMember(dto => dto.travelledDistance, opt => opt.MapFrom(src => src.TravelledDistance))
                    .ForMember(dto => dto.parts, opt => opt.MapFrom(src => src.Parts.ToList()));
            });
        }

        static void InitializeMapperQ5()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Customer, CustomerDTO>()
                    .ForMember(dto => dto.Name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dto => dto.BoughtCars, opt => opt.MapFrom(src => src.Sales.Count))
                    .ForMember(dto => dto.SpentMoney,
                        opt => opt.MapFrom(src => src.Sales.Sum(s => s.Car.Parts.Sum(p => p.Price))));
            });
        }

        static void InitializeMapperQ6()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Part, PartDTO>()
                    .ForMember(dto => dto.name, opt => opt.MapFrom(src => src.Name))
                    .ForMember(dto => dto.price, opt => opt.MapFrom(src => src.Price));

                cfg.CreateMap<Car, CarDTOq6>()
                    .ForMember(dto => dto.make, opt => opt.MapFrom(src => src.Make))
                    .ForMember(dto => dto.model, opt => opt.MapFrom(src => src.Model))
                    .ForMember(dto => dto.travelledDistance, opt => opt.MapFrom(src => src.TravelledDistance));

                cfg.CreateMap<Sale, SaleDTO>()
                    .ForMember(dto => dto.car, opt => opt.MapFrom(src => src.Car))
                    .ForMember(dto => dto.Discount, opt => opt.MapFrom(src => src.Discount))
                    .ForMember(dto => dto.CustomerName, opt => opt.MapFrom(src => src.Customer.Name))
                    .ForMember(dto => dto.Price, opt => opt.MapFrom(src => src.Car.Parts.Sum(p => p.Price)))
                    .ForMember(dto => dto.PriceWithDiscount,
                        opt => opt.MapFrom(src => Math.Round((double) src.Car.Parts.Sum(p => p.Price) * (1 - src.Discount/100d),2)));
            });
        }

        public static void Query1()
        {
            InitializeMapperQ1();

            using (var db = new CarDealerContext())
            {
                var xmlDoc = new XDocument();

                var cars = new CarsDTO()
                {
                    Cars = db.Cars
                        .ProjectTo<CarDTO>()
                        .Where(c => c.travelledDistance > 2 * Math.Pow(10, 6))
                        .OrderBy(c => c.make).ThenBy(c => c.model)
                        .ToList()
                };

                var serializer = new XmlSerializer(typeof(CarsDTO));
                var writer = new StreamWriter("../../Export/cars.xml");

                using (writer)
                {
                    serializer.Serialize(writer, cars);
                }
            }
        }

        public static void Query2()
        {
            InitializeMapperQ2();

            using (var db = new CarDealerContext())
            {
                var xmlDoc = new XDocument();

                var cars = new CarsDTOatr()
                {
                    Cars = db.Cars
                        .Where(c => c.Make == "Ferrari")
                        .ProjectTo<CarDTOatr>()
                        .OrderBy(c => c.model).ThenByDescending(c => c.travelledDistance)
                        .ToList()
                };

                var serializer = new XmlSerializer(typeof(CarsDTO));
                var writer = new StreamWriter("../../Export/ferrari-cars.xml");

                using (writer)
                {
                    serializer.Serialize(writer, cars);
                }
            }
        }

        public static void Query3()
        {
            InitializeMapperQ3();

            using (var db = new CarDealerContext())
            {
                var xmlDoc = new XDocument();

                var cars = new SuppliersDTO()
                {
                    suppliers = db.Suppliers
                        .Where(c => c.IsImporter == false)
                        .ProjectTo<SupplierDTO>()
                        .ToList()
                };

                var serializer = new XmlSerializer(typeof(SuppliersDTO));
                var writer = new StreamWriter("../../Export/local-suppliers.xml");

                using (writer)
                {
                    serializer.Serialize(writer, cars);
                }
            }
        }

        public static void Query4()
        {
            InitializeMapperQ4();

            using (var db = new CarDealerContext())
            {
                var xmlDoc = new XDocument();

                var cars = new CarsDTOq4()
                {
                    Cars = db.Cars
                        .ProjectTo<CarDTOq4>()
                        .ToList()
                };

                var serializer = new XmlSerializer(typeof(CarsDTOq4));
                var writer = new StreamWriter("../../Export/cars-and-parts.xml");

                using (writer)
                {
                    serializer.Serialize(writer, cars);
                }
            }
        }

        public static void Query5()
        {
            InitializeMapperQ5();

            using (var db = new CarDealerContext())
            {
                var xmlDoc = new XDocument();

                var customers = new CustomersDTO()
                {
                    Customers = db.Customers
                        .ProjectTo<CustomerDTO>()
                        .Where(c => c.BoughtCars >= 1)
                        .OrderByDescending(c => c.SpentMoney).ThenByDescending(c => c.BoughtCars)
                        .ToList()
                };

                var serializer = new XmlSerializer(typeof(CustomersDTO));
                var writer = new StreamWriter("../../Export/customers-total-sales.xml");

                using (writer)
                {
                    serializer.Serialize(writer, customers);
                }
            }
        }

        public static void Query6()
        {
            InitializeMapperQ6();

            using (var db = new CarDealerContext())
            {
                var xmlDoc = new XDocument();

                var sales = new SalesDTO()
                {
                    Sales = db.Sales
                        .ProjectTo<SaleDTO>()
                        .ToList()
                };

                var serializer = new XmlSerializer(typeof(SalesDTO));
                var writer = new StreamWriter("../../Export/sales-discounts.xml");

                using (writer)
                {
                    serializer.Serialize(writer, sales);
                }
            }
        }
    }
}