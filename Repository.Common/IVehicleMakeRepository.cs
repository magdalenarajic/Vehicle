using Common;
using DAL.Entities;
using Model;
using Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVehicleMakeRepository 
    {
        Task<List<IVehicleMake>> GetOrderByNameAsync();
        Task<List<IVehicleMake>> GetFilterByNameAsync(string search = null);

        Task<PagedList<VehicleMakeEntity>> GetPaged(QueryParameters queryParameters);
    }
}
