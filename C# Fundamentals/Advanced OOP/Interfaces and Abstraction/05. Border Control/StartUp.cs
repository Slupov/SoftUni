
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Border_Control
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> ids = TakeIds();
            string fake = Console.ReadLine();
            IId citezens = new Idchecker();

            foreach (var id in ids)
            {
                if (citezens.CheckId(id, fake))
                {
                    Console.WriteLine(id);
                }

            }
        }

        public static List<string> TakeIds()
        {
            string[] input = Console.ReadLine().Split();

            List<string> ids = new List<string>();

            while (input[0] != "End")
            {
                ids.Add(input.Last());
                input = Console.ReadLine().Split();
            }
            return ids;
        }
    }
}
