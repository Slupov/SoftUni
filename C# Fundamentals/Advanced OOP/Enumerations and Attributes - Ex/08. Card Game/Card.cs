using System;

namespace _01.Card_Suit
{
    public class Card : IComparable<Card>
    {
        public Card(CardRanks rank, CardSuits suit)
        {
            this.Rank = rank;
            this.Suit = suit;
        }

        public CardRanks Rank { get; set; }

        public CardSuits Suit { get; set; }

        public int CompareTo(Card other)
        {
            return GetCardPower().CompareTo(other.GetCardPower());
        }

        private int GetCardPower()
        {
            return (int) this.Rank + (int) this.Suit;
        }

        public override string ToString()
        {
            return $"{this.Rank} of {this.Suit}";
        }
    }
}