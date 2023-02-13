
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class VehicleContext : DbContext, IVehicleContext
    {
        public VehicleContext(): base("VehicleContext")
        {
        }
        public DbSet<VehicleModel> VehicleModels { get; set; }
        public DbSet<VehicleMake> VehicleMakes { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        
    }
}
