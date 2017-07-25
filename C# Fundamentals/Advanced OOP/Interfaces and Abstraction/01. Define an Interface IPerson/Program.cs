using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _01.Define_an_Interface_IPerson
{
    class Program
    {
        public static void Main(string[] args)
        {
            Type personInterface = typeof(Citizen).GetInterface("IPerson");
            PropertyInfo[] properties = personInterface.GetProperties();
            Console.WriteLine(properties.Length);
            string name = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            IPerson person = new Citizen(name, age);
            Console.WriteLine(person.Name);
            Console.WriteLine(person.Age);
        }
    }
}