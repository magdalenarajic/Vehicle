using AutoMapper;
using Common;
using DAL.Entities;
using Model.Common;
using Repository.Common;
using Service.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class VehicleModelService : IVehicleModelService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IVehicleModelRepository _vehicleModelRepository;
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

        public async Task<bool> CreateVehicleModelAsync(IVehicleModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                var vehicleModelEntity = _mapper.Map<VehicleModelEntity>(vehicleModel);
                await _unitOfWork.VehicleModelEntities.AddAsync(vehicleModelEntity);
                _unitOfWork.Commit();
                return true;
            }
            return false;
        }

        public async Task<bool> UpdateVehicleModelAsync(int id, IVehicleModel vehicleModel)
        {
            if (vehicleModel != null)
            {
                var newVehicleModel = _mapper.Map<VehicleModelEntity>(vehicleModel);
                var oldVehicleModel = await _unitOfWork.VehicleModelEntities.GetByIdAsync(id);
                if (oldVehicleModel != null)
                {
                    oldVehicleModel.Name = newVehicleModel.Name;
                    oldVehicleModel.Abrv = newVehicleModel.Abrv;

                    await _unitOfWork.VehicleModelEntities.UpdateAsync(oldVehicleModel);

                    return true;
                }
                return false;
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

        public async Task<PagedList<IVehicleModel>> GetPagedVehicleModelsAsync(QueryParameters queryParameters)
        {
            PagedList<IVehicleModel> pagedVehicleModels = await _vehicleModelRepository.GetPagedList(queryParameters);
            return pagedVehicleModels;
        } 
    }
}
