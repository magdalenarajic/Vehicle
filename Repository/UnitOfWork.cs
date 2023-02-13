using DAL;
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
        private IVehicleModelRepository _vehicleModelRepository;
        private IVehicleMakeRepository _vehicleMakeRepository;
        public UnitOfWork(VehicleContext context)
        {
            _dbContext = context;
        }

        public IVehicleMakeRepository VehicleMakeRepository
        {
            get 
            { 
                return _vehicleMakeRepository = _vehicleMakeRepository ?? new VehicleMakeRepository(_dbContext); 
            }
        }

        public IVehicleModelRepository VehicleModelRepository 
        {
            get
            {
                return _vehicleModelRepository = _vehicleModelRepository ?? new VehicleModelRepository(_dbContext);
            }
            
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public async Task CommitAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void Rollback()
        {
            _dbContext.Dispose();
        }

        
    }
}
