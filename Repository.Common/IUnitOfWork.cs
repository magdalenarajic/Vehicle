using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork
    {
        IVehicleMakeRepository VehicleMakeRepository { get; }
        IVehicleModelRepository VehicleModelRepository { get; }
        void Commit();
        void Dispose();
        int Save();
        Task CommitAsync();
    }
}
