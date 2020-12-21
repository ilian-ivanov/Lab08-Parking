using Lab08_Parking.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_Parking.Data.Repositories
{
    public interface IParkingRepository
    {
        Task<Parking> GetParkingAsync(long parkingId);
        Task<bool> IsValidParking(long parkingId);
    }
}
