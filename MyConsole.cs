namespace Blackjack
{
    internal class MyConsole
    {
        public static void WriteDealerCards(string message, Card hand)
        {
            Console.WriteLine(message + " " + hand);
        }

        public static void Write(string message)
        {
            Console.WriteLine(message);
        }

        public static void LineBreak(string message = "")
        {
            Console.WriteLine(message);
        }
    }
}
