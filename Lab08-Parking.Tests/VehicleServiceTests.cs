using Lab08_Parking.Common;
using Lab08_Parking.Data.Models;
using Lab08_Parking.Data.Repositories;
using Lab08_Parking.Services;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Lab08_Parking.Tests
{
    public class VehicleServiceTests
    {
        private readonly Mock<IVehicleRepository> mockVehicleRepository;
        private readonly Mock<ITimeCalculator> mockTimeCalculator;
        private readonly IVehicleService vehicleService;

        public VehicleServiceTests()
        {
            mockTimeCalculator = new Mock<ITimeCalculator>();
            mockVehicleRepository = new Mock<IVehicleRepository>();
            vehicleService = new VehicleService(mockVehicleRepository.Object, mockTimeCalculator.Object);
        }
       
        [Fact]
        public void GetCurrentFee_DayPeriod_Size1_WithoutDiscount()
        {
            // Arange
            mockTimeCalculator.Setup(c => c.CalculateTimePeriods(It.IsAny<VehiclePeriodData>())).Returns(new Periods { Period1 = 2, Period2 = 0 });
            mockVehicleRepository.Setup(c => c.GetVehicleByRegNumberAsync(It.IsAny<string>())).Returns(Task.FromResult(
                new Vehicle
                {
                    Size = 1,
                    Parking = new Parking
                    {
                        DailyRate = 3,
                        NightlyRate = 2
                    }
                }));

            // Act
            var actualFee = vehicleService.GetCurrentFeeAsync("1111").Result;

            // Assert
            Assert.Equal(6m, actualFee);
        }

        [Fact]
        public void GetCurrentFee_NightPeriod_Size1_WithoutDiscount()
        {
            // Arange
            mockTimeCalculator.Setup(c => c.CalculateTimePeriods(It.IsAny<VehiclePeriodData>())).Returns(new Periods { Period1 = 0, Period2 = 2 });
            mockVehicleRepository.Setup(c => c.GetVehicleByRegNumberAsync(It.IsAny<string>())).Returns(Task.FromResult(
                new Vehicle
                {
                    Size = 1,
                    Parking = new Parking
                    {
                        DailyRate = 3,
                        NightlyRate = 2
                    }
                }));

            // Act
            var actualFee = vehicleService.GetCurrentFeeAsync("1111").Result;

            // Assert
            Assert.Equal(4m, actualFee);
        }

        [Fact]
        public void GetCurrentFee_DayNightPeriods_Size1_WithoutDiscount()
        {
            // Arange
            mockTimeCalculator.Setup(c => c.CalculateTimePeriods(It.IsAny<VehiclePeriodData>())).Returns(new Periods { Period1 = 1, Period2 = 2 });
            mockVehicleRepository.Setup(c => c.GetVehicleByRegNumberAsync(It.IsAny<string>())).Returns(Task.FromResult(
                new Vehicle
                {
                    Size = 1,
                    Parking = new Parking
                    {
                        DailyRate = 3,
                        NightlyRate = 2
                    }
                }));

            // Act
            var actualFee = vehicleService.GetCurrentFeeAsync("1111").Result;

            // Assert
            Assert.Equal(7m, actualFee);
        }


        [Fact]
        public void GetCurrentFee_DayNightPeriods_Size1_WithDiscount10()
        {
            // Arange
            mockTimeCalculator.Setup(c => c.CalculateTimePeriods(It.IsAny<VehiclePeriodData>())).Returns(new Periods { Period1 = 1, Period2 = 2 });
            mockVehicleRepository.Setup(c => c.GetVehicleByRegNumberAsync(It.IsAny<string>())).Returns(Task.FromResult(
                new Vehicle
                {
                    Size = 1,
                    Parking = new Parking
                    {
                        DailyRate = 3,
                        NightlyRate = 2
                    },
                    DiscountCard = new DiscountCard
                    {
                        Discount = 10
                    }
                }));

            // Act
            var actualFee = vehicleService.GetCurrentFeeAsync("1111").Result;

            // Assert
            Assert.Equal(6.3m, actualFee);
        }

        [Fact]
        public void GetCurrentFee_DayNightPeriods_Size1_WithDiscount15()
        {
            // Arange
            mockTimeCalculator.Setup(c => c.CalculateTimePeriods(It.IsAny<VehiclePeriodData>())).Returns(new Periods { Period1 = 1, Period2 = 2 });
            mockVehicleRepository.Setup(c => c.GetVehicleByRegNumberAsync(It.IsAny<string>())).Returns(Task.FromResult(
                new Vehicle
                {
                    Size = 1,
                    Parking = new Parking
                    {
                        DailyRate = 3,
                        NightlyRate = 2
                    },
                    DiscountCard = new DiscountCard
                    {
                        Discount = 15
                    }
                }));

            // Act
            var actualFee = vehicleService.GetCurrentFeeAsync("1111").Result;

            // Assert
            Assert.Equal(5.95m, actualFee);
        }

        [Fact]
        public void GetCurrentFee_DayNightPeriods_Size1_WithDiscount20()
        {
            // Arange
            mockTimeCalculator.Setup(c => c.CalculateTimePeriods(It.IsAny<VehiclePeriodData>())).Returns(new Periods { Period1 = 1, Period2 = 2 });
            mockVehicleRepository.Setup(c => c.GetVehicleByRegNumberAsync(It.IsAny<string>())).Returns(Task.FromResult(
                new Vehicle
                {
                    Size = 1,
                    Parking = new Parking
                    {
                        DailyRate = 3,
                        NightlyRate = 2
                    },
                    DiscountCard = new DiscountCard
                    {
                        Discount = 20
                    }
                }));

            // Act
            var actualFee = vehicleService.GetCurrentFeeAsync("1111").Result;

            // Assert
            Assert.Equal(5.6m, actualFee);
        }

        [Fact]
        public void GetCurrentFee_DayNightPeriods_Size2_WithDiscount20()
        {
            // Arange
            mockTimeCalculator.Setup(c => c.CalculateTimePeriods(It.IsAny<VehiclePeriodData>())).Returns(new Periods { Period1 = 1, Period2 = 2 });
            mockVehicleRepository.Setup(c => c.GetVehicleByRegNumberAsync(It.IsAny<string>())).Returns(Task.FromResult(
                new Vehicle
                {
                    Size = 2,
                    Parking = new Parking
                    {
                        DailyRate = 3,
                        NightlyRate = 2
                    },
                    DiscountCard = new DiscountCard
                    {
                        Discount = 20
                    }
                }));

            // Act
            var actualFee = vehicleService.GetCurrentFeeAsync("1111").Result;

            // Assert
            Assert.Equal(11.2m, actualFee);
        }

        [Fact]
        public void GetCurrentFee_DayNightPeriods_Size4_WithDiscount20()
        {
            // Arange
            mockTimeCalculator.Setup(c => c.CalculateTimePeriods(It.IsAny<VehiclePeriodData>())).Returns(new Periods { Period1 = 1, Period2 = 2 });
            mockVehicleRepository.Setup(c => c.GetVehicleByRegNumberAsync(It.IsAny<string>())).Returns(Task.FromResult(
                new Vehicle
                {
                    Size = 4,
                    Parking = new Parking
                    {
                        DailyRate = 3,
                        NightlyRate = 2
                    },
                    DiscountCard = new DiscountCard
                    {
                        Discount = 20
                    }
                }));

            // Act
            var actualFee = vehicleService.GetCurrentFeeAsync("1111").Result;

            // Assert
            Assert.Equal(22.4m, actualFee);
        }
    }
}
