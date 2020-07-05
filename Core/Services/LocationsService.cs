using Data.Entities;
using Data.Repositories;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
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
            items = new List<Location>()
            {
                new Location { Address = "First item" },
                new Location { Address = "Second item" },
                new Location { Address =  "Third item" },
                new Location { Address =  "Fourth item" },
                new Location { Address =  "Fifth item" },
                new Location { Address =  "Sixth item" }
            };
        }

        private readonly List<Location> items;

        public async Task<bool> AddLocationAsync(Location location)
        {
            items.Add(location);

            return await Task.FromResult(true);//_repository.AddLocationAsync(location);
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            //var locations = await _repository.GetLocationsAsync();

            //return locations.ToList();

            return await Task.FromResult(items);
        }
    }
}
