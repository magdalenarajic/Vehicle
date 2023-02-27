using AutoMapper;
using Common;
using DAL;
using DAL.Entities;
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
    public class VehicleModelRepository :  IVehicleModelRepository
    {
        private readonly VehicleContext _context;
        private readonly IMapper _mapper;
        public VehicleModelRepository(VehicleContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IVehicleModel>> GetOrderByNameAsync()
        {
            var vehicleModelEntities = await _context.VehicleModels.OrderBy(e => e.Name).ToListAsync();
            return _mapper.Map<List<IVehicleModel>>(vehicleModelEntities).ToList();
        }
        public async Task<List<IVehicleModel>> GetFilterByNameAsync(string search = null)
        {
            var query = _context.VehicleModels.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e => e.Name.StartsWith(search));
            }
            var vehicleModelEntities = await query.ToListAsync();
            return _mapper.Map<List<IVehicleModel>>(vehicleModelEntities).ToList();
        }

        public async Task<PagedList<IVehicleModel>> GetPagedList(QueryParameters queryParameters)
        {
            var vehicleModelEntities = await _context.VehicleModels.OrderBy(e => e.Name).ToListAsync();
            var count = vehicleModelEntities.Count();

            var pageList = _mapper.Map<List<IVehicleModel>>(vehicleModelEntities)
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize);

            var pagedList = PagedList<IVehicleModel>.ToPagedList(pageList, count, queryParameters.PageNumber, queryParameters.PageSize);

            return pagedList;
        }
    }
}
