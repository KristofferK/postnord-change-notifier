using PostnordChangeNotifier.Postnord;
using System;
using System.Text.RegularExpressions;
using System.Threading;

namespace PostnordChangeNotifier
{
    class Program
    {
        static void Main(string[] args)
        {
            var trackingId = GetTrackingIdFromUser();
            var notifier = new ChangeNotifier(new PostnordApi())
            {
                TrackingId = trackingId
            };
            notifier.Watch(5);
            
            while (Console.ReadLine() != ":q")
            {
                Console.WriteLine("Type :q to exit");
            }
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
