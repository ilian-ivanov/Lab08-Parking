using Lab08_Parking.Common;
using Lab08_Parking.Data.Models;
using System.Threading.Tasks;

namespace Lab08_Parking.Services
{
    public interface IVehicleService
    {
        Task<decimal> GetCurrentFeeAsync(string regNumber);
        Task<Vehicle> AddVehicleAsync(Vehicle newVehicle);
        Task RemoveVehicleAsync(string regNumber);
        Task<bool> IsValidVehicle(string regNumber);
    }
}
