using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;
using ProductShop.Models;

namespace ProductsShop.Client
{
    ///CAR DEALER EXERCISES IN THE SECOND SOLUTION !!!
    class Program
    {
        static void Main()
        {
//            Exercise2();
//            Exercise3.Query1();
//            Exercise3.Query2();
//            Exercise3.Query3();
//              Exercise3.Query4();
        }

        //EX2

        #region Exercise2

        static void Exercise2()
        {
            ImportUsers();
            ImportCategories();
            ImportProducts();
        }

        static void ImportUsers()
        {
            string usersjson = File.ReadAllText("../../Import/users.json");
            List<User> users = JsonConvert.DeserializeObject<List<User>>(usersjson);

            using (var db = new ProductShopContext())
            {
                db.Users.AddOrUpdate(u => new {u.FirstName, u.LastName},
                    users.ToArray());
                db.SaveChanges();
            }
        }

        static void ImportCategories()
        {
            string categoriesjson = File.ReadAllText("../../Import/categories.json");
            List<Category> categories = JsonConvert.DeserializeObject<List<Category>>(categoriesjson);

            using (var db = new ProductShopContext())
            {
                db.Categories.AddOrUpdate(cat => cat.Name, categories.ToArray());
                db.SaveChanges();
            }
        }

        static void ImportProducts()
        {
            string productsjson = File.ReadAllText("../../Import/products.json");
            List<Product> products = JsonConvert.DeserializeObject<List<Product>>(productsjson);

            using (var db = new ProductShopContext())
            {
                int usersCount = db.Users.Count();
                Random rnd = new Random();

                foreach (Product p in products)
                {
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
                }
                db.Products.AddOrUpdate(p => new {p.Name, p.SellerId}, products.ToArray());
                db.SaveChanges();
            }
        }

        #endregion
    }
}