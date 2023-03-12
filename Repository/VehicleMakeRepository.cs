using AutoMapper;
using Common;
using DAL;
using Model.Common;
using Repository.Common;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Repository
{
    public class VehicleMakeRepository :  IVehicleMakeRepository
    {
        private readonly VehicleContext _context;
        private readonly IMapper _mapper;
        public VehicleMakeRepository(VehicleContext context, IMapper mapper) 
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<IVehicleMake>> GetOrderByNameAsync()
        {
            var vehicleMakeEntities = await _context.VehicleMakes.OrderBy(e => e.Name).ToListAsync();
            return _mapper.Map<List<IVehicleMake>>(vehicleMakeEntities).ToList();
        }
        public async Task<List<IVehicleMake>> GetFilterByNameAsync(string search = null)
        {
            var query = _context.VehicleMakes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(e => e.Name.StartsWith(search));
            }
            var vehicleMakeEntities = await query.ToListAsync();
            return _mapper.Map<List<IVehicleMake>>(vehicleMakeEntities).ToList();
        }

        public async Task<PagedList<IVehicleMake>> GetPagedList(QueryParameters queryParameters)
        {
            var query = _context.VehicleMakes.AsQueryable();
            if (!string.IsNullOrWhiteSpace(queryParameters.Name))
            {
                query = query.Where(e => e.Name.StartsWith(queryParameters.Name));
            }

            var vehicleMakeEntities = await query.OrderBy(e => e.Id).ToListAsync();
            var count = vehicleMakeEntities.Count();
            var pageList = _mapper.Map<List<IVehicleMake>>(vehicleMakeEntities)
                .Skip((queryParameters.PageNumber - 1) * queryParameters.PageSize)
                .Take(queryParameters.PageSize);

            if (!string.IsNullOrWhiteSpace(queryParameters.Order) && (queryParameters.Order == "name"))
            {
                pageList = pageList.OrderBy(e => e.Name);
            }
            var pagedList = PagedList<IVehicleMake>.ToPagedList(pageList ,count, queryParameters.PageNumber, queryParameters.PageSize);
            return pagedList;
        }

    }
}
