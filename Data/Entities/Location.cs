namespace Data.Entities
{
    public class Location: BaseEntity
    {
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
