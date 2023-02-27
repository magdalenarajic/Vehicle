using Common;
using DAL.Entities;
using Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVehicleModelService
    {
        Task<IVehicleModel> GetVehicleModelByIdAsync(int id);
        Task<List<IVehicleModel>> GetAllVehicleModelsAsync();

        Task<PagedList<IVehicleModel>> GetPagedVehicleModelsAsync(QueryParameters queryParameters);
        Task<bool> CreateVehicleModelAsync(IVehicleModel vehicleModel);
        Task<bool> UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel);
        Task<bool> DeleteVehicleModelAsync(int id);
        Task<List<IVehicleModel>> GetVehicleModelsOrderByNameAsync();
        Task<List<IVehicleModel>> GetVehicleModelsFilterByNameAsync(string search = null);
    }
}
