using System;
using System.Linq;

namespace Enums_and_Attributes_EX___01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var command = string.Empty;
            var t = typeof(Weapon);
            var attribute =
                (TypeAttribute)
                typeof(Weapon)
                    .GetCustomAttributes(typeof(TypeAttribute), false).First();
            while ((command = Console.ReadLine()) != "END")
                switch (command)
                {
                    case "Author":
                        Console.WriteLine($"Author: {attribute.Author}");
                        break;

                    case "Revision":
                        Console.WriteLine($"Revision: {attribute.Revision}");
                        break;

                    case "Description":
                        Console.WriteLine($"Class description: {attribute.Description}");
                        break;

                    case "Reviewers":
                        Console.WriteLine($"Reviewers: {string.Join(", ", attribute.Reviewers)}");
                        break;
                }
        }
    }
}