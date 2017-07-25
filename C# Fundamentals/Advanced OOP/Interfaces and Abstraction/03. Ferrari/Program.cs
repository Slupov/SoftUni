using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03.Ferrari
{
    class Program
    {
        static void Main(string[] args)
        {
            string driver = Console.ReadLine();
            Ferrari f = new Ferrari(driver);
            Console.WriteLine(f);

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }

        }
    }
}
