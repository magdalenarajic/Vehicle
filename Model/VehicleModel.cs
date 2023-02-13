using Model.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class VehicleModel : IVehicleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        [ForeignKey("VehicleMake")]
        public int MakeId { get; set; }
        public virtual VehicleMake VehicleMake { get; set; }
        
       
    }
}
