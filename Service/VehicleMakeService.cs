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

        public async Task<VehicleMake> GetVehicleMakeByIdAsync(int id)
        {
            if (id > 0)
            {
                var makes = await _unitOfWork.VehicleMakeRepository.GetByIdAsync(id);
                if (makes != null)
                {
                    return makes;
                }
            }
            return null;
            
        }

        public async Task<IEnumerable<VehicleMake>> GetAllVehicleMakesAsync()
        {
            
            var makes = await _unitOfWork.VehicleMakeRepository.GetAllAsync();
            return makes;
        }
        public async Task<bool> CreateVehicleMakeAsync(VehicleMake entity)
        {
            if (entity != null)
            {
                await _unitOfWork.VehicleMakeRepository.AddAsync(entity);

                var result = _unitOfWork.Save();

                if (result > 0)
                    return true;
                else
                    return false;
            }
            return false;
        }

        public async Task<bool> UpdateVehicleMakeAsync(VehicleMake vehicleMake)
        {
            if (vehicleMake != null)
            {
                var make = await _unitOfWork.VehicleMakeRepository.GetByIdAsync(vehicleMake.Id);
                if (make != null)
                {
                    make.Name = vehicleMake.Name;
                    make.Abrv = vehicleMake.Abrv;
                   

                    await _unitOfWork.VehicleMakeRepository.UpdateAsync(make);

                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }

        public async Task<bool> DeleteVehicleMakeAsync(int id)
        {
            if (id > 0)
            {
                var make = await _unitOfWork.VehicleMakeRepository.GetByIdAsync(id);
                if (make != null)
                {
                    await _unitOfWork.VehicleMakeRepository.DeleteAsync(make);
                    var result = _unitOfWork.Save();

                    if (result > 0)
                        return true;
                    else
                        return false;
                }
            }
            return false;
        }
    }
}
