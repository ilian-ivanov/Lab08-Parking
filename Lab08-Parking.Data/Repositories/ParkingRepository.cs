using Lab08_Parking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Lab08_Parking.Data.Repositories
{
    public class ParkingRepository : BaseRepository, IParkingRepository
    {
        public ParkingRepository(ParkingContext context) : base(context)
        {
        }

        public async Task<Parking> GetParkingAsync(long parkingId)
        {
            return await context.Parkings.Include(p => p.Vehicles).FirstOrDefaultAsync(p => p.Id == parkingId);
        }

        public async Task<bool> IsValidParking(long parkingId)
        {
            return await this.context.Parkings.FindAsync(parkingId) != null;
        }
    }
}
 