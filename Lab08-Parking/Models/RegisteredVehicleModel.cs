using Lab08_Parking.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08_Parking.Models
{
    public class RegisteredVehicleModel
    {
        public long Id { get; set; }

        public string RegNumber { get; set; }

        public long ParkingId { get; set; }

        public Size Size { get; set; }

        public long? DiscountCardId { get; set; }

        public DateTime EntryTime { get; set; }
    }
}
