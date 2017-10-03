using System;

namespace Enums_and_Attributes_EX___01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (var suit in Enum.GetValues(typeof(Suit)))
            foreach (var rank in Enum.GetValues(typeof(Rank)))
                Console.WriteLine($"{rank} of {suit}");
        }
    }
}