using System;

namespace Enums_and_Attributes_EX___01
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var rank = Console.ReadLine();
            var suit = Console.ReadLine();
            var rank1 = Console.ReadLine();
            var suit1 = Console.ReadLine();
            var card = new Card((Rank) Enum.Parse(typeof(Rank), rank), (Suit) Enum.Parse(typeof(Suit), suit));
            var card1 = new Card((Rank) Enum.Parse(typeof(Rank), rank1), (Suit) Enum.Parse(typeof(Suit), suit1));
            if (card.CompareTo(card1) < 0)
                Console.WriteLine(card);
            else
                Console.WriteLine(card1);
        }
    }
}