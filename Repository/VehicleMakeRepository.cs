using DAL;
using Microsoft.Extensions.Logging;
using Model;
using Model.Common;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class VehicleMakeRepository : GenericRepository<IVehicleMake>, IVehicleMakeRepository
    {
        public VehicleMakeRepository(VehicleContext context) : base(context)
        {

        }
      

    }
}
