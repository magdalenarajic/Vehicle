using Common;
using DAL.Entities;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVehicleMakeService
    {
        Task<IVehicleMake> GetVehicleMakeByIdAsync(int id);
        Task<List<IVehicleMake>> GetAllVehicleMakesAsync();

        Task<PagedList<IVehicleMake>> GetPagedVehicleMakesAsync(QueryParameters queryParameters);
        Task<bool> CreateVehicleMakeAsync(IVehicleMake vehicleMake);
        Task<bool> UpdateVehicleMakeAsync(int id, IVehicleMake vehicleMake);
        Task<bool> DeleteVehicleMakeAsync(int id);
        Task<List<IVehicleMake>> GetVehicleMakesOrderByNameAsync();
        Task<List<IVehicleMake>> GetVehicleMakesFilterByNameAsync(string search = null);


    }
}
