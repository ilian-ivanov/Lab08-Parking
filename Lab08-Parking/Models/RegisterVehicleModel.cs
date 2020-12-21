using Lab08_Parking.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08_Parking.Models
{
    public class RegisterVehicleModel
    {
        [Required]
        public string RegNumber { get; set; }

        [Required]
        [Range(1, long.MaxValue)]
        public long ParkingId { get; set; }

        [Required]
        [RegularExpression("^(CategoryA|CategoryB|CategoryC)$", ErrorMessage = "The size should be 1 (CategoryA), 2 (CategoryB) or 4 (CategoryC)")]
        public Size Size { get; set; }

        public long? DiscountCardId { get; set; }
    }
}
