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
            var list = new List<string>();
            Box<string> box = new Box<string>("");
            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                Box<string> b = new Box<string>(str);
                list.Add(b.ToString());
            }
            box.list = list;
            var indexes = Console.ReadLine().Split().Select(int.Parse).ToArray();
            box.SwapElements(box.list, indexes[0], indexes[1]);
          box.PrintList();
        }
    }
}
