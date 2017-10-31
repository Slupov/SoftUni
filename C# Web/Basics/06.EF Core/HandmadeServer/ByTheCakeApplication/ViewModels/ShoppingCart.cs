using System.Collections.Generic;

namespace HandmadeServer.ByTheCakeApplication.ViewModels
{
    public class ShoppingCart
    {
        public const string SessionKey = "%^Current_Shopping_Cart^%";

        public List<int> ProductIds { get; private set; } = new List<int>();
    }
}
