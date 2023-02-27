using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
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
    public class VehicleModelsController : ApiController
    {
        private readonly IVehicleModelService _vehicleModelService;
        private readonly IMapper _mapper;

        public VehicleModelsController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;

        }


        // GET: api/VehicleModels
        [HttpGet]
        [ResponseType(typeof(VehicleModelRest))]
        [Route("VehicleModels")]
        public async Task<IHttpActionResult> GetAll()
        {
            var vehicleModels = await _vehicleModelService.GetAllVehicleModelsAsync();
            if (vehicleModels == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<VehicleModelRest>>(vehicleModels));
        }


        // GET: api/VehicleModels/id
        [ResponseType(typeof(VehicleModelRest))]
        [Route("VehicleModels/{id}")]
        public async Task<IHttpActionResult> GetVehicleModel(int id)
        {
            var vehicleModel = await _vehicleModelService.GetVehicleModelByIdAsync(id);
            if (vehicleModel == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<VehicleModelRest>(vehicleModel));
        }


        [HttpGet]
        [Route("PagedVehicleModels")]
        public async Task<IHttpActionResult> GetPagedVehicleModels([FromUri] QueryParameters queryParameters)
        {
            var vehicleModels = await _vehicleModelService.GetPagedVehicleModelsAsync(queryParameters);
            var metadata = new
            {
                vehicleModels.TotalCount,
                vehicleModels.PageSize,
                vehicleModels.CurrentPage,
                vehicleModels.TotalPages,
                vehicleModels.HasNext,
                vehicleModels.HasPrevious
            };
            System.Web.HttpContext.Current.Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(metadata));
            return Ok(_mapper.Map<List<VehicleModelRest>>(vehicleModels));
        }


        // PUT: api/VehicleModels/id
        [HttpPut]
        [Route("VehicleModels/{id}")]
        public async Task<IHttpActionResult> PutVehicleModel(int id, VehicleModelRest vehicleModelRest)
        {
            try
            {
                var vehicleModel = _mapper.Map<IVehicleModel>(vehicleModelRest);
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
        [ResponseType(typeof(VehicleModelRest))]
        [Route("VehicleModels")]
        public async Task<IHttpActionResult> PostVehicleModel(VehicleModelRest vehicleModelRest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var vehicleModel = _mapper.Map<IVehicleModel>(vehicleModelRest);
                var newVehicleModel = await _vehicleModelService.CreateVehicleModelAsync(vehicleModel);
                return Ok(newVehicleModel);
            }
            catch
            {
                return StatusCode(HttpStatusCode.BadRequest);
            }
        }


        // DELETE: api/VehicleModels/id
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


        [HttpGet]
        [ResponseType(typeof(VehicleModelRest))]
        [Route("OrderedVehicleModels")]
        public async Task<IHttpActionResult> GetVehicleModelsOrderByName()
        {
            var vehicleModels = await _vehicleModelService.GetVehicleModelsOrderByNameAsync();
            if (vehicleModels == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<VehicleModelRest>>(vehicleModels));
        }


        [HttpGet]
        [ResponseType(typeof(VehicleModelRest))]
        [Route("FilteredVehicleModels")]
        public async Task<IHttpActionResult> GetVehicleModelsFilterByName(string name)
        {
            var vehicleModels = await _vehicleModelService.GetVehicleModelsFilterByNameAsync(name);
            if (vehicleModels == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<VehicleModelRest>>(vehicleModels));
        }


    }
}