using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Xml.Linq;
using ProductShop.Data;
using ProductShop.Data.Models;

namespace ProductShop.Client
{
    class Program
    {
        static void Main(string[] args)
        {
            //            ImportUsers();
            //            ImportCategories();
            //            ImportProducts();
            var watch = System.Diagnostics.Stopwatch.StartNew();
            watch.Start();
            //            Exercise4.Query1();
            //            Exercise4.Query2();
            //            Exercise4.Query3();
            Exercise4.Query4();
            watch.Stop();
            Console.WriteLine(watch.ElapsedMilliseconds / 1000d + " seconds.");
        }

        #region Exercise3

        static void ImportUsers()
        {
            XDocument xmlDoc = XDocument.Load("../../Import/users.xml");

            if (xmlDoc.Root != null)
            {
                var users = xmlDoc.Root.Elements();

                using (var db = new ProductShopContext())
                {
                    var newUsers = new List<User>();
                    foreach (var user in users)
                    {
                        //<user first-name="Eugene" last-name="Stewart" age="65" />
                        var firstname = user.Attribute("first-name");
                        if (firstname != null)
                            newUsers.Add(
                                new User()
                                {
                                    FirstName = firstname.Value,
                                    LastName = user.Attribute("last-name").Value,
                                    Age =
                                        user.LastAttribute.Name.ToString() != "age"
                                            ? (int?) null
                                            : int.Parse(user.Attribute("age").Value)
                                });
                    }

                    db.Users.AddOrUpdate(u => new {u.FirstName, u.LastName}, newUsers.ToArray());
                    db.SaveChanges();
                }
            }
        }

        static void ImportCategories()
        {
            XDocument xmlDoc = XDocument.Load("../../Import/categories.xml");

            if (xmlDoc.Root != null)
            {
                var categories = xmlDoc.Root.Elements();

                using (var db = new ProductShopContext())
                {
                    foreach (var category in categories)
                    {
                        db.Categories.AddOrUpdate(c => c.Name, new Category()
                        {
                            Name = category.Element("name").Value
                        });
                    }

                    db.SaveChanges();
                }
            }
        }

        static void ImportProducts()
        {
            XDocument xmlDoc = XDocument.Load("../../Import/products.xml");

            if (xmlDoc.Root != null)
            {
                var products = xmlDoc.Root.Elements();

                using (var db = new ProductShopContext())
                {
                    int usersCount = db.Users.Count();
                    Random rnd = new Random();

                    var resultProducts = new List<Product>();
                    foreach (var product in products)
                    {
                        var p = new Product()
                        {
                            Price = decimal.Parse(product.Element("price").Value),
                            Name = product.Element("name").Value
                        };

                        //setting a seller
                        p.SellerId = rnd.Next(1, usersCount);

                        //40% probability of having a buyer
                        if (rnd.NextDouble() >= 0.6)
                        {
                            p.BuyerId = rnd.Next(1, usersCount);
                        }

                        //random number of categories for product (up to 4)
                        for (int c = 0; c < rnd.Next(0, 5); c++)
                        {
                            //add a random category
                            p.Categories.Add(db.Categories.Find(rnd.Next(0, db.Categories.Count())));
                        }

                        resultProducts.Add(p);
                    }

                    db.Products.AddOrUpdate(p => new {p.Name, p.SellerId}, resultProducts.ToArray());

                    db.SaveChanges();
                }
            }
        }

        #endregion
    }
}