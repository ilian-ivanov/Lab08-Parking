using Lab08_Parking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Lab08_Parking.Data.Repositories
{
    public class VehicleRepository : BaseRepository, IVehicleRepository
    {
        public VehicleRepository(ParkingContext context) : base(context)
        {
        }

        public async Task<Vehicle> AddVehicleAsync(Vehicle newVehicle)
        {
            newVehicle.DiscountCardId = this.context.DiscountCards.Find(newVehicle.DiscountCardId)?.Id;            
            await this.context.Vehicles.AddAsync(newVehicle);
            await this.context.SaveChangesAsync();

            return newVehicle;
        }

        public async Task<Vehicle> GetVehicleByRegNumberAsync(string regNumber)
        {
            return await this.context.Vehicles.Include(v => v.Parking).Include(v => v.DiscountCard).Where(v => v.RegNumber == regNumber).SingleOrDefaultAsync();
        }

        public async Task<bool> IsValidVehicle(string regNumber)
        {
            var count = await this.context.Vehicles.Where(v => v.RegNumber == regNumber).CountAsync();
            return count > 0 ? true : false;
        }

        public async Task RemoveVehicleByRegNumberAsync(string regNumber)
        {
            var vehicle = await context.Vehicles.SingleOrDefaultAsync(v => v.RegNumber == regNumber);
            context.Vehicles.Remove(vehicle);
            await context.SaveChangesAsync();
        }
    }
}
