using System;

namespace Enums_and_Attributes_EX___01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rank = Console.ReadLine();
            var suit = Console.ReadLine();
            var card = new Card((Rank) Enum.Parse(typeof(Rank), rank), (Suit) Enum.Parse(typeof(Suit), suit));
            Console.WriteLine(card);
        }
    }
}