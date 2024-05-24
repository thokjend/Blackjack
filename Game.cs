namespace Blackjack
{
    internal class Game
    {

        private readonly Deck _deck;
        private readonly Hand _dealerHand;
        private readonly Hand _playerHand;
        public int _playerCardsSum { get; private set; }
        private int _dealerCardsSum;

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
            while (_dealerCardsSum < 17)
            {
                _dealerHand.Draw(_deck);
                _dealerCardsSum = _dealerHand.CalculateValue();
            }
        }

        public void CalculateStartingHandsValue()
        {
            _playerCardsSum = _playerHand.CalculateValue();
            _dealerCardsSum = _dealerHand.CalculateValue();
        }

        public void DrawCard()
        {
            _playerHand.Draw(_deck);
            _playerCardsSum = _playerHand.CalculateValue();
            MyConsole.Write($"Your cards: ");
            _playerHand.Show();
            MyConsole.LineBreak();
        }

        public void End()
        {
            Console.WriteLine($"Dealer has a total of {_dealerCardsSum} with these cards:");
            _dealerHand.Show();
            MyConsole.LineBreak();
            Console.WriteLine($"You have a total of {_playerCardsSum} with these cards:");
            _playerHand.Show();
        }


        public void checkIfWinOrBust()
        {
            if (_playerCardsSum > _dealerCardsSum && _playerCardsSum < 21) { MyConsole.Write("You won!"); }
            else if (_playerCardsSum == 21) { MyConsole.Write("Blackjack, you won!"); }
            else if (_playerCardsSum > 21) { MyConsole.Write("Bust, dealer wins!"); }
            else if (_playerCardsSum > 21) { MyConsole.Write("Dealer Bust, you won!"); }
            else if (_playerCardsSum == _dealerCardsSum) { MyConsole.Write("Draw!"); }
            else if (_dealerCardsSum == 21) { MyConsole.Write("Dealer has Blackjack!, you lose!"); }
            else if (_playerCardsSum < _dealerCardsSum) { MyConsole.Write("You lose!"); }
        }

    }
}
