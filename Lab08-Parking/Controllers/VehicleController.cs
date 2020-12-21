using AutoMapper;
using Lab08_Parking.Common;
using Lab08_Parking.Data.Models;
using Lab08_Parking.Models;
using Lab08_Parking.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace Lab08_Parking.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleController : ControllerBase
    {
        private readonly ILogger<VehicleController> logger;
        private readonly IVehicleService vehicleService;
        private readonly IParkingService parkingService;
        private readonly IMapper mapper;

        public VehicleController(ILogger<VehicleController> logger, IVehicleService vehicleService, IParkingService parkingService, IMapper mapper)
        {
            this.logger = logger;
            this.vehicleService = vehicleService;
            this.parkingService = parkingService;
            this.mapper = mapper;

            this.logger.LogInformation("Initialized Vehicle Controller");
        }

        [HttpGet("{regNumber}/fee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<decimal>> GetCurrentFee([FromRoute]string regNumber)
        {
            this.logger.LogInformation($"Fetching the fee for a vehicle with registration number = {regNumber}");

            if (string.IsNullOrEmpty(regNumber))
            {
                ModelState.AddModelError("error", "Registraniton number is required!");
                this.logger.LogInformation($"The state is not valid {string.Join(',', ModelState.Values.Select(v => v.Errors))}");
                return BadRequest(ModelState);
            }

            var isValidVehicle = await this.vehicleService.IsValidVehicle(regNumber);
            if (!isValidVehicle)
            {
                this.logger.LogInformation($"A vehicle with registration number = {regNumber} is not found.");
                return NotFound();
            }

            var fee = await this.vehicleService.GetCurrentFeeAsync(regNumber);

            this.logger.LogInformation($"The fee for a vehicle with registration number = {regNumber} is = {fee}");
            return Ok(fee);
        }

        [HttpPost]
        [Consumes(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RegisteredVehicleModel>> Register(RegisterVehicleModel newVehicle)
        {
            this.logger.LogInformation($"Registering a new vehicle = {JsonSerializer.Serialize(newVehicle)}");
            if (ModelState.IsValid)
            {
                var isValidParking = await this.parkingService.IsParkingValid(newVehicle.ParkingId);
                if (!isValidParking)
                {
                    this.logger.LogInformation($"A parking with id = {newVehicle.ParkingId} is not found.");
                    return NotFound();
                }

                var vehicle = this.mapper.Map<Vehicle>(newVehicle);                
                await this.vehicleService.AddVehicleAsync(vehicle);
                var vehicleResult = this.mapper.Map<RegisteredVehicleModel>(vehicle);

                this.logger.LogInformation($"Registered a new vehicle = {JsonSerializer.Serialize(vehicleResult)}");
                return Ok(vehicleResult);
            }

            this.logger.LogInformation($"The state is not valid {string.Join(',', ModelState.Values.Select(v => v.Errors))}");
            return BadRequest(ModelState);
        }

        [HttpDelete("{regNumber}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<decimal>> Exit([FromRoute] string regNumber)
        {
            this.logger.LogInformation($"Deleting a vehicle with number = {regNumber}");
            if (string.IsNullOrEmpty(regNumber))
            {
                ModelState.AddModelError("", "Registraniton number is required!");
                this.logger.LogInformation($"The state is not valid {string.Join(',', ModelState.Values.Select(v => v.Errors))}");
                return BadRequest();
            }

            var isValidVehicle = await this.vehicleService.IsValidVehicle(regNumber);
            if (!isValidVehicle)
            {
                this.logger.LogInformation($"A vehicle with registration number = {regNumber} is not found.");
                return NotFound();
            }

            var fee = await this.vehicleService.GetCurrentFeeAsync(regNumber);
            await this.vehicleService.RemoveVehicleAsync(regNumber);

            this.logger.LogInformation($"Deleted a vehicle with number = {regNumber} and fee {fee}.");
            return Ok(fee);
        }
    }
}
