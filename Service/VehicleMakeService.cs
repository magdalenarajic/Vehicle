using AutoMapper;
using DAL.Entities;
using Model;
using Model.Common;
using Repository.Common;
using Service.Common;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Service
{
    public class VehicleMakeService : IVehicleMakeService
    {
        public IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public VehicleMakeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IVehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            if (id > 0)
            {
                var vehicleMake = await _unitOfWork.VehicleMakeEntities.GetByIdAsync(id);
                if (vehicleMake != null)
                {
                    var _vehicleMake = _mapper.Map<IVehicleMake>(vehicleMake);
                    return _vehicleMake;
                }
            }
            return null;
            
        }

        public async Task<IEnumerable<IVehicleMake>> GetAllVehicleMakesAsync()
        {
            
            var vehicleMakes = await _unitOfWork.VehicleMakeEntities.GetAllAsync();

            return _mapper.Map<List<IVehicleMake>>(vehicleMakes).ToList();
        }
        public async Task<bool> CreateVehicleMakeAsync(VehicleMakeEntity vehicleMakeEntity)
        {
            if (vehicleMakeEntity != null)
            {
                await _unitOfWork.VehicleMakeEntities.AddAsync(vehicleMakeEntity);
                _unitOfWork.Commit();
               return true;
            }
            return false;
        }

        public async Task<bool> UpdateVehicleMakeAsync(int id, VehicleMakeEntity vehicleMakeEntity)
        {
            if (vehicleMakeEntity != null)
            {
                var vehicleMake = await _unitOfWork.VehicleMakeEntities.GetByIdAsync(id);
                 if (vehicleMake != null)
                 {
                     vehicleMake.Name = vehicleMakeEntity.Name;
                     vehicleMake.Abrv = vehicleMakeEntity.Abrv;

                     await _unitOfWork.VehicleMakeEntities.UpdateAsync(vehicleMake);

                    return true;
                 } 
            }
            return false;
        }

        public async Task<bool> DeleteVehicleMakeAsync(int id)
        {
                var vehicleMake = await _unitOfWork.VehicleMakeEntities.GetByIdAsync(id);
                if (vehicleMake != null)
                {
                   await _unitOfWork.VehicleMakeEntities.DeleteAsync(vehicleMake);
                    _unitOfWork.Commit();
                   return true;
                }
                return false;
        }
    }
}
