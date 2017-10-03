using System;

namespace Enums_and_Attributes_EX___01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var command = Console.ReadLine();
            Type t = null;
            if (command == "Rank")
                t = typeof(Rank);
            else
                t = typeof(Suit);
            var attributes = t.GetCustomAttributes(false);

            foreach (var attribute in attributes)
                Console.WriteLine(attribute);
        }
    }
}