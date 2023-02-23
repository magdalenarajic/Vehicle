using DAL.Entities;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Common
{
    public interface IVehicleMakeService
    {
        Task<VehicleMakeEntity> GetVehicleMakeByIdAsync(int id);
        Task<IEnumerable<VehicleMakeEntity>> GetAllVehicleMakesAsync();
        Task<bool> CreateVehicleMakeAsync(VehicleMakeEntity entity);

        Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeEntity vehicleMake);

        Task<bool> DeleteVehicleMakeAsync(int id);
    }
}
