using DAL.Entities;
using Repository.Common;
using Service.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public IUnitOfWork _unitOfWork;

        public VehicleModelService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<VehicleModelEntity> GetVehicleModelByIdAsync(int id)
        {
            if (id > 0)
            {
                var model = await _unitOfWork.VehicleModelEntities.GetByIdAsync(id);
                if (model != null)
                {
                    return model;
                }
            }
            return null;
        }
        public async Task<IEnumerable<VehicleModelEntity>> GetAllVehicleModelsAsync()
        {
            var models = await _unitOfWork.VehicleModelEntities.GetAllAsync();
            return models;
        }
        public async Task<bool> CreateVehicleModelAsync(VehicleModelEntity entity)
        {
            if (entity != null)
            {
                await _unitOfWork.VehicleModelEntities.AddAsync(entity);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateVehicleModelAsync(int id, VehicleModelEntity entity)
        {
            if (entity != null)
            {
                var model = await _unitOfWork.VehicleModelEntities.GetByIdAsync(id);
                if (model != null)
                {
                    model.Name = entity.Name;
                    model.Abrv = entity.Abrv;

                    await _unitOfWork.VehicleModelEntities.UpdateAsync(model);

                    return true;
                }
            }
            return false;
        }
        public async Task<bool> DeleteVehicleModelAsync(int id)
        {
            var model = await _unitOfWork.VehicleModelEntities.GetByIdAsync(id);
            if (model != null)
            {
                await _unitOfWork.VehicleModelEntities.DeleteAsync(model);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }
    }
}
