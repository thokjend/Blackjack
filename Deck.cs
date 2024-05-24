namespace Blackjack
{
    internal class Deck
    {
        private List<string> deck;
        private List<string> suits = new List<string> { "Spades", "Hearts", "Diamonds", "Clubs" };
        private readonly Random _random = new Random();

        public Deck()
        {
            deck = new List<string>();
            FillDeckAndShuffle();
        }

        private void FillDeckAndShuffle()
        {
            foreach (var suit in suits)
            {
                foreach (var card in Enum.GetNames(typeof(cardValues)))
                {
                    deck.Add($"{card} of {suit}");
                }
            }

            deck = deck.OrderBy(x => _random.Next()).ToList();
        }


        public string Draw()
        {
            var card = deck.Last();
            deck.RemoveAt(deck.Count - 1);
            return card;
        }

        public List<string> DrawStartingHand()
        {
            return [Draw(), Draw()];
        }

    }
}
