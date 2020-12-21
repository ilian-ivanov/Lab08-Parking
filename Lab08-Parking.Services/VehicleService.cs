using Lab08_Parking.Common;
using Lab08_Parking.Data.Models;
using Lab08_Parking.Data.Repositories;
using System;
using System.Threading.Tasks;

namespace Lab08_Parking.Services
{
    public class VehicleService : IVehicleService
    {
        private readonly IVehicleRepository vehicleRepository;
        private readonly ITimeCalculator timeCalculator;

        public VehicleService(IVehicleRepository vehicleRepository, ITimeCalculator timeCalculator)
        {
            this.vehicleRepository = vehicleRepository;
            this.timeCalculator = timeCalculator;
        }

        public async Task<decimal> GetCurrentFeeAsync(string regNumber)
        {
            var vehicle = await this.vehicleRepository.GetVehicleByRegNumberAsync(regNumber);
            var parking = vehicle.Parking;

            var periods = this.timeCalculator.CalculateTimePeriods(new VehiclePeriodData
            {
                EntryTime = vehicle.EntryTime,
                ExitTime = DateTime.Now,
                StartHourPeriod = parking.DailyRateStartHour,
                EndHourPeriod = parking.DailyRateStopHour
            });

            var fee = (periods.Period1 * parking.DailyRate + periods.Period2 * parking.NightlyRate) * vehicle.Size;
            if (vehicle.DiscountCard != null && vehicle.DiscountCard.Discount > 0)
            {
                fee = fee - (fee * (vehicle.DiscountCard.Discount/100.0m));
            }

            return fee;
        }

        public async Task<Vehicle> AddVehicleAsync(Vehicle newVehicle)
        {
            newVehicle.EntryTime = DateTime.Now;

            await this.vehicleRepository.AddVehicleAsync(newVehicle);

            return newVehicle;
        }

        public async Task RemoveVehicleAsync(string regNumber)
        {
            await this.vehicleRepository.RemoveVehicleByRegNumberAsync(regNumber);
        }

        public async Task<bool> IsValidVehicle(string regNumber)
        {
            return await this.vehicleRepository.IsValidVehicle(regNumber);
        }
    }
}
