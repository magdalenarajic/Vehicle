using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPI.RESTModels
{
    public class VehicleModelRest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public int MakeId { get; set; }
    }
}