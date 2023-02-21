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
        Task<VehicleMake> GetVehicleMakeByIdAsync(int id);
        Task<IEnumerable<VehicleMake>> GetAllVehicleMakesAsync();
        Task<bool> CreateVehicleMakeAsync(VehicleMake entity);

        Task<bool> UpdateVehicleMakeAsync(VehicleMake vehicleMake);

        Task<bool> DeleteVehicleMakeAsync(int id);
    }
}
