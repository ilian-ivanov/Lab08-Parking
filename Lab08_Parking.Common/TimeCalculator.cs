using System;

namespace Lab08_Parking.Common
{
    public class TimeCalculator: ITimeCalculator 
    {
        public Periods CalculateTimePeriods(VehiclePeriodData data)
        {
            var startPeriod1 = data.StartHourPeriod;
            var startPeriod2 = data.EndHourPeriod;
            var start = data.EntryTime;
            var end = data.ExitTime;
            var period1hours = 0;
            var period2hours = 0;

            while (start < end)
            {
                start = start.AddHours(1);
                if(start.Hour > startPeriod1 && start.Hour <= startPeriod2)
                {
                    period1hours += 1;
                }
                else
                {
                    period2hours += 1;
                }
            }

            return new Periods { Period1 = period1hours, Period2 = period2hours };
        }
    }
}
