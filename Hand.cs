namespace Blackjack
{
    internal class Hand
    {
        private readonly List<string> _hand;
        
        public Hand(List<string> initialCards)
        {
            _hand = initialCards;
        }


        public List<string> GetHand()
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
                var cardValue = card.Split("of");
                var cardName = cardValue[0].Trim();
                var isValid = Enum.TryParse<cardValues>(cardName, out cardValues value);
                if (!isValid) continue;
                if (value == cardValues.Ace) numAces++;
                else sum += (int)value;
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
