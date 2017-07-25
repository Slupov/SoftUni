using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_EX___01
{
    public class Threeuple<Item1, Item2, Item3>
    {
        private Item1 item1;
        private Item2 item2;
        private Item3 item3;
        public Threeuple(Item1 x, Item2 y, Item3 z)
        {
            item1 = x;
            item2 = y;
            item3 = z;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2} -> {item3}";
        }
    }
}
