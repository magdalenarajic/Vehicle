using AutoMapper;
using DAL;
using Microsoft.Extensions.Logging;
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

    }
}
