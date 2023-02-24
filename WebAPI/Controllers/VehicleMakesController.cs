using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using AutoMapper;
using DAL.Entities;
using Model;
using Model.Common;
using Service.Common;

namespace WebAPI.Controllers
{
    [RoutePrefix("api")]
    public class VehicleMakesController : ApiController
    {
        private readonly IVehicleMakeService _vehicleMakeService;
        private readonly IMapper _mapper;

        public VehicleMakesController(IVehicleMakeService vehicleMakeService, IMapper mapper)
        {
            _vehicleMakeService = vehicleMakeService;
            _mapper = mapper;

        }

        // GET: api/VehicleMakes
        [HttpGet]
        [Route("VehicleMakes")]
        public async Task<List<IVehicleMake>> GetAll()
        {
            var vehicleMakes = await _vehicleMakeService.GetAllVehicleMakesAsync();
            return vehicleMakes;
        }

        // GET: api/VehicleMakes/id
        [ResponseType(typeof(IVehicleMake))]
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
        public async Task<IHttpActionResult> PutVehicleMake(int id, VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var vehicleMakeEntity = _mapper.Map<VehicleMakeEntity>(vehicleMake);
                var updatedVehicleMake = await _vehicleMakeService.UpdateVehicleMakeAsync(id, vehicleMakeEntity);
                return Ok(updatedVehicleMake);
            }
            catch 
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }

            
        }

        // POST: api/VehicleMakes
        [HttpPost]
        [ResponseType(typeof(VehicleMakeEntity))]
        [Route("VehicleMakes")]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleMake vehicleMake)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vehicleMakeEntity = _mapper.Map<VehicleMakeEntity>(vehicleMake);
            var newVehicleMake = await _vehicleMakeService.CreateVehicleMakeAsync(vehicleMakeEntity);
            return Ok(newVehicleMake);
        }

        // DELETE: api/VehicleMakes/id
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

        [HttpGet]
        [Route("VehicleMakesOrderBy")]
        public async Task<List<IVehicleMake>> GetVehicleMakesOrderByName() 
        {
            var vehicleMakes = await _vehicleMakeService.GetVehicleMakesOrderByNameAsync();
            return vehicleMakes;
        }
        [HttpGet]
        [Route("VehicleMakesFilterBy")]
        public async Task<List<IVehicleMake>> GetVehicleMakesFilterByName(string name)
        {
            var vehicleMakes = await _vehicleMakeService.GetVehicleMakesFilterByNameAsync(name);
            return vehicleMakes;
        }


    }
}