using Core.Models;
using System.Threading.Tasks;

namespace Core.Services
{
    public interface IGoogleMapService
    {
        Task<PlacesLocationPredictions> GetPlacesPredictionsAsync(string search);
        Task<AddressInfo> GetPlaceDetails(string placeId);
    }
}
