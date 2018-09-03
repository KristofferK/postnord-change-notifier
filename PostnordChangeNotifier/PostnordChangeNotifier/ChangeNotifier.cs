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

        public void Watch(int checkFrequency)
        {
            new Thread(() =>
            {
                Console.WriteLine("Watching " + TrackingId);
                Console.Title = "Watching " + TrackingId;
                while (true)
                {
                    var trackingInformation = postnord.GetTrackingInformationSynchronous(TrackingId);
                    if (trackingInformation.Equals(lastTrackingInformationResponse))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[" + DateTime.Now.ToLongTimeString() + "] ");
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.WriteLine("No changes");
                        Console.Title = "Parcel from " + trackingInformation.Consignor.Name;
                    }
                    else
                    {
                        lastTrackingInformationResponse = trackingInformation;
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("[" + DateTime.Now.ToLongTimeString() + "] ");
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("Changed");
                        Console.Title = "(CHANGED) Parcel from " + trackingInformation.Consignor.Name;
                        Console.Beep();
                    }
                    Thread.Sleep(checkFrequency * 60 * 1000);
                }
            })
            {
                IsBackground = true
            }.Start();
        }
    }
}
