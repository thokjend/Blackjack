using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualBasic.CompilerServices;

namespace Blackjack
{
    internal class Program
    {
        static readonly Random Random = new Random();
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

            List<string> deck = makeDeck();
            List<string> dealerCards = dealStartingCards(deck);
            List<string> playerCards = dealStartingCards(deck);

            Console.WriteLine($"Dealer cards: X, {dealerCards[1]}");
            Console.WriteLine($"Your cards: ");

            showCards(playerCards);
            Console.WriteLine("");

            int playerSum = CalculateHandValue(playerCards);
            int dealerSum = CalculateHandValue(dealerCards);

            while (dealerSum < 17)
            {
                dealerSum = dealCard(dealerCards, deck);
            }

            while (playerSum < 21)
            {
                Console.WriteLine("do you want to draw or stay? (d/s)");

                string action = Console.ReadLine();
                if (action == "d")
                {
                    playerSum = dealCard(playerCards, deck);
                    Console.WriteLine($"Your cards: ");
                    showCards(playerCards);
                    Console.WriteLine("");
                }

                if (action == "s")
                {
                    Console.WriteLine($"Dealer has a total of {dealerSum} with these cards:");
                    showCards(dealerCards);
                    Console.WriteLine("");
                    Console.WriteLine($"You have a total of {playerSum} with these cards:");
                    showCards(playerCards);
                    break;
                }
            }

            Console.WriteLine("");
            checkIfWinOrBust(playerSum, dealerSum);
        }

        static void checkIfWinOrBust(int playerScore, int dealerScore)
        {
            if (playerScore > dealerScore && playerScore < 21) { Console.WriteLine("You won!"); }
            else if (dealerScore > 21) { Console.WriteLine("Dealer Bust, you won!");}
            else if (playerScore > 21) { Console.WriteLine("Bust, dealer wins!"); }
            else if (playerScore == dealerScore) { Console.WriteLine("Draw!"); }
            else if (dealerScore == 21) { Console.WriteLine("Dealer has Blackjack!, you lose!"); }
            else if (playerScore < dealerScore && playerScore < 21) { Console.WriteLine("You lose!");}
            else if (playerScore == 21) { Console.WriteLine("Blackjack, you won!");}
            
        }

        static int dealCard(List<string> cards, List<string> deck)
        {
            int sum = 0;
            cards.Add(deck[deck.Count - 1]);
            deck.Remove(deck[deck.Count - 1]);
            sum = CalculateHandValue(cards);

            return sum;
        }

        static void showCards(List<string> hand)
        {
            foreach (var card in hand)
            {
                Console.WriteLine($"[{card}] ");
            }
        }

        static int CalculateHandValue(List<string> hand)
        {
            int sum = 0;
            int numAces = 0;

            foreach (var card in hand)
            {
                string[] cardValue = card.Split("of");
                string cardName = cardValue[0].Trim();
                if (Enum.TryParse<cardValues>(cardName, out cardValues value))
                {
                    if (value == cardValues.Ace)
                    {
                        numAces++;
                    }
                    else
                    {
                        sum += (int)value;
                    }
                }
            }

            for (int i = 0; i < numAces; i++)
            {
                if (sum + 11 <= 21)
                {
                    sum += 11; // Add 11 if it keeps the total below or equal to 21
                }
                else
                {
                    sum += 1; // Otherwise, add 1
                }
            }

            return sum;
        }

        static List<string> dealStartingCards(List<string> deck)
        {
            List<string> cards = new List<string>();
            while (cards.Count < 2)
            {
                cards.Add(deck[deck.Count - 1]);
                deck.Remove(deck[deck.Count - 1]);
            }

            return cards;
        }


        static List<string> makeDeck()
        {
            List<string> deck = new List<string>();
            List<string> suits = new List<string> { "Spades", "Hearts", "Diamonds", "Clubs" };

            foreach (var suit in suits)
            {
                foreach (var card in Enum.GetNames(typeof(cardValues)))
                {
                    deck.Add($"{card} of {suit}");
                }
            }

            List<string> shuffledDeck = deck.OrderBy(x => Random.Next()).ToList();

            return shuffledDeck;
        }

    }
}
