using Common;
using Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVehicleModelRepository 
    {
        Task<List<IVehicleModel>> GetOrderByNameAsync();
        Task<List<IVehicleModel>> GetFilterByNameAsync(string search = null);

        Task<PagedList<IVehicleModel>> GetPagedList(QueryParameters queryParameters);
    }
}
