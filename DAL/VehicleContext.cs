
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using DAL.Entities;
using Model;

namespace DAL
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(): base("VehicleContext")
        {
        }
        public DbSet<VehicleMakeEntity> VehicleMakes => Set<VehicleMakeEntity>();
        public DbSet<VehicleModelEntity> VehicleModels => Set<VehicleModelEntity>();
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
           
        }

        
    }
}
