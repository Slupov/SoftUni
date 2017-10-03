namespace Enums_and_Attributes_EX___01
{
    internal class Card
    {
        public Card(Rank rank, Suit suit)
        {
            this.Rank = rank;
            this.Suit = suit;
            this.Power = (int) this.Suit + (int) this.Rank;
        }

        public Suit Suit { get; set; }
        public Rank Rank { get; set; }
        public int Power { get; set; }

        public override string ToString()
        {
            return $"Card name: {this.Rank} of {this.Suit}; Card power: {this.Power}";
        }
    }
}