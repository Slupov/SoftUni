
using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Border_Control
{
    public class StartUp
    {
        public static void Main()
        {
            List<string> birthdays = TakeIds();
            string birthYear = Console.ReadLine();
            IBirthdate citezens = new BirthdayChecker();

            foreach (var birthday in birthdays)
            {
                if (citezens.CheckBirthdate(birthday, birthYear))
                {
                    Console.WriteLine(birthday);
                }

            }
        }

        public static List<string> TakeIds()
        {
            string[] input = Console.ReadLine().Split(new []{' ','\n','\t'},StringSplitOptions.RemoveEmptyEntries);

            List<string> ids = new List<string>();

            while (input[0] != "End")
            {
                if (input[0] != "Robot")
                {
                    ids.Add(input.Last());
                }             
                input = Console.ReadLine().Split(new[] { ' ', '\n', '\t' }, StringSplitOptions.RemoveEmptyEntries);
            }
            return ids;
        }
    }
}
