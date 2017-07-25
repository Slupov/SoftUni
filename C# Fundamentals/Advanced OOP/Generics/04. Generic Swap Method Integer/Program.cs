using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_EX___01
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var list = new List<int>();
            Box<int> box = new Box<int>(1);
            for (int i = 0; i < n; i++)
            {
                int str = int.Parse(Console.ReadLine());
                Box<int> b = new Box<int>(str);
                list.Add(str);
            }
            box.list = list;
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.SwapElements(box.list, indexes[0], indexes[1]);
          box.PrintList();
        }
    }
}
