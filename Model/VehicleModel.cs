using Model.Common;

namespace Model
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public IVehicleMake VehicleMake { get; set; }
        
       
    }
}
