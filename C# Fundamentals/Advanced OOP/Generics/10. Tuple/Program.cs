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
            Tuple<string, string> tuple1 = new Tuple<string, string>(first[0] + " " + first[1], first[2]);
            Tuple<string, int> tuple2 = new Tuple<string, int>(second[0], int.Parse(second[1]));
            Tuple<int, double> tuple3 = new Tuple<int, double>(int.Parse(third[0]), double.Parse(third[1]));

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}