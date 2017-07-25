using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.Smartphone
{
    class Program
    {
        static void Main(string[] args)
        {
            ISmartphone smartPhone = new Smartphone();
            string[] numArr = Console.ReadLine().Split().ToArray();
            string[] urlArr = Console.ReadLine().Split().ToArray();

            foreach (var num in numArr)
            {
                try
                {
                    Console.WriteLine(smartPhone.Call(num));
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            }
            foreach (var url in urlArr)
            {
                try
                {
                    Console.WriteLine(smartPhone.Browse(url));
                }
                catch (ArgumentException argumentException)
                {
                    Console.WriteLine(argumentException.Message);
                }
            }
        }
    }
}
