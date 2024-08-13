namespace Blackjack
{
    internal class Card
    {
        public int Value { get; }
        public string Suit { get; }
        public string Name { get; }

        public Card(string name, int value, string suit)
        {
            Name = name;
            Value = value;
            Suit = suit;
        }

        public override string ToString()
        {
            return $"{Name} of {Suit}";
        }
    }
}