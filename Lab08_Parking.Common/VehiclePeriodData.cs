using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_Parking.Common
{
    public class VehiclePeriodData
    {
        public int StartHourPeriod { get; set; }

        public int EndHourPeriod { get; set; }

        public DateTime EntryTime { get; set; }

        public DateTime ExitTime { get; set; }

    }
}
