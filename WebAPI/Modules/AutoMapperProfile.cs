using AutoMapper;
using DAL.Entities;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.Modules
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<VehicleMakeEntity, VehicleMake>().ReverseMap();
            CreateMap<VehicleMakeEntity, IVehicleMake>().ReverseMap();
            CreateMap<IVehicleMake, VehicleMake>().ReverseMap();

            CreateMap<VehicleModelEntity, VehicleModel>().ReverseMap();
            CreateMap<VehicleModelEntity, IVehicleModel>().ReverseMap();
            CreateMap<IVehicleModel, VehicleModel>().ReverseMap();

        }
    }
}