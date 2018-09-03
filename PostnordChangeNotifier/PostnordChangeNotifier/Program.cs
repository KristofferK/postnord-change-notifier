using System;
using System.Text.RegularExpressions;

namespace PostnordChangeNotifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var trackingId = GetTrackingIdFromUser();
            Console.WriteLine("Good");
        }

        private static string GetTrackingIdFromUser()
        {
            Console.Title = "Please enter tracking ID";
            string input = "";
            while (!Regex.IsMatch(input, "^[0-9]{10,20}$"))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("Please enter tracking ID: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                input = Console.ReadLine();
                Console.Clear();
            }
            Console.ForegroundColor = ConsoleColor.White;
            return input;
        }
    }
}
