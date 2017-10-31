using System;
using System.Collections.Generic;
using System.Linq;
using HandmadeServer.ByTheCakeApplication.Data;
using HandmadeServer.ByTheCakeApplication.Data.Models;

namespace HandmadeServer.ByTheCakeApplication.Services
{
    public class ShoppingService : IShoppingService
    {
        public void CreateOrder(int userId, IEnumerable<int> productIds)
        {
            using (var db = new ByTheCakeDbContext())
            {
                var order = new Order
                {
                    UserId = userId,
                    CreationDate = DateTime.UtcNow,
                    Products = productIds
                        .Select(id => new OrderProduct
                        {
                            ProductId = id
                        })
                        .ToList()
                };

                db.Add(order);
                db.SaveChanges();
            }
        }
    }
}
