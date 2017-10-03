using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using ProductShop.Client.DTOs;
using ProductShop.Data;
using ProductShop.Data.Models;

namespace ProductShop.Client
{
    //second solution uses DTOs and automapper only !
    internal class Exercise4
    {
        public static void InitializeMapperQ3()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryDTO>()
                .ForMember(dto => dto.ProductsCount, opt => opt.MapFrom(src => src.Products.Count))
                .ForMember(dto => dto.AveragePrice,
                    opt => opt.MapFrom(src => src.Products.Count == 0 ? 0 : src.Products.Average(p => p.Price)))
                .ForMember(dto => dto.TotalRevenue,
                    opt => opt.MapFrom(src => src.Products.Count == 0 ? 0 : src.Products.Sum(p => p.Price))));
        }

        public static void InitializeMapperQ4()
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Category, CategoryDTO>()
                .ForMember(dto => dto.ProductsCount, opt => opt.MapFrom(src => src.Products.Count))
                .ForMember(dto => dto.AveragePrice,
                    opt => opt.MapFrom(src => src.Products.Count == 0 ? 0 : src.Products.Average(p => p.Price)))
                .ForMember(dto => dto.TotalRevenue,
                    opt => opt.MapFrom(src => src.Products.Count == 0 ? 0 : src.Products.Sum(p => p.Price))));
        }


        //using basic select from LINQ
        public static void Query1()
        {
            using (var db = new ProductShopContext())
            {
                var xmlDoc = new XDocument();
                xmlDoc.Add(new XElement("products"));

                var products = db.Products
                    .Where(p => p.Price >= 1000 && p.Price <= 2000 && p.BuyerId.HasValue)
                    .OrderBy(p => p.Price)
                    .Select(p => new
                    {
                        name = p.Name,
                        price = p.Price,
                        buyer = p.Buyer.FirstName + " " + p.Buyer.LastName
                    });

                foreach (var product in products)
                {
                    var current = new XElement("product");
                    current.SetAttributeValue("name", product.name);
                    current.SetAttributeValue("price", product.price);
                    current.SetAttributeValue("buyer", product.buyer);

                    xmlDoc.Root.Add(current);
                }

                xmlDoc.Save("../../Export/products-in-range.xml");
            }
        }

        public static void Query2()
        {
            using (var db = new ProductShopContext())
            {
                var xmlDoc = new XDocument();
                xmlDoc.Add(new XElement("users"));

                var users = db.Users
                    .Where(u => u.SoldProducts.Count >= 1)
                    .OrderBy(u => u.LastName)
                    .ThenBy(u => u.FirstName)
                    .Select(u => new
                    {
                        firstname = u.FirstName,
                        lastname = u.LastName,
                        soldProducts = u.SoldProducts.Select(p => new {name = p.Name, price = p.Price})
                    });

                foreach (var user in users)
                {
                    var current = new XElement("user");
                    current.SetAttributeValue("first-name", user.firstname);
                    current.SetAttributeValue("last-name", user.lastname);

                    current.Add(new XElement("sold-products"));

                    foreach (var sp in user.soldProducts)
                    {
                        var prod = new XElement("product");
                        prod.Add(new XElement("name", sp.name));
                        prod.Add(new XElement("price", sp.price));

                        current.Element("sold-products").Add(prod);
                    }

                    xmlDoc.Root.Add(current);
                }

                xmlDoc.Save("../../Export/users-sold-products.xml");
            }
        }

        //using DTOs and AutoMapper
        public static void Query3()
        {
            InitializeMapperQ3();

            using (var db = new ProductShopContext())
            {
                var xmlDoc = new XDocument();

                var categories = new CategoriesDTO()
                {
                    Categories = db.Categories
                        .ProjectTo<CategoryDTO>()
                        .OrderByDescending(c => c.ProductsCount)
                        .ToList()
                };

                var serializer = new XmlSerializer(typeof(CategoriesDTO));
                var writer = new StreamWriter("../../Export/categories-by-products.xml");

                using (writer)
                {
                    serializer.Serialize(writer, categories);
                }
            }
        }

        //using basic select from LINQ
        public static void Query4()
        {
            using (var db = new ProductShopContext())
            {
                var xmlDoc = new XDocument();
                xmlDoc.Add(new XElement("users"));

                var users = db.Users
                    .Where(u => u.SoldProducts.Count >= 1)
                    .OrderByDescending(u => u.SoldProducts.Count)
                    .ThenBy(u => u.LastName)
                    .Select(u => new {u.FirstName, u.LastName, u.Age, u.SoldProducts});

                foreach (var user in users)
                {
                    var currentUser = new XElement("user");
                    currentUser.SetAttributeValue("first-name", user.FirstName);
                    currentUser.SetAttributeValue("last-name", user.LastName);
                    currentUser.SetAttributeValue("age", user.Age);

                    var soldProducts = new XElement("sold-products");

                    foreach (var soldProduct in user.SoldProducts)
                    {
                        var sp = new XElement("product");

                        sp.SetAttributeValue("name", soldProduct.Name);
                        sp.SetAttributeValue("price", soldProduct.Price);

                        soldProducts.Add(sp);
                    }

                    soldProducts.SetAttributeValue("count", user.SoldProducts.Count);
                    currentUser.Add(soldProducts);

                    xmlDoc.Root.Add(currentUser);
                }
                xmlDoc.Root.SetAttributeValue("count", users.Count());

                xmlDoc.Save("../../Export/users-and-products.xml");
            }
        }
    }
}