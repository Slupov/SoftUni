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
            List<IComparable<double>> list = new List<IComparable<double>>();
            for (int i = 0; i < n; i++)
            {
                double str = Convert.ToDouble(Console.ReadLine());
                list.Add(str);
            }
            double s = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine(CompareMethod(list,s));
        }

        public static int CompareMethod<T>(List<IComparable<T>> list, T element)
        {
            return list.Count(x => x.CompareTo(element) > 0);
        }
    }
}
