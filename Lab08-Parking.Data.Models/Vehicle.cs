using Lab08_Parking.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace Lab08_Parking.Data.Models
{
    public class Vehicle
    {
        public long Id { get; set; }

        public string RegNumber { get; set; }

        public byte Size { get; set; }

        public DateTime EntryTime { get; set; }

        public long? DiscountCardId { get; set; }

        public virtual DiscountCard DiscountCard { get; set; }

        public long ParkingId { get; set; }

        public virtual Parking Parking { get; set; }
    }
}
