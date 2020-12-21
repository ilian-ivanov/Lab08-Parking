using Lab08_Parking.Data.Models;
using System.Threading.Tasks;

namespace Lab08_Parking.Data.Repositories
{
    public interface IVehicleRepository
    {
        Task<Vehicle> GetVehicleByRegNumberAsync(string regNumber);

        Task<Vehicle> AddVehicleAsync(Vehicle newVehicle);

        Task RemoveVehicleByRegNumberAsync(string regNumber);
        Task<bool> IsValidVehicle(string regNumber);
    }
}
