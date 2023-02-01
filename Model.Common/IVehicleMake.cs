using System.Collections.Generic;

namespace Model.Common
{
    public interface IVehicleMake
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }
        List<IVehicleModel> VehicleModels { get; set; }
    }
}
