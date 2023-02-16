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
        Task<VehicleMake> GetVehicleMakeByIdAsync(Guid id);
        Task<IEnumerable<VehicleMake>> GetAllVehicleMakesAsync();
        Task<bool> AddVehicleMakeAsync(VehicleMake entity);
    }
}
