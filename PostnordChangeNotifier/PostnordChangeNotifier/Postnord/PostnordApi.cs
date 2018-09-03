using Newtonsoft.Json.Linq;
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
                var shipment = JObject.Parse(source)["response"]["trackingInformationResponse"]["shipments"][0];
                return GenerateTrackingInformationResponseFromJToken(shipment);
            }
        }

        private TrackingInformationResponse GenerateTrackingInformationResponseFromJToken(JToken shipment)
        {
            return new TrackingInformationResponse
            {
                Consignee = GetConsignee(shipment),
                Consignor = GetConsignor(shipment),
                Events = GetEvents(shipment),
                EstimatedTimeOfArrival = (DateTime)shipment["estimatedTimeOfArrival"],
                ServiceName = shipment["service"]["name"].ToString(),
                Status = GetStatus(shipment),
            };
        }

        private Location GetConsignee(JToken shipment)
        {
            return new Location()
            {
                City = shipment["consignee"]["address"]["city"].ToString(),
                Country = shipment["consignee"]["address"]["country"].ToString(),
                Name = shipment["consignee"]["name"]?.ToString()
            };
        }

        private Location GetConsignor(JToken shipment)
        {
            return new Location()
            {
                City = shipment["consignor"]["address"]["city"].ToString(),
                Country = shipment["consignor"]["address"]["country"].ToString(),
                Name = shipment["consignor"]["name"]?.ToString()
            };
        }

        private IEnumerable<Event> GetEvents(JToken shipment)
        {
            var events = new List<Event>();
            foreach (var itemEvent in shipment["items"][0]["events"])
            {
                events.Add(new Event()
                {
                    Description = itemEvent["eventDescription"].ToString(),
                    Location = new Location()
                    {
                        City = itemEvent["location"]["city"].ToString(),
                        Country = itemEvent["location"]["country"].ToString(),
                        Name = itemEvent["location"]["name"].ToString(),
                    },
                    Time = (DateTime)itemEvent["eventTime"]
                });
            }
            return events;
        }

        private Status GetStatus(JToken shipment)
        {
            return new Status()
            {
                Body = shipment["statusText"]["body"].ToString(),
                Header = shipment["statusText"]["header"].ToString(),
                EstimatedTimeOfArrival = shipment["statusText"]["estimatedTimeOfArrival"].ToString()
            };
        }
    }
}
