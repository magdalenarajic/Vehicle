using DAL.Entities;
using Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModel> GetVehicleModelByIdAsync(int id);
        Task<IEnumerable<IVehicleModel>> GetAllVehicleModelsAsync();
        Task<bool> CreateVehicleModelAsync(VehicleModelEntity entity);

        Task<bool> UpdateVehicleModelAsync(int id, VehicleModelEntity vehicleModel);

        Task<bool> DeleteVehicleModelAsync(int id);
    }
}
