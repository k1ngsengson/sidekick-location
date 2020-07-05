namespace Data.Entities
{
    public class Location: BaseEntity
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }
    }
}
