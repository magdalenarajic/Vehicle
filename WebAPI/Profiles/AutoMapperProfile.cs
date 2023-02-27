using AutoMapper;
using DAL.Entities;
using Model;
using Model.Common;
using WebAPI.RESTModels;

namespace WebAPI.Modules
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeRest, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeRest, IVehicleMake>().ReverseMap();

            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelRest, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelRest, IVehicleModel>().ReverseMap();

        }
    }
}