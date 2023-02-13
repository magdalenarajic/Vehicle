using DAL;
using Model;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VehicleMakeRepository : GenericRepository<VehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(VehicleContext context): base(context)
        {

        }
        public override IEnumerable<VehicleMake> GetAll()
        {
            return _dbContext.Set<VehicleMake>().AsEnumerable();
        }

    }
}
