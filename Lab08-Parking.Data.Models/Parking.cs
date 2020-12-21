using System;
using System.Collections.Generic;
using System.Text;
using Lab08_Parking.Common;

namespace Lab08_Parking.Data.Models
{
    public class Parking
    {
        public long Id { get; set; }

        public byte Size { get; set; }

        public decimal DailyRate { get; set; }

        public decimal NightlyRate { get; set; }

        public byte DailyRateStartHour { get; set; }

        public byte DailyRateStopHour { get; set; }

        public virtual IList<Vehicle> Vehicles { get; set; }

        public virtual IList<DiscountCard> DiscountCards { get; set; }
    }
}
