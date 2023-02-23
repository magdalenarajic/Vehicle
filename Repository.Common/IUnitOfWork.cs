using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Common
{
    public interface IUnitOfWork
    {
        IGenericRepository<VehicleMakeEntity> VehicleMakeEntities { get; }
        IGenericRepository<VehicleModelEntity> VehicleModelEntities { get; }
        void Commit();
        void Dispose();
       // int Save();
        Task CommitAsync();
    }
}
