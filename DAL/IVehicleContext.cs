using System.Data.Entity;
using Model;

namespace DAL
{
    public interface IVehicleContext
    {
        DbSet<VehicleModel> VehicleModels { get; set; }
        DbSet<VehicleMake> VehicleMakes { get; set; }
    }
}
