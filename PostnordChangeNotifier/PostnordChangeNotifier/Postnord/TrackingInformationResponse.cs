using System;
using System.Collections.Generic;
using System.Text;

namespace PostnordChangeNotifier.Postnord
{
    internal class TrackingInformationResponse
    {
        public DateTime EstimatedTimeOfArrival { get; set; }
        public string ServiceName { get; set; }
        public Location Consignor { get; set; }
        public Location Consignee { get; set; }
        public Status Status { get; set; }
        public IEnumerable<Event> Events { get; set; }
    }
}
