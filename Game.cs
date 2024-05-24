namespace Blackjack
{
    internal class Game
    {

        public void checkIfWinOrBust(int playerScore, int dealerScore)
        {
            if (playerScore > dealerScore && playerScore < 21) { Console.WriteLine("You won!"); }
            else if (playerScore == 21) { Console.WriteLine("Blackjack, you won!"); }
            else if (playerScore > 21) { Console.WriteLine("Bust, dealer wins!"); }
            else if (dealerScore > 21) { Console.WriteLine("Dealer Bust, you won!"); }
            else if (playerScore == dealerScore) { Console.WriteLine("Draw!"); }
            else if (dealerScore == 21) { Console.WriteLine("Dealer has Blackjack!, you lose!"); }
            else if (playerScore < dealerScore) { Console.WriteLine("You lose!"); }
        }

    }
}
