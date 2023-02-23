using DAL.Entities;
using Model;
using Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        public IUnitOfWork _unitOfWork;

        public VehicleMakeService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<VehicleMakeEntity> GetVehicleMakeByIdAsync(int id)
        {
            if (id > 0)
            {
                var makes = await _unitOfWork.VehicleMakeEntities.GetByIdAsync(id);
                if (makes != null)
                {
                    return makes;
                }
            }
            return null;
            
        }

        public async Task<IEnumerable<VehicleMakeEntity>> GetAllVehicleMakesAsync()
        {
            
            var makes = await _unitOfWork.VehicleMakeEntities.GetAllAsync();
            return makes;
        }
        public async Task<bool> CreateVehicleMakeAsync(VehicleMakeEntity entity)
        {
            if (entity != null)
            {
                await _unitOfWork.VehicleMakeEntities.AddAsync(entity);
                _unitOfWork.Commit();
               return true;
            }
            return false;
        }

        public async Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeEntity entity)
        {
            if (entity != null)
            {
                var make = await _unitOfWork.VehicleMakeEntities.GetByIdAsync(id);
                 if (make != null)
                 {
                     make.Name = entity.Name;
                     make.Abrv = entity.Abrv;

                     await _unitOfWork.VehicleMakeEntities.UpdateAsync(make);

                    return true;
                 } 
            }
            return false;
        }

        public async Task<bool> DeleteVehicleMakeAsync(int id)
        {
                var make = await _unitOfWork.VehicleMakeEntities.GetByIdAsync(id);
                if (make != null)
                {
                   await _unitOfWork.VehicleMakeEntities.DeleteAsync(make);
                    _unitOfWork.Commit();
                   return true;
                }
                return false;
        }
    }
}
