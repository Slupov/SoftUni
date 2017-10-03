using System;

namespace Enums_and_Attributes_EX___01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Card Ranks:");
            foreach (var EnumName in Enum.GetValues(typeof(Suit)))
                Console.WriteLine($"Ordinal value: {(int) EnumName}; Name value: {EnumName}");
        }
    }
}