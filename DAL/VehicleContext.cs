using DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace DAL
{
    public class VehicleContext : DbContext, IVehicleContext
    {
        public VehicleContext(): base("VehicleContext")
        {
        }
        public DbSet<VehicleModelEntity> VehicleModels { get; set; }
        public DbSet<VehicleMakeEntity> VehicleMakes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
