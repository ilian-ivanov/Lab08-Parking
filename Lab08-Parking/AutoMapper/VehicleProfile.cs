using AutoMapper;
using Lab08_Parking.Common;
using Lab08_Parking.Data.Models;
using Lab08_Parking.Models;

namespace Lab08_Parking.AutoMapper
{
    public class VehicleProfile: Profile
    {
        public VehicleProfile()
        {
            CreateMap<RegisterVehicleModel, Vehicle>()
                .ForMember(dest => dest.Size,
                    opt => opt.MapFrom(src => (byte)src.Size));

            CreateMap<Vehicle, RegisteredVehicleModel>()
                .ForMember(dest => dest.Size,
                    opt => opt.MapFrom(src => (Size)src.Size));
        }
    }
}
