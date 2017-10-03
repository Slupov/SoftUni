using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Card_Suit
{
    public class Program
    {
        public static void Main()
        {
            var cards = new List<Card>();
            var ranks = typeof(CardRanks).GetEnumValues();
            var suits = typeof(CardSuits).GetEnumValues();

            foreach (var suit in suits)
            foreach (var rank in ranks)
            {
                var card = new Card((CardRanks) rank, (CardSuits) suit);
                cards.Add(card);
            }

            var firstPlayerName = Console.ReadLine();
            var secondPlayerName = Console.ReadLine();
            var firstPlayerCards = new SortedSet<Card>();
            var secondPlayerCards = new SortedSet<Card>();

            FillSetsOfCards(cards, firstPlayerCards);
            FillSetsOfCards(cards, secondPlayerCards);

            var biggerCardFirstPlayer = firstPlayerCards.Last();
            var biggerCardSecondPlayer = secondPlayerCards.Last();

            if (biggerCardFirstPlayer.CompareTo(biggerCardSecondPlayer) == 1)
                Console.WriteLine($"{firstPlayerName} wins with {biggerCardFirstPlayer}.");
            else
                Console.WriteLine($"{secondPlayerName} wins with {biggerCardSecondPlayer}.");
        }

        private static void FillSetsOfCards(List<Card> cards, SortedSet<Card> collection)
        {
            while (collection.Count < 5)
            {
                var cardTokens = Console.ReadLine().Split();
                CardRanks? rank = null;
                CardSuits? suit = null;
                try
                {
                    rank = (CardRanks) Enum.Parse(typeof(CardRanks), cardTokens[0]);
                    suit = (CardSuits) Enum.Parse(typeof(CardSuits), cardTokens[2]);
                    var cardToAdd = cards.FirstOrDefault(c => c.Rank == rank && c.Suit == suit);

                    if (cardToAdd != null)
                    {
                        collection.Add(cardToAdd);
                        cards.Remove(cardToAdd);
                    }
                    else
                    {
                        Console.WriteLine("Card is not in the deck.");
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("No such card exists.");
                }
            }
        }
    }
}