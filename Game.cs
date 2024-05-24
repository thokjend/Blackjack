namespace Blackjack
{
    internal class Game
    {

        private readonly Deck _deck;
        private readonly Hand _dealerHand;
        private readonly Hand _playerHand;
        public int PlayerCardsSum { get; private set; }
        public int DealerCardsSum { get; private set; }

        public Game()
        {
            _deck = new Deck();
            _dealerHand = new Hand(_deck.DrawStartingHand());
            _playerHand = new Hand(_deck.DrawStartingHand());
        }

        public void ShowStartingHands()
        {
            MyConsole.WriteDealerCards("Dealer cards: X", _dealerHand.GetHand()[1] );
            MyConsole.Write("Your cards: ");
            _playerHand.Show();
            MyConsole.LineBreak();
        }

        public void DealerDraw()
        {
            while (DealerCardsSum < 17)
            {
                _dealerHand.Draw(_deck);
                DealerCardsSum = _dealerHand.CalculateValue();
            }
        }

        public void CalculateStartingHandsValue()
        {
            PlayerCardsSum = _playerHand.CalculateValue();
            DealerCardsSum = _dealerHand.CalculateValue();
        }

        public void DrawCard()
        {
            _playerHand.Draw(_deck);
            PlayerCardsSum = _playerHand.CalculateValue();
            MyConsole.Write($"Your cards: ");
            _playerHand.Show();
            MyConsole.LineBreak();
        }

        public void End()
        {
            Console.WriteLine($"Dealer has a total of {DealerCardsSum} with these cards:");
            _dealerHand.Show();
            MyConsole.LineBreak();
            Console.WriteLine($"You have a total of {PlayerCardsSum} with these cards:");
            _playerHand.Show();
        }


        public void checkIfWinOrBust()
        {
            if (PlayerCardsSum > DealerCardsSum && PlayerCardsSum < 21) { MyConsole.Write("You won!"); }
            else if (PlayerCardsSum == 21) { MyConsole.Write("Blackjack, you won!"); }
            else if (PlayerCardsSum > 21) { MyConsole.Write("Bust, dealer wins!"); }
            else if (DealerCardsSum > 21) { MyConsole.Write("Dealer Bust, you won!"); }
            else if (PlayerCardsSum == DealerCardsSum) { MyConsole.Write("Draw!"); }
            else if (DealerCardsSum == 21) { MyConsole.Write("Dealer has Blackjack!, you lose!"); }
            else if (PlayerCardsSum < DealerCardsSum && DealerCardsSum < 21) { MyConsole.Write("You lose!"); }
        }

    }
}
