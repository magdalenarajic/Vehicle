namespace DAL.Entities
{
    public class VehicleModelEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Abrv { get; set; }
        public VehicleMakeEntity VehicleMake { get; set; }

    }
}
