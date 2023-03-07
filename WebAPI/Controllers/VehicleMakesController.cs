using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AutoMapper;
using Common;
using Model.Common;
using Newtonsoft.Json;
using Service.Common;
using WebAPI.RESTModels;

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
        [ResponseType(typeof(VehicleMakeRest))]
        [Route("VehicleMakes")]

        public async Task<IHttpActionResult> GetAll()
        {
            var vehicleMakes = await _vehicleMakeService.GetAllVehicleMakesAsync();
            if (vehicleMakes == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<VehicleMakeRest>>(vehicleMakes));
        }

        // GET: api/VehicleMakes/id
        [ResponseType(typeof(VehicleMakeRest))]
        [Route("VehicleMakes/{id}")]
        public async Task<IHttpActionResult> GetVehicleMake(int id)
        {
            var vehicleMake = await _vehicleMakeService.GetVehicleMakeByIdAsync(id);
            if (vehicleMake == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VehicleMakeRest>(vehicleMake));
        }

        [HttpGet]
        [Route("PagedVehicleMakes")]
        public async Task<IHttpActionResult> GetPagedVehicleMakes([FromUri] QueryParameters queryParameters)
        {
            var vehicleMakes = await _vehicleMakeService.GetPagedVehicleMakesAsync(queryParameters);
            var metadata = new
            {
                vehicleMakes.TotalCount,
                vehicleMakes.PageSize,
                vehicleMakes.CurrentPage,
                vehicleMakes.TotalPages,
                vehicleMakes.HasNext,
                vehicleMakes.HasPrevious
            };
            System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(_mapper.Map<List<VehicleMakeRest>>(vehicleMakes));
        }
        
        // PUT: api/VehicleMakes/id
        [HttpPut]
        [Route("VehicleMakes/{id}")]
        public async Task<IHttpActionResult> PutVehicleMake(int id, VehicleMakeRest vehicleMakeRest)
        {
            try
            {
                var vehicleMake = _mapper.Map<IVehicleMake>(vehicleMakeRest);
                var updatedVehicleMake = await _vehicleMakeService.UpdateVehicleMakeAsync(id, vehicleMake);
                return Ok(updatedVehicleMake);
            }
            catch 
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }

        // POST: api/VehicleMakes
        [HttpPost]
        [Route("VehicleMakes")]
        public async Task<IHttpActionResult> PostVehicleMake(VehicleMakeRest vehicleMakeRest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var vehicleMake = _mapper.Map<IVehicleMake>(vehicleMakeRest);
                var newVehicleMake = await _vehicleMakeService.CreateVehicleMakeAsync(vehicleMake);
                return Ok(newVehicleMake);
            }
            catch
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
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
        [ResponseType(typeof(VehicleMakeRest))]
        [Route("OrderedVehicleMakes")]
        public async Task<IHttpActionResult> GetVehicleMakesOrderByName() 
        {
            var vehicleMakes = await _vehicleMakeService.GetVehicleMakesOrderByNameAsync();
            if (vehicleMakes == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<VehicleMakeRest>>(vehicleMakes));
        }
        [HttpGet]
        [ResponseType(typeof(VehicleMakeRest))]
        [Route("FilteredVehicleMakes")]
        public async Task<IHttpActionResult> GetVehicleMakesFilterByName(string name)
        {
            var vehicleMakes = await _vehicleMakeService.GetVehicleMakesFilterByNameAsync(name);
            if (vehicleMakes == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<VehicleMakeRest>>(vehicleMakes));
        }


    }
}