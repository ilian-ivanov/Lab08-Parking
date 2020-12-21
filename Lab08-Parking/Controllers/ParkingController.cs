using Lab08_Parking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Lab08_Parking.Controllers
{
    [Route("api/parking")]
    [ApiController]
    public class ParkingController : ControllerBase
    {
        private readonly ILogger<ParkingController> logger;
        private readonly IParkingService parkingService;

        public ParkingController(ILogger<ParkingController> logger, IConfiguration config, IParkingService parkingService)
        {
            this.logger = logger;
            this.parkingService = parkingService;

            this.logger.LogInformation("Initialized Parking Controller");
        }

        [HttpGet("{parkingId}/freespots/count")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<byte>> GetFreeSpotsCount(long parkingId)
        {
            this.logger.LogInformation($"Calling: GetFreeSpotsCount with parkingId = {parkingId}");

            var isValidParking = await this.parkingService.IsParkingValid(parkingId);
            if (!isValidParking)
            {
                this.logger.LogInformation($"A parking with id = {parkingId} is not found.");
                return NotFound();
            }

            var count = await this.parkingService.GetFreeSpotsCountAsync(parkingId);

            this.logger.LogInformation($"Called: GetFreeSpotsCount and return free spots = {count}");

            return Ok(count);
        }
    }
}
