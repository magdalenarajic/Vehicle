using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Common
{
    public interface IVehicleMake
    {
        int Id { get; set; }
        string Name { get; set; }
        string Abrv { get; set; }

    }
}
