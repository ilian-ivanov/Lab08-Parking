﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_Parking.Services
{
    public interface IParkingService
    {
        Task<byte> GetFreeSpotsCountAsync(long parkingId);
        Task<bool> IsParkingValid(long parkingId);
    }
}
