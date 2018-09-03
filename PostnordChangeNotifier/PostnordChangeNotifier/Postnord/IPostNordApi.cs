using System;
using System.Collections.Generic;
using System.Text;

namespace PostnordChangeNotifier.Postnord
{
    internal interface IPostNordApi
    {
        TrackingInformationResponse GetTrackingInformationSynchronous(string trackingId);
    }
}
