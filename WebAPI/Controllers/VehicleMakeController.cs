using Model;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace WebAPI.Controllers
{
    public class VehicleMakeController : ApiController
    {
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }
        public async Task<IEnumerable<VehicleMake>> GetVehicleMakesAsync()
            {
            return await _vehicleMakeService.GetAllVehicleMake();
            }
    }
}
