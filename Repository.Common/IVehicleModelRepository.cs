using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVehicleModelRepository 
    {
        Task<List<IVehicleModel>> GetOrderByNameAsync();
        Task<List<IVehicleModel>> GetFilterByNameAsync(string search = null);
    }
}
