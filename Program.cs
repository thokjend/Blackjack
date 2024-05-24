using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic.CompilerServices;

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
            var deck = new Deck();
            var drawStartingCards = new Hand(deck.DrawStartingHand());
            var dealerHand = drawStartingCards;
            var playerHand = drawStartingCards;

            Console.WriteLine($"Dealer cards: X, {dealerHand.GetHand()[1]}");
            Console.WriteLine($"Your cards: ");
            playerHand.Show();
            Console.WriteLine("");

            int playerCardsSum = playerHand.CalculateValue();
            int dealerCardsSum = dealerHand.CalculateValue();

            while (dealerCardsSum < 17) 
            {
                dealerHand.Draw(deck);
                dealerCardsSum = dealerHand.CalculateValue();
            }

            while (playerCardsSum < 21)
            {
                Console.WriteLine("do you want to draw or stay? (d/s)");

                string action = Console.ReadLine();
                if (action == "d")
                {
                    playerHand.Draw(deck);
                    playerCardsSum = playerHand.CalculateValue();
                    Console.WriteLine($"Your cards: ");
                    playerHand.Show();
                    Console.WriteLine("");
                }

                if (action == "s")
                {
                    Console.WriteLine($"Dealer has a total of {dealerCardsSum} with these cards:");
                    dealerHand.Show();
                    Console.WriteLine("");
                    Console.WriteLine($"You have a total of {playerCardsSum} with these cards:");
                    playerHand.Show();
                    break;
                }
            }

            Console.WriteLine("");
            game.checkIfWinOrBust(playerCardsSum, dealerCardsSum);
        }

    }
}
