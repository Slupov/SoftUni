using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_EX___01
{
    public class Tuple<Item1, Item2>
    {
        private Item1 item1;
        private Item2 item2;
        public Tuple(Item1 x, Item2 y)
        {
            item1 = x;
            item2 = y;
        }

        public override string ToString()
        {
            return $"{item1} -> {item2}";
        }
    }
}
