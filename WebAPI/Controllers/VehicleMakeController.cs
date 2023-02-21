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
    [RoutePrefix("api/vehiclemake")]
    public class VehicleMakeController : ApiController
    {
        private readonly IVehicleMakeService _vehicleMakeService;

        
        public VehicleMakeController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        // GET api/values
        [HttpGet]
        [Route("makes")]
        public async Task<IEnumerable<VehicleMake>> GetAsync()
        {
            return await _vehicleMakeService.GetAllVehicleMakesAsync();
        }

       




    }
}
