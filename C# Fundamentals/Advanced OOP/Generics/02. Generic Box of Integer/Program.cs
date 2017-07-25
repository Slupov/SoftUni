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

            for (int i = 0; i < n; i++)
            {
                int str = int.Parse(Console.ReadLine());
                Box<int> b = new Box<int>(str);
                Console.WriteLine(b);
            }
        }
    }
}
