using PostnordChangeNotifier.Postnord;
using System;
using System.Collections.Generic;
using System.Text;

namespace PostnordChangeNotifier
{
    internal class ChangeNotifier
    {
        private readonly IPostNordApi postnord;
        public string TrackingId { get; set; }

        public ChangeNotifier(IPostNordApi postnord)
        {
            this.postnord = postnord;
        }

        public void Watch()
        {
            Console.WriteLine("Watching " + TrackingId);
        }
    }
}
