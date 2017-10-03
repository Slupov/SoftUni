using System.Linq;
using Newtonsoft.Json;
using ProductShop.Data;

namespace ProductsShop
{
    public class Exercise3
    {
        public static void Query1()
        {
            using (ProductShopContext db = new ProductShopContext())
            {
                var products =
                    db.Products.Where(p => p.Price >= 500 && p.Price <= 1000)
                        .OrderBy(p => p.Price)
                        .Select(
                            p => new
                            {
                                name = p.Name,
                                price = p.Price,
                                seller = p.Seller.FirstName + " " + p.Seller.LastName
                            })
                        .ToList();

                var productsJson = JsonConvert.SerializeObject(products, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/products-in-range.json", productsJson);
            }
        }

        public static void Query2()
        {
            using (ProductShopContext db = new ProductShopContext())
            {
                var users = db.Users
                    .Where(s => s.SoldProducts.Count() > 0)
                    .Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        soldProducts = u.SoldProducts.Where(sp => sp.Buyer != null).Select(sp => new
                        {
                            name = sp.Name,
                            price = sp.Price,
                            buyerFirstName = sp.Buyer.FirstName,
                            buyerLastName = sp.Buyer.LastName
                        })
                    })
                    .OrderBy(u => u.lastName).ThenBy(u => u.firstName)
                    .ToList();

                var productsJson = JsonConvert.SerializeObject(users, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/users-sold-products.json", productsJson);
            }
        }

        public static void Query3()
        {
            using (ProductShopContext db = new ProductShopContext())
            {
                var categories = db.Categories
                    .Select(c => new
                    {
                        category = c.Name,
                        productsCount = c.Products.Count,
                        averagePrice = c.Products.Any() ? c.Products.Average(p => p.Price) : 0,
                        totalRevenue = c.Products.Any() ? c.Products.Sum(p => p.Price) : 0,
                    })
                    .OrderBy(cat => cat.category).ToList();


                var productsJson = JsonConvert.SerializeObject(categories, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/categories-by-products.json", productsJson);
            }
        }

        public static void Query4()
        {
            using (ProductShopContext db = new ProductShopContext())
            {
                var users = db.Users.Where(u => u.SoldProducts.Any())
                    .OrderByDescending(u => u.SoldProducts.Count())
                    .ThenBy(u => u.LastName);

                object result = new
                {
                    usersCount = users.Count(),
                    users = users.Select(u => new
                    {
                        firstName = u.FirstName,
                        lastName = u.LastName,
                        age = u.Age,
                        soldProducts = new
                        {
                            count = u.SoldProducts.Count,
                            products = u.SoldProducts
                                .Select(sp => new
                                {
                                    name = sp.Name,
                                    price = sp.Price
                                })
                        }
                    })
                };


                var productsJson = JsonConvert.SerializeObject(result, Formatting.Indented);

                System.IO.File.WriteAllText("../../Export/users-and-products.json", productsJson);
            }
        }
    }
}