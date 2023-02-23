using DAL;
using DAL.Entities;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly VehicleContext _dbContext;

        private readonly IGenericRepository<VehicleMakeEntity> _vehicleMakeEntities;
        private readonly IGenericRepository<VehicleModelEntity> _vehicleModelEntities;
        public UnitOfWork(VehicleContext context)
        {
            _dbContext = context;
        }

        public IGenericRepository<VehicleMakeEntity> VehicleMakeEntities => _vehicleMakeEntities ?? new GenericRepository<VehicleMakeEntity>(_dbContext);

        public IGenericRepository<VehicleModelEntity> VehicleModelEntities => _vehicleModelEntities ?? new GenericRepository<VehicleModelEntity>(_dbContext);
        public void Commit()
        {
            _dbContext.SaveChanges();
        }
       /* public int Save()
        {
            return _dbContext.SaveChanges();
        } */

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        
    }
}
