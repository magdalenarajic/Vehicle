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

        public async Task<VehicleMake> GetVehicleMakeByIdAsync(Guid id)
        {
            return await _unitOfWork.VehicleMakeRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<VehicleMake>> GetAllVehicleMake()
        {
            return await _unitOfWork.VehicleMakeRepository.GetAllAsync();
        }
    }
}
