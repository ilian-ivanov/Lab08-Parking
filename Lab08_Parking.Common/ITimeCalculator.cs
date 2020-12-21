using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_Parking.Common
{
    public interface ITimeCalculator
    {
        Periods CalculateTimePeriods(VehiclePeriodData data);
    }
}
