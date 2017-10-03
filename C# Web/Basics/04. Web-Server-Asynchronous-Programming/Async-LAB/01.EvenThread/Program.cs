using System;
using System.Linq;
using System.Threading;

namespace _01.EvenThread
{
    class Program
    {
        private static void Main()
        {
            var range = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var start = range[0] % 2 == 0 ? range[0] : range[0] + 1;

            Thread t1 = new Thread(() =>
            {
                for (var i = start; i <= range[1]; i += 2)
                {
                    Console.WriteLine(i);
                }
            });

            t1.Start();
            t1.Join();
            Console.WriteLine("Thread finished work");
        }
    }
}