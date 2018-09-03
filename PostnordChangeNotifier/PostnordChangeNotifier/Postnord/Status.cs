using System;
using System.Collections.Generic;
using System.Text;

namespace PostnordChangeNotifier.Postnord
{
    internal class Status
    {
        public string Header { get; set; }
        public string Body { get; set; }
        public string EstimatedTimeOfArrival { get; set; }

        public override string ToString()
        {
            return Header;
        }

        public override bool Equals(object obj)
        {
            var status = obj as Status;
            if (status == null)
            {
                return false;
            }

            return
                Header == status.Header &&
                Body == status.Body &&
                EstimatedTimeOfArrival == status.EstimatedTimeOfArrival;
        }
    }
}
