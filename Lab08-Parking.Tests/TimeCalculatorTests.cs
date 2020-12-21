using Lab08_Parking.Common;
using System;
using Xunit;

namespace Lab08_Parking.Tests
{
    public class TimeCalculatorTests
    {
        private readonly ITimeCalculator timeCalculator;

        public TimeCalculatorTests()
        {
            timeCalculator = new TimeCalculator();
        }

        [Fact]
        public void CalculateTimePerios_OnlyDayPeriod()
        {
            // Arrange
            var vehiclePeriodData = new VehiclePeriodData
            {
                StartHourPeriod = 8,
                EndHourPeriod = 18,
                EntryTime = new DateTime(2020, 12, 20, 10, 5, 30),
                ExitTime = new DateTime(2020, 12, 20, 12, 1, 20)
            };

            // Act
            var timePeriodsActual = timeCalculator.CalculateTimePeriods(vehiclePeriodData);
            var totalHoursActual = (vehiclePeriodData.ExitTime - vehiclePeriodData.EntryTime).TotalHours;
            var totalHoursPaidActual = timePeriodsActual.Period1 + timePeriodsActual.Period2;

            // Assert
            Assert.Equal(2, timePeriodsActual.Period1);
            Assert.Equal(0, timePeriodsActual.Period2);
            Assert.True(totalHoursPaidActual - 1 < totalHoursActual && totalHoursActual < totalHoursPaidActual);
        }

        [Fact]
        public void CalculateTimePerios_OnlyNightPeriod()
        {
            // Arrange
            var vehiclePeriodData = new VehiclePeriodData
            {
                StartHourPeriod = 8,
                EndHourPeriod = 18,
                EntryTime = new DateTime(2020, 12, 20, 18, 5, 30),
                ExitTime = new DateTime(2020, 12, 20, 20, 1, 20)
            };

            // Act
            var timePeriodsActual = timeCalculator.CalculateTimePeriods(vehiclePeriodData);
            var totalHoursActual = (vehiclePeriodData.ExitTime - vehiclePeriodData.EntryTime).TotalHours;
            var totalHoursPaidActual = timePeriodsActual.Period1 + timePeriodsActual.Period2;

            // Assert
            Assert.Equal(0, timePeriodsActual.Period1);
            Assert.Equal(2, timePeriodsActual.Period2);
            Assert.True(totalHoursPaidActual - 1 < totalHoursActual && totalHoursActual < totalHoursPaidActual);
        }

        [Fact]
        public void CalculateTimePerios_DayNightPeriod()
        {
            // Arrange
            var vehiclePeriodData = new VehiclePeriodData
            {
                StartHourPeriod = 8,
                EndHourPeriod = 18,
                EntryTime = new DateTime(2020, 12, 20, 16, 5, 30),
                ExitTime = new DateTime(2020, 12, 20, 21, 1, 20)
            };

            // Act
            var timePeriodsActual = timeCalculator.CalculateTimePeriods(vehiclePeriodData);
            var totalHoursActual = (vehiclePeriodData.ExitTime - vehiclePeriodData.EntryTime).TotalHours;
            var totalHoursPaidActual = timePeriodsActual.Period1 + timePeriodsActual.Period2;

            // Assert
            Assert.Equal(2, timePeriodsActual.Period1);
            Assert.Equal(3, timePeriodsActual.Period2);
            Assert.True(totalHoursPaidActual - 1 < totalHoursActual && totalHoursActual < totalHoursPaidActual);
        }


        [Fact]
        public void CalculateTimePerios_DayNightDayPeriod()
        {
            // Arrange
            var vehiclePeriodData = new VehiclePeriodData
            {
                StartHourPeriod = 8,
                EndHourPeriod = 18,
                EntryTime = new DateTime(2020, 12, 20, 16, 5, 30),
                ExitTime = new DateTime(2020, 12, 21, 10, 1, 20)
            };

            // Act
            var timePeriodsActual = timeCalculator.CalculateTimePeriods(vehiclePeriodData);
            var totalHoursActual = (vehiclePeriodData.ExitTime - vehiclePeriodData.EntryTime).TotalHours;
            var totalHoursPaidActual = timePeriodsActual.Period1 + timePeriodsActual.Period2;

            // Assert
            Assert.Equal(4, timePeriodsActual.Period1);
            Assert.Equal(14, timePeriodsActual.Period2);
            Assert.True(totalHoursPaidActual - 1 < totalHoursActual && totalHoursActual < totalHoursPaidActual);
        }
    }
}
