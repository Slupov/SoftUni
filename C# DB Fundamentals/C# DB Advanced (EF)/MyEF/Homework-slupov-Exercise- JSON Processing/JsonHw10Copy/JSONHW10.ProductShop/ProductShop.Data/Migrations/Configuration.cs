using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using ProductShop.Models;

namespace ProductShop.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ProductShop.Data.ProductShopContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ProductShop.Data.ProductShopContext context)
        {
            
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }

        //EX2 
        static void ImportData()
        {
            string usersjson = File.ReadAllText("../../Import/users.json");

            List<User> users = JsonConvert.DeserializeObject<List<User>>(usersjson);
        }
    }
}
