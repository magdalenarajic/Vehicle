using System.Collections.Generic;
using System.Data.Entity;
using DAL.Entities;

namespace DAL
{
    public class VehicleContextInitializer: DropCreateDatabaseIfModelChanges<VehicleContext>
    {
        protected override void Seed(VehicleContext context)
        {
            GetVehicleMakes().ForEach(make => context.VehicleMakes.Add(make));
            context.SaveChanges();
            GetVehicleModels().ForEach(model => context.VehicleModels.Add(model));
            context.SaveChanges();
        } 
        private static List<VehicleMakeEntity> GetVehicleMakes()
        {
            var makes = new List<VehicleMakeEntity>
            {
                new VehicleMakeEntity
                {
                    Name = "Volkswagen1",
                    Abrv = "VW1"
                },
                new VehicleMakeEntity
                {
                    Name = "Audi",
                    Abrv = "A"
                },
            };
            return makes;
        }
        private static List<VehicleModelEntity> GetVehicleModels()
        {
            var models = new List<VehicleModelEntity>
            {
                new VehicleModelEntity
                {
                    Name = "Golf 1",
                    Abrv = "G1"
                },
                new VehicleModelEntity
                {
                    Name = "Golf 2",
                    Abrv = "G2"
                },
                new VehicleModelEntity
                {
                    Name = "Audi A5",
                    Abrv = "AA5",
                }
            };
            return models;
        }
    }
}
