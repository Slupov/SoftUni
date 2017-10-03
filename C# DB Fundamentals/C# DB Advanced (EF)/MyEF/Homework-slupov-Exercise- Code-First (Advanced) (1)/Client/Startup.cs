using System;
using Data;
using Models;

namespace Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            //EX 1,2
//            var ctx = new LocalStoreContext();
//            ctx.Database.Initialize(true);

//            foreach (var product in ctx.Products)
//            {
//                Console.WriteLine(product.Name + " " + product.Quantity);
//            }

            //EX 3
            var ctx = new SalesContext();


        }
    }
}
