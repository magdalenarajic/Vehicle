using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class VehicleModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }

        [ForeignKey("VehicleMakeEntity")]
        public int MakeId { get; set; }
        public virtual VehicleMakeEntity VehicleMakeEntity { get; set; }
    }
}
