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
            string[] first = Console.ReadLine().Split();
            string[] second = Console.ReadLine().Split();
            string[] third = Console.ReadLine().Split();
            Threeuple<string, string, string> tuple1 = new Threeuple<string, string, string>(first[0] + " " + first[1], first[2], first[3]);
            Threeuple<string, int, bool> tuple2 = new Threeuple<string, int, bool>(second[0], int.Parse(second[1]), second[2] == "drunk" ? true : false);
            Threeuple<string, double, string> tuple3 = new Threeuple<string, double, string>(third[0], double.Parse(third[1]), third[2]);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}