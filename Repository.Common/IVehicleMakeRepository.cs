using Common;
using Model.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IVehicleMakeRepository 
    {
        Task<List<IVehicleMake>> GetOrderByNameAsync();
        Task<List<IVehicleMake>> GetFilterByNameAsync(string search = null);

        Task<PagedList<IVehicleMake>> GetPagedList(QueryParameters queryParameters);
    }
}
