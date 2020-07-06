using Core.Models;
using Data.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Services
{
    public class LocationsService : ILocationsService
    {
        private readonly ILocationsRepository _repository;

        public LocationsService(ILocationsRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> AddLocationAsync(AddressInfo addressInfo)
        {   
            var location = addressInfo.ToLocation();

            return await _repository.AddLocationAsync(location);
        }

        public async Task<List<AddressInfo>> GetLocationsAsync()
        {
            var locations = await _repository.GetLocationsAsync();

            return locations.Select(item => item.ToAddressInfo()).ToList();
        }
    }
}
