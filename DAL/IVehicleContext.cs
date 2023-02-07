using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IVehicleContext
    {
        DbSet<VehicleModelEntity> VehicleModels { get; set; }
        DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
    }
}
