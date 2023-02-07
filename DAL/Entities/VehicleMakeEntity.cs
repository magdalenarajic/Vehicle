using System.Collections.Generic;

namespace DAL.Entities
{
    public class VehicleMakeEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }


        public ICollection<VehicleModelEntity> VehicleModels { get; set; }
    }
}
