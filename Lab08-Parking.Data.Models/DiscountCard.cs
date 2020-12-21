using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_Parking.Data.Models
{
    public class DiscountCard
    {
        public long Id { get; set; }

        public string Name { get; set; }

        [Range(0,100)]
        public byte Discount { get; set; }

        public long ParkingId { get; set; }

        public virtual Parking Parking { get; set; }

        public virtual IList<Vehicle> Vehicles { get; set; }
    }
}
