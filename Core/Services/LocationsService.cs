using Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public class LocationsService : ILocationsService
    {
        //private readonly ILocationsRepository _repository;

        //public LocationsService(ILocationsRepository repository)
        //{
        //    _repository = repository;
        //}
        public LocationsService()
        {
            items = new List<AddressInfo>();
        }

        private readonly List<AddressInfo> items;

        public async Task<bool> AddLocationAsync(AddressInfo location)
        {
            items.Add(location);

            return await Task.FromResult(true);//_repository.AddLocationAsync(location);
        }

        public async Task<List<AddressInfo>> GetLocationsAsync()
        {
            //var locations = await _repository.GetLocationsAsync();

            //return locations.ToList();

            return await Task.FromResult(items);
        }
    }
}
