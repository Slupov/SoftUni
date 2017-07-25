using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_EX___01
{
    class Sorter<T> where T : IComparable<T>
    {
        public static void Sort(CustomList<T> list)
        {
            list._items.Sort();
        }
    }
}
