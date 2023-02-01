using System.Collections.Generic;

namespace Model.Common
{
    public interface IVehicleModel
    {
        int Id { get; set; }

        string Name { get; set; }
        string Abrv { get; set; }
        int MakeId { get; set; }
        IVehicleMake VehicleMake { get; set; }
    }
}
