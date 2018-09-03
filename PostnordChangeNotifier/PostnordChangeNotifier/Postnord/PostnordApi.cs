using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace PostnordChangeNotifier.Postnord
{
    internal class PostnordApi : IPostNordApi
    {
        public TrackingInformationResponse GetTrackingInformationSynchronous(string trackingId)
        {
            using (WebClient webClient = new WebClient())
            {
                var source = webClient.DownloadString("https://www.postnord.dk/api/shipment/" + trackingId + "/da");
                Console.WriteLine(source);

                return new TrackingInformationResponse();
            }
        }
    }
}
