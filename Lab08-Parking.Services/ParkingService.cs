using System;
using System.Threading.Tasks;
using System.Linq;
using Lab08_Parking.Data.Repositories;

namespace Lab08_Parking.Services
{
    public class ParkingService : IParkingService
    {
        private readonly IParkingRepository parkingRepository;

        public ParkingService(IParkingRepository parkingRepository)
        {
            this.parkingRepository = parkingRepository;
        }

        public async Task<byte> GetFreeSpotsCountAsync(long parkingId)
        {
            var parking = await this.parkingRepository.GetParkingAsync(parkingId);
            byte freeSpots = Convert.ToByte(parking.Size - parking.Vehicles.Sum(v => v.Size));

            return freeSpots;
        }

        public async Task<bool> IsParkingValid(long parkingId)
        {
            return await this.parkingRepository.IsValidParking(parkingId);
        }
    }
}
