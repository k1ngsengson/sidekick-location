using Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ILocationsRepository
    {
        Task<IEnumerable<Location>> GetLocationsAsync();
        Task<bool> AddLocationAsync(Location location);
    }
}
