using AutoMapper;
using Common;
using DAL.Entities;
using Model;
using Model.Common;
using Newtonsoft.Json;
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
        private readonly IMapper _mapper;
        public VehicleModelsController(IVehicleModelService vehicleModelService, IMapper mapper)
        {
            _vehicleModelService = vehicleModelService;
            _mapper = mapper;
        }
        // GET: api/VehicleModels
        [HttpGet]
        [Route("VehicleModels")]
        public async Task<List<IVehicleModel>> GetAll()
        {
            var vehicleModels = await _vehicleModelService.GetAllVehicleModelsAsync();
            return vehicleModels;
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
            return Ok(vehicleModels);
        }

        // PUT: api/VehicleModels/id
        [HttpPut]
        [ResponseType(typeof(void))]
        [Route("VehicleModels/{id}")]
        public async Task<IHttpActionResult> PutVehicleModel(int id, VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            { 
                var vehicleModelEntity = _mapper.Map<VehicleModelEntity>(vehicleModel);
                var updatedVehicleModel = await _vehicleModelService.UpdateVehicleModelAsync(id, vehicleModelEntity);
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
        public async Task<IHttpActionResult> PostVehicleModel(VehicleModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var vehicleModelEntity = _mapper.Map<VehicleModelEntity>(vehicleModel);
            var newVehicleModel = await _vehicleModelService.CreateVehicleModelAsync(vehicleModelEntity);
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

        [HttpGet]
        [Route("VehicleModelsOrderBy")]
        public async Task<List<IVehicleModel>> GetVehicleModelsOrderByName()
        {
            var vehicleModels = await _vehicleModelService.GetVehicleModelsOrderByNameAsync();
            return vehicleModels;
        }
        [HttpGet]
        [Route("VehicleModelsFilterBy")]
        public async Task<List<IVehicleModel>> GetVehicleModelsFilterByName(string name)
        {
            var vehicleModels = await _vehicleModelService.GetVehicleModelsFilterByNameAsync(name);
            return vehicleModels;
        }
    }
}