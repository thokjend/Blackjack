namespace Blackjack
{
    internal class Program
    { 
        static void Main(string[] args)
        {

            /*
                1. Make main deck
                2. Make player and computer hands
                3. Add cards from main deck to player and computer hands
                4. convert cards to number
                5. Make main game loop (be able to draw a new card from the main deck)
                6. Add blackjack rules
             */

            var game = new Game();
            game.ShowStartingHands();
            game.CalculateStartingHandsValue();
            game.DealerDraw();

            while (game.PlayerCardsSum < 21)
            {
                MyConsole.Write("do you want to draw or stay? (d/s)");
                string action = Console.ReadLine();

                if (action == "d")
                {
                    game.DrawCard();
                }

                if (action == "s")
                {
                    game.End();
                    break;
                }
            }

            MyConsole.LineBreak();
            game.checkIfWinOrBust();
        }

    }
}
