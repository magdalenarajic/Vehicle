using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Common
{
    public interface IVehicleModel
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

        [ForeignKey("IVehicleMake")]
        int MakeId { get; set; }
    }
}
