using Core.Models;
using Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface ILocationsService
    {
        Task<List<AddressInfo>> GetLocationsAsync();
        Task<bool> AddLocationAsync(AddressInfo location);
    }
}
