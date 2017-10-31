using System.Collections.Generic;

namespace HandmadeServer.ByTheCakeApplication.Services
{
    public interface IShoppingService
    {
        void CreateOrder(int userId, IEnumerable<int> productIds);
    }
}
