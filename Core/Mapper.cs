using Core.Models;
using Entities;

namespace Core
{
    public static class Mapper
    {
        public static AddressInfo ToAddressInfo(this Location entity)
        {
            var model = new AddressInfo()
            {
                Address = entity.Address,
                Longitude = entity.Longitude,
                Latitude = entity.Latitude,
                //Json = entity.Json
            };

            return model;
        }

        public static Location ToLocation(this AddressInfo model)
        {
            var entity = new Location()
            {
                Address = model.Address,
                Longitude = model.Longitude,
                Latitude = model.Latitude,
                //Json = model.Json
            };

            return entity;
        }
    }
}
