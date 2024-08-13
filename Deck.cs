namespace Blackjack
{
    internal class Deck
    {
        private List<Card> deck;
        private List<string> suits = new List<string> { "Spades", "Hearts", "Diamonds", "Clubs" };
        private readonly Random _random = new Random();

        public Deck()
        {
            deck = new List<Card>();
            FillDeckAndShuffle();
        }

        private void FillDeckAndShuffle()
        {
            foreach (var suit in suits)
            {
                foreach (var cardName in Enum.GetNames(typeof(cardValues)))
                {
                    var cardValue = (int)Enum.Parse(typeof(cardValues), cardName);
                    deck.Add(new Card(cardName,cardValue,suit));
                }
            }

            deck = deck.OrderBy(x => _random.Next()).ToList();
        }


        public Card Draw()
        {
            var card = deck.Last();
            deck.RemoveAt(deck.Count - 1);
            return card;
        }

        public List<Card> DrawStartingHand()
        {
            return new List<Card> { Draw(), Draw() };
        }

    }
}
