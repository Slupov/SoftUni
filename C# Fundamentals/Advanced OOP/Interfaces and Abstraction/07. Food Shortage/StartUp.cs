using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Border_Control
{
    public class StartUp
    {
        public static void Main()
        {
            int numOfPersons = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();

            for (int i = 0; i < numOfPersons; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (input.Length == 3)
                {
                   Rebel rebel = new Rebel(input[0],input[1],input[2]);                   
                    buyers.Add(rebel);
                }
                if (input.Length == 4)
                {
                    Citezen citezen = new Citezen(input[0],input[1],input[2],input[3]);
                    buyers.Add(citezen);
                }
            }

            Console.WriteLine(BoughtFood(buyers));

        }

        public static int BoughtFood(List<IBuyer> citezens)
        {
            string input = Console.ReadLine();
            while (input != "End")
            {
                foreach (var one in citezens)
                {
                    if (one.Name == input)
                    {
                        one.Food = one.BuyFood();
                    }
                }
                input = Console.ReadLine();
            }
            return citezens.Sum(x => x.Food);
        }
    }
}
