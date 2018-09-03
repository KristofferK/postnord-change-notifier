using System;
using System.Collections.Generic;
using System.Text;

namespace PostnordChangeNotifier.Postnord
{
    internal class Event
    {
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }

        public override string ToString()
        {
            return $"{Time.ToLongDateString()} @ {Location}: {Description}";
        }
    }
}
