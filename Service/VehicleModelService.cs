using AutoMapper;
using DAL.Entities;
using Model.Common;
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
        private readonly IMapper _mapper;
        private IVehicleModelRepository _vehicleModelRepository;
        public VehicleModelService(IUnitOfWork unitOfWork, IMapper mapper, IVehicleModelRepository vehicleModelRepository)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _vehicleModelRepository = vehicleModelRepository;
        }

        public async Task<IVehicleModel> GetVehicleModelByIdAsync(int id)
        {
            if (id > 0)
            {
                var vehicleModel = await _unitOfWork.VehicleModelEntities.GetByIdAsync(id);
                if (vehicleModel != null)
                {
                    var _vehicleModel = _mapper.Map<IVehicleModel>(vehicleModel);
                    return _vehicleModel;
                }
            }
            return null;
        }

        public async Task<List<IVehicleModel>> GetAllVehicleModelsAsync()
        {
            var vehicleModels = await _unitOfWork.VehicleModelEntities.GetAllAsync();
            return _mapper.Map<List<IVehicleModel>>(vehicleModels).ToList();
        }

        public async Task<bool> CreateVehicleModelAsync(VehicleModelEntity vehicleModelEntity)
        {
            if (vehicleModelEntity != null)
            {
                await _unitOfWork.VehicleModelEntities.AddAsync(vehicleModelEntity);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateVehicleModelAsync(int id, VehicleModelEntity vehicleModelEntity)
        {
            if (vehicleModelEntity != null)
            {
                var vehicleModel = await _unitOfWork.VehicleModelEntities.GetByIdAsync(id);
                if (vehicleModel != null)
                {
                    vehicleModel.Name = vehicleModelEntity.Name;
                    vehicleModel.Abrv = vehicleModelEntity.Abrv;

                    await _unitOfWork.VehicleModelEntities.UpdateAsync(vehicleModel);

                    return true;
                }
            }
            return false;
        }

        public async Task<bool> DeleteVehicleModelAsync(int id)
        {
            var vehicleModel = await _unitOfWork.VehicleModelEntities.GetByIdAsync(id);
            if (vehicleModel != null)
            {
                await _unitOfWork.VehicleModelEntities.DeleteAsync(vehicleModel);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public async Task<List<IVehicleModel>> GetVehicleModelsOrderByNameAsync()
        {
            var vehicleModelEntities = await _vehicleModelRepository.GetOrderByNameAsync();
            return new List<IVehicleModel>(vehicleModelEntities.ToList());
        }
        public async Task<List<IVehicleModel>> GetVehicleModelsFilterByNameAsync(string search)
        {
            var vehicleModelEntities = await _vehicleModelRepository.GetFilterByNameAsync(search);
            return new List<IVehicleModel>(vehicleModelEntities.ToList());
        }
    }
}
