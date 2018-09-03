using System;
using System.Collections.Generic;
using System.Linq;
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

        public override bool Equals(object obj)
        {
            var response = obj as TrackingInformationResponse;

            if (response == null)
            {
                return false;
            }

            return
                Events.Count() == response.Events.Count() &&
                Consignor.Equals(response.Consignor) &&
                Consignee.Equals(response.Consignee) &&
                Status.Equals(response.Status);
        }
    }
}
