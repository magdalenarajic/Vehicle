using DAL.Entities;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;

namespace WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class VehicleModelsController : ApiController
    {
        private readonly IVehicleModelService _vehicleModelService;

        public VehicleModelsController(IVehicleModelService vehicleModelService)
        {
            _vehicleModelService = vehicleModelService;
        }
        // GET: api/VehicleModels
        [HttpGet]
        [Route("VehicleModels")]
        public async Task<IEnumerable<VehicleModelEntity>> GetAll()
        {
            var VehicleModels = await _vehicleModelService.GetAllVehicleModelsAsync();
            return VehicleModels;
        }

        // GET: api/VehicleModels/id
        [ResponseType(typeof(VehicleModelEntity))]
        [Route("VehicleModels/{id}")]
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            var vehicleModel = await _vehicleModelService.GetVehicleModelByIdAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(vehicleModel);
        }


        // PUT: api/VehicleModels/id
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("VehicleModels/{id}")]
        public async Task<IHttpActionResult> PutVehicleModel(int id, VehicleModelEntity vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var updatedVehicleModel = await _vehicleModelService.UpdateVehicleModelAsync(id, vehicleModel);
                return Ok(updatedVehicleModel);
            }
            catch
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        // POST: api/VehicleModels
        [HttpPost]
        [ResponseType(typeof(VehicleModelEntity))]
        [Route("VehicleModels")]
        public async Task<IHttpActionResult> PostVehicleModel(VehicleModelEntity vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newVehicleModel = await _vehicleModelService.CreateVehicleModelAsync(vehicleModel);
            return Ok(newVehicleModel);
        }

        // DELETE: api/VehicleModels/5
        [HttpDelete]
        [Route("VehicleModels/{id}")]
        public async Task<IHttpActionResult> DeleteVehicleModel(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var deletedVehicleModel = await _vehicleModelService.DeleteVehicleModelAsync(id);
            if (deletedVehicleModel == false)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.OK);
        }
    }
}