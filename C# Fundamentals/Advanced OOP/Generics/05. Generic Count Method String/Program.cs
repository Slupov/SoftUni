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
            List<IComparable<string>> list = new List<IComparable<string>>();
            for (int i = 0; i < n; i++)
            {
                string str = Console.ReadLine();
                list.Add(str);
            }
            string s = Console.ReadLine();
            Console.WriteLine(CompareMethod(list,s));
        }

        public static int CompareMethod<T>(List<IComparable<T>> list, T element)
        {
            return list.Count(x => x.CompareTo(element) > 0);
        }
    }
}
