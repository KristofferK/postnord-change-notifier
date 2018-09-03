using PostnordChangeNotifier.Postnord;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace PostnordChangeNotifier
{
    internal class ChangeNotifier
    {
        private readonly IPostNordApi postnord;
        private TrackingInformationResponse lastTrackingInformationResponse;
        public string TrackingId { get; set; }

        public ChangeNotifier(IPostNordApi postnord)
        {
            this.postnord = postnord;
        }

        public void Watch()
        {
            new Thread(() =>
            {
                Console.WriteLine("Watching " + TrackingId);
                var trackingInformation = postnord.GetTrackingInformationSynchronous(TrackingId);
                if (trackingInformation.Equals(lastTrackingInformationResponse))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("["+DateTime.Now.ToShortTimeString()+"] ");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("No changes");
                }
                else
                {
                    lastTrackingInformationResponse = trackingInformation;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("[" + DateTime.Now.ToShortTimeString() + "] ");
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Changed");
                    Console.Beep();
                }
            }).Start();
        }
    }
}
