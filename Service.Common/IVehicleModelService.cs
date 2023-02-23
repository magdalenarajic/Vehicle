using DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVehicleModelService
    {
        Task<VehicleModelEntity> GetVehicleModelByIdAsync(int id);
        Task<IEnumerable<VehicleModelEntity>> GetAllVehicleModelsAsync();
        Task<bool> CreateVehicleModelAsync(VehicleModelEntity entity);

        Task<bool> UpdateVehicleModelAsync(int id, VehicleModelEntity vehicleModel);

        Task<bool> DeleteVehicleModelAsync(int id);
    }
}
