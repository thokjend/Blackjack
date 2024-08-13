namespace Blackjack
{
    internal class Hand
    {
        private readonly List<Card> _hand;
        
        public Hand(List<Card> initialCards)
        {
            _hand = initialCards;
        }


        public List<Card> GetHand()
        {
            return _hand;
        }


        public void Show()
        {
            foreach (var card in _hand)
            {
                Console.WriteLine($"[{card}] ");
            }
        }

        public int CalculateValue()
        {
            int sum = 0;
            int numAces = 0;

            foreach (var card in _hand)
            {
                if (card.Name == "Ace") numAces++;
                else sum += card.Value;
            }

            for (int i = 0; i < numAces; i++)
            {
                sum += sum + 11 <= 21 ? 11 : 1;
            }

            return sum;
        }

        public void Draw(Deck deck)
        {
            _hand.Add(deck.Draw());
        }


    }
}
