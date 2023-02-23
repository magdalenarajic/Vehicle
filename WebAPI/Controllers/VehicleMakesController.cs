using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using DAL.Entities;
using Service.Common;

namespace WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class VehicleMakesController : ApiController
    {
        private readonly IVehicleMakeService _vehicleMakeService;

        public VehicleMakesController(IVehicleMakeService vehicleMakeService)
        {
            _vehicleMakeService = vehicleMakeService;
        }

        // GET: api/VehicleMakes
        [HttpGet]
        [Route("VehicleMakes")]
        public async Task<IEnumerable<VehicleMakeEntity>> GetAll()
        {
            var VehicleMakes = await _vehicleMakeService.GetAllVehicleMakesAsync();
            return VehicleMakes;
        }

        // GET: api/VehicleMakes/id
        [ResponseType(typeof(VehicleMakeEntity))]
        [Route("VehicleMakes/{id}")]
        public async Task<IHttpActionResult> GetVehicleMake(int id)
        {
            var vehicleMake = await _vehicleMakeService.GetVehicleMakeByIdAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(vehicleMake);
        }

        // PUT: api/VehicleMakes/id
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("VehicleMakes/{id}")]
        public async Task<IHttpActionResult> PutVehicleMake(int id, VehicleMakeEntity vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedVehicleMake = await _vehicleMakeService.UpdateVehicleMakeAsync(id, vehicleMake);
                return Ok(updatedVehicleMake);
            }
            catch 
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            // return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleMakes
        [HttpPost]
        [ResponseType(typeof(VehicleMakeEntity))]
        [Route("VehicleMakes")]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleMakeEntity vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newVehicleMake = await _vehicleMakeService.CreateVehicleMakeAsync(vehicleMake);
            return Ok(newVehicleMake);
        }

        // DELETE: api/VehicleMakes/5
        [HttpDelete]
        [Route("VehicleMakes/{id}")]
        public async Task<IHttpActionResult> DeleteVehicleMake(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedVehicleMake = await _vehicleMakeService.DeleteVehicleMakeAsync(id);
            if (deletedVehicleMake == false)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.OK);
        }

    }
}