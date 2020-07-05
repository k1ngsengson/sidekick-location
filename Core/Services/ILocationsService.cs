using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ILocationsService
    {
        Task<List<Location>> GetLocationsAsync();
        Task<bool> AddLocationAsync(Location location);
    }
}
