using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab08_Parking.Data.Repositories
{
    public abstract class BaseRepository
    {
        protected readonly ParkingContext context;

        public BaseRepository(ParkingContext context)
        {
            this.context = context;
        }
    }
}
