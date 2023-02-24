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
        Task<IEnumerable<IVehicleMake>> GetAllVehicleMakesAsync();
        Task<bool> CreateVehicleMakeAsync(VehicleMakeEntity vehicleMake);

        Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeEntity vehicleMake);

        Task<bool> DeleteVehicleMakeAsync(int id);
    }
}
