using System;
using System.Collections.Generic;
using System.Text;

namespace PostnordChangeNotifier.Postnord
{
    internal class Location
    {
        public string City { get; set; }
        public string Country { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            var location = obj as Location;
            if (location == null)
            {
                return false;
            }
            return
                City == location.City &&
                Country == location.Country &&
                Name == location.Name;
        }
    }
}
