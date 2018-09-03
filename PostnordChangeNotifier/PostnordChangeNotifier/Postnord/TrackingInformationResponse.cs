using System;
using System.Collections.Generic;
using System.Text;

namespace PostnordChangeNotifier.Postnord
{
    internal class TrackingInformationResponse
    {
        public string EstimatedTimeOfArrival { get; set; }
        public string ServiceName { get; set; }
        public Location Consignor { get; set; }
        public Location Consignee { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
