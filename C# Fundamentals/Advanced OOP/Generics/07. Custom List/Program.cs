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
            CustomList<string> list = new CustomList<string>();
            string input = string.Empty;
            while ((input = Console.ReadLine()) != "END")
            {
                string[] tokens = input.Split();
                switch (tokens[0])
                {
                    case "Add":
                        list.Add(tokens[1]);
                        break;
                    case "Max":
                        Console.WriteLine(list.Max());
                        break;
                    case "Min":
                        Console.WriteLine(list.Min());
                        break;
                    case "Remove":
                        list.Remove(int.Parse(tokens[1]));
                        break;
                    case "Greater":
                        Console.WriteLine(list.CountGreaterThan(tokens[1]));
                        break;
                    case "Swap":
                        list.Swap(int.Parse(tokens[1]), int.Parse(tokens[2]));
                        break;
                    case "Contains":
                        Console.WriteLine(list.Contains(tokens[1]));
                        break;
                    case "Print":
                        list.Print();
                        break;
                }
            }
        }
    }
}
